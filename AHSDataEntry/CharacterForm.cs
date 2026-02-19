using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AHS.Core;
using Microsoft.EntityFrameworkCore;
using AHSDb.Models;

namespace AHSDataEntry
{
    public partial class CharacterForm : Form
    {
        public bool isCastPanelOpen = false;
        public bool isSeasonPanelOpen = false;
        List<Cast> castList = new List<Cast>();
        List<Season> seasonList = new List<Season>();
        public CharacterForm()
        {
            InitializeComponent();

            using (AHSDbContext context = new AHSDbContext())
            {
                ;
                try
                {
                    castList = context.Casts.AsNoTracking().ToList();
                    if (AHSProvider.castBuffer.Count > 0)
                    {
                        castList.AddRange(AHSProvider.castBuffer);
                    }
                    seasonList = context.Seasons.AsNoTracking().ToList();
                    if (AHSProvider.seasonbuffer.Count > 0)
                    {
                        seasonList.AddRange(AHSProvider.seasonbuffer);
                    }
                    setCastComboBox();
                    SetSeasonComboBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while fetching data: {ex.Message}");
                    //return;
                }


            }
        }
        private void CharAddToBuffer_click(object sender, EventArgs e)
        {

            object charName = UIHelper.TextBoxCheck(txtcharName.Text.ToString(), false, false);
            if (charName == null)
            {
                MessageBox.Show("Please enter a Valid name into the Name Box");
                txtcharName.Focus();
                return;
            }
            object ep1 = UIHelper.TextBoxCheck(txtEpNum.Text, false, true);
            if (ep1 == null)
            {
                MessageBox.Show("Please Enter a valid number for number of Episodes");
                txtEpNum.Focus();
                return;
            }
            object ep2 = UIHelper.TextBoxCheck(txtEp2.Text, true, true);

            if (!UIHelper.ComboBoxCheck(cmbSeasonList1.SelectedIndex, false))
            {
                MessageBox.Show($"Please select a season From Season1 Dropdown");
                cmbSeasonList1.Focus();
                return;
            }
            if (!UIHelper.ComboBoxCheck(cmbCastList.SelectedIndex, false))
            {
                MessageBox.Show($"Please select a Cast member from the cast Dropown");
                cmbCastList.Focus();
                return;
            }
            
            if (!AHSProvider.addToBuffer(new Character
            {
                Name = charName.ToString(),
                Cast = (Cast)cmbCastList.SelectedValue,
                Season1 = (Season)cmbSeasonList1.SelectedValue,
                Season2 = (Season)cmbSeasonList2.SelectedValue,
                NumOfEpisodes1 = (int)ep1,
                NumOfEpisodes2 = (int)(ep2 ?? 0)


            }))
            {
                MessageBox.Show($"{charName.ToString()} is already in buffer)");
                txtcharName.Focus();
                UIHelper.UiCleaner(this.Controls);
                return;
            }

            UIHelper.UiCleaner(this.Controls);
            txtcharName.Focus();
        }

        private async void commitBtn_Click(object sender, EventArgs e)
        {
            if (AHSProvider.charBuffer.Count == 0)
            {
                MessageBox.Show("There is nothing in the buffer to commit");
                return;
            }
            using (AHSDbContext db = new AHSDbContext())
            {
                try
                {
                    if (AHSProvider.castBuffer.Count > 0)
                    {
                        List<Cast> castDbCheckList = AHSProvider.castBuffer.Where(c => !db.Casts.Any(c2 => c2.Name == c.Name)).ToList();
                        foreach (Cast cast in castDbCheckList)
                        {
                            await db.Casts.AddAsync(cast);
                        }
                        //await db.SaveChangesAsync();
                    }
                    if (AHSProvider.seasonbuffer.Count > 0)
                    {
                        List<Season> seasonDbCheckList = AHSProvider.seasonbuffer.Where(s => !db.Seasons.Any(s2 => s2.Name == s.Name)).ToList();
                        foreach (Season season in seasonDbCheckList)
                        {
                            await db.Seasons.AddAsync(season);
                        }
                        //await db.SaveChangesAsync();
                    }
                    List<Character> dbCheckList = AHSProvider.charBuffer.Where(c => !db.Characters.Any(c2 => c2.Name == c.Name)).ToList();
                    if (dbCheckList.Count < AHSProvider.charBuffer.Count)
                    {
                        MessageBox.Show("Some characters in the buffer already exist in the database and will not be added");

                    }
                    foreach (Character character in dbCheckList)
                    {
                        await db.Characters.AddAsync(character);
                    }
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while committing to the database: {ex.Message}");
                    return;
                }
                finally
                {
                    AHSProvider.charBuffer.Clear();
                    AHSProvider.castBuffer.Clear();
                    AHSProvider.seasonbuffer.Clear();
                    MessageBox.Show("Buffer Committed to Database Successfully");
                }
            }
        }

        private void OpenCastPanel_Click(object sender, EventArgs e)
        {
            panel.Visible = true;
            pnlLblSeasonNum.Visible = false;
            pnlTxtSeasonNum.Visible = false;
            PnlTxtName.Focus();
            isCastPanelOpen = true;
        }

        private void OpenSeasonPanel_Click(object sender, EventArgs e)
        {
            panel.Visible = true;
            pnlLblSeasonNum.Visible = true;
            pnlTxtSeasonNum.Visible = true;
            pnlTxtSeasonNum.Focus();
            isSeasonPanelOpen = true;
        }

        private void pnlAddBtn_Click(object sender, EventArgs e)
        {

            if (isCastPanelOpen)
            {
                object castName = UIHelper.TextBoxCheck(PnlTxtName.Text.ToString(), false, false);
                if (castName == null)
                {
                    MessageBox.Show("Please enter a Valid name into the Name Box");
                    PnlTxtName.Focus();
                    return;
                }
                Cast cast = new Cast() { Name = castName.ToString() };
                if (!AHSProvider.addToBuffer(cast))
                {
                    MessageBox.Show($"{castName.ToString()} is already in buffer");
                    PnlTxtName.Focus();
                    UIHelper.UiCleaner(panel.Controls);
                    return;
                }
                castList.Add(cast);
                setCastComboBox();
                isCastPanelOpen = false;

            }
            else if (isSeasonPanelOpen)
            {
                object seasonNum = UIHelper.TextBoxCheck(pnlTxtSeasonNum.Text.ToString(), false, true);
                if (seasonNum == null)
                {
                    MessageBox.Show("Please enter a Valid number into the Season Number Box");
                    pnlTxtSeasonNum.Focus();
                    return;
                }
                object seasonName = UIHelper.TextBoxCheck(PnlTxtName.Text.ToString(), false, false);
                if (seasonName == null)
                {
                    MessageBox.Show("Please enter a Valid name into the Name Box");
                    PnlTxtName.Focus();
                    return;
                }
                Season season = new Season() { SeasonNum = (int)seasonNum, Name = seasonName.ToString() };
                if (!AHSProvider.addToBuffer(season))
                {
                    MessageBox.Show($"{seasonName.ToString()} is already in buffer");
                    PnlTxtName.Focus();
                    UIHelper.UiCleaner(panel.Controls);
                    return;
                }
                seasonList.Add(season);
                SetSeasonComboBox();
                isSeasonPanelOpen = false;
            }
            UIHelper.UiCleaner(panel.Controls);
            panel.Visible = false;
        }
        public void setCastComboBox()
        {
            cmbCastList.DataSource = null;
            cmbCastList.DataSource = castList;
            cmbCastList.DisplayMember = "Name";
            //cmbCastList.ValueMember = "Id";
            cmbCastList.SelectedIndex = -1;

        }
        public void SetSeasonComboBox()
        {
            cmbSeasonList1.DataSource = null;
            cmbSeasonList1.DataSource = seasonList;
            cmbSeasonList1.DisplayMember = "Name";
            cmbSeasonList1.SelectedIndex = -1;

            cmbSeasonList2.DataSource = null;
            cmbSeasonList2.DataSource = seasonList;
            cmbSeasonList2.DisplayMember = "Name";
            cmbSeasonList2.BindingContext = new BindingContext();
            cmbSeasonList2.SelectedIndex = -1;
        }

    }
}
