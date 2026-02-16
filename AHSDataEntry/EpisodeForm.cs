using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AHS.Core;
using AHSDb.Models;
using Microsoft.EntityFrameworkCore;

namespace AHSDataEntry
{
    public partial class EpisodeForm : Form
    {
        public List<Season> seasonsList = new List<Season>();
        public EpisodeForm()
        {
            InitializeComponent();
            try
            {
                using (AHSDbContext db = new AHSDbContext())
                {
                    if (AHSProvider.seasonbuffer.Count > 0)
                    {
                        seasonsList.AddRange(AHSProvider.seasonbuffer);
                    }
                    db.Seasons.AsNoTracking().ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching seasons from the database: {ex.Message}");
            }


        }
        public void SetSeasonComboBox()
        {
            cmbSeasonList.DataSource = null;
            cmbSeasonList.DataSource = seasonsList;
            cmbSeasonList.DisplayMember = "Name";
            cmbSeasonList.SelectedIndex = -1;
        }

        private void openSsnPnl_Click(object sender, EventArgs e)
        {
            panel.Visible = true;

        }
        private void addSeasonBtn_Click(object sender, EventArgs e)
        {
            object seasonNum = UIHelper.TextBoxCheck(txtSeasonNum.Text.ToString(), false, true);
            if(seasonNum == null)
            {
                MessageBox.Show("Please enter Valid Number of Season into the Number box");
                UIHelper.UiCleaner(panel.Controls);
                txtSeasonNum.Focus();
                return;
            }
            object seasonName = UIHelper.TextBoxCheck(txtSeasonName.Text.ToString(), false, false);
            if(seasonName == null)
            {
                MessageBox.Show("Please enter Valid Name of Season into the Name box");
                UIHelper.UiCleaner(panel.Controls);
                txtSeasonNum.Focus();
                return;
            }
            Season season = new Season() { SeasonNum = (int)seasonNum, Name = seasonName.ToString() };
            if (!AHSProvider.addToBuffer(season))
            {
                MessageBox.Show( $"{seasonName} is already in buffer.");
                UIHelper.UiCleaner(panel.Controls);
                txtSeasonNum.Focus();
                return;
            }
            seasonsList.Add(season);
            SetSeasonComboBox();
            UIHelper.UiCleaner(panel.Controls);
            panel.Visible = false;
        }
        private void addEpBtn_click(object sender, EventArgs e)
        {
            object epName = UIHelper.TextBoxCheck(txtEpName.Text.ToString(), false, false);
            if (epName == null)
            {
                MessageBox.Show("Please enter Valid Name of Episode into the Name box");
                UIHelper.UiCleaner(Controls);
                txtEpName.Focus();
                return;
            }
            if (!UIHelper.ComboBoxCheck(cmbSeasonList.SelectedIndex, false))
            {
                MessageBox.Show("Plase select a Season from Dropdown");
                UIHelper.UiCleaner(Controls);
                txtEpName.Focus();
                return;
            }
            Episode ep = new Episode()
            {
                Name = epName.ToString(),
                Season = (Season)cmbSeasonList.SelectedValue
            };
            if (!AHSProvider.addToBuffer(ep))
            {
                MessageBox.Show($"{ep.Name} already exists in the buffer. Please avoid duplicates.");
                UIHelper.UiCleaner(Controls);
                txtEpName.Focus();
                return;
            }
            UIHelper.UiCleaner(Controls);
            txtEpName.Focus();
        }

        private async void EpsCommitBtn_Click(object sender, EventArgs e)
        {
            if (AHSProvider.episodeBuffer.Count == 0)
            {
                MessageBox.Show("There are no Episodes in the buffer to commit.");
                return;
            }
            try
            {
                using (AHSDbContext db = new AHSDbContext())
                {
                    List<Episode> epBufferCheck = AHSProvider.episodeBuffer.Where(e => !db.Episodes.Any(e2 => e2.Name == e.Name)).ToList();
                    foreach (Episode ep in epBufferCheck)
                    {
                        db.Episodes.AddAsync(ep);
                    }
                    await db.SaveChangesAsync();
                    MessageBox.Show($"epsiodes commited successfuully to dataBase");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                AHSProvider.episodeBuffer.Clear();
                UIHelper.UiCleaner(Controls);
                txtEpName.Focus();
            }

        }


    }
}
