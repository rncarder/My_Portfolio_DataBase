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
        public Color cntrlClr;
        public bool isCastPanelOpen = false;
        public bool isSeasonPanelOpen = false;
        List<Cast> castList = new List<Cast>();
        List<Season> seasonList = new List<Season>();
        public CharacterForm()
        {
            InitializeComponent();
            fetchData();
            if (AHSProvider.charBuffer.Count > 0) { UpdateCharDash(); }
        }
        public void fetchData()
        {
            using (AHSDbContext context = new AHSDbContext())
            {

                try
                {
                    context.Casts.AsNoTracking().ToList();
                    if (AHSProvider.castBuffer.Count > 0)
                    {
                        castList.AddRange(AHSProvider.castBuffer);
                       
                    }
                    seasonList = context.Seasons.AsNoTracking().ToList();
                    if (AHSProvider.seasonbuffer.Count > 0)
                    {
                        seasonList.AddRange(AHSProvider.seasonbuffer);
                    }
                    UIHelper.SetComboBox(cmbCastList, castList);
                    UIHelper.SetComboBox(cmbSeasonList1, seasonList);
                    UIHelper.SetComboBox(cmbSeasonList2, seasonList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while fetching data: {ex.Message}");
                    //return;
                }


            }
        }
        public void UpdateCharDash()
        {
            charDashBoard.DataSource = null;
            charDashBoard.DataSource = AHSProvider.charBuffer;
            charDashBoard.Columns["Id"].Visible = false;
        }
        private void CharAddToBuffer_click(object sender, EventArgs e)
        {

            object charName = UIHelper.TextBoxCheck(txtcharName.Text.ToString(), false, false);
            if (charName == null)
            {
                lblCharName.BackColor = Color.Red;
                txtcharName.Focus();
                return;
            }
            object ep1 = UIHelper.TextBoxCheck(txtEpNum.Text, false, true);
            if (ep1 == null)
            {

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
                UIHelper.UiCleaner(this.Controls, cntrlClr);
                return;
            }

            UIHelper.UiCleaner(this.Controls, cntrlClr);
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
            isSeasonPanelOpen = false;
            isCastPanelOpen = true;
        }

        private void OpenSeasonPanel_Click(object sender, EventArgs e)
        {
            panel.Visible = true;
            pnlLblSeasonNum.Visible = true;
            pnlTxtSeasonNum.Visible = true;
            pnlTxtSeasonNum.Focus();
            isCastPanelOpen = false;
            isSeasonPanelOpen = true;
        }

        private void pnlAddBtn_Click(object sender, EventArgs e)
        {

            if (isCastPanelOpen)
            {
                object castName = UIHelper.TextBoxCheck(PnlTxtName.Text.ToString(), false, false);
                if (castName == null)
                {
                    pnlLblName.BackColor = Color.Red;
                    PnlTxtName.Focus();
                    return;
                }
                Cast cast = new Cast() { Name = castName.ToString() };
                if (!AHSProvider.addToBuffer(cast))
                {
                    MessageBox.Show($"{castName.ToString()} is already in buffer");
                    PnlTxtName.Focus();
                    UIHelper.UiCleaner(panel.Controls, cntrlClr);
                    return;
                }
                castList.Add(cast);
                UIHelper.SetComboBox(cmbCastList, castList);
                isCastPanelOpen = false;

            }
            else if (isSeasonPanelOpen)
            {
                object seasonNum = UIHelper.TextBoxCheck(pnlTxtSeasonNum.Text.ToString(), false, true);
                if (seasonNum == null)
                {
                    pnlLblSeasonNum.BackColor = Color.Red;
                    pnlTxtSeasonNum.Focus();
                    return;
                }
                object seasonName = UIHelper.TextBoxCheck(PnlTxtName.Text.ToString(), false, false);
                if (seasonName == null)
                {
                    pnlLblName.BackColor = Color.Red;
                    PnlTxtName.Focus();
                    return;
                }
                Season season = new Season() { SeasonNum = (int)seasonNum, Name = seasonName.ToString() };
                if (!AHSProvider.addToBuffer(season))
                {
                    MessageBox.Show($"{seasonName.ToString()} is already in buffer");
                    PnlTxtName.Focus();
                    UIHelper.UiCleaner(panel.Controls, cntrlClr);
                    return;
                }
                seasonList.Add(season);
                UIHelper.SetComboBox(cmbSeasonList1, seasonList);
                UIHelper.SetComboBox(cmbSeasonList2, seasonList);
                isSeasonPanelOpen = false;
            }

            UIHelper.UiCleaner(panel.Controls, cntrlClr);
            panel.Visible = false;
        }

        private void charDashBoard_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
