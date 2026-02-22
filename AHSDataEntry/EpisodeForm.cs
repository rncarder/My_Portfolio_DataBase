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
                    seasonsList.AddRange(db.Seasons.AsNoTracking().ToList());
                    UIHelper.SetComboBox(cmbSeasonList, seasonsList);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching seasons from the database: {ex.Message}");
            }
            if (AHSProvider.episodeBuffer.Count > 0)
            {
                episodeDash.DataSource = AHSProvider.charBuffer;
                episodeDash.Columns["Id"].Visible = false;
            }
            if (AHSProvider.seasonbuffer.Count > 0)
            {
                seasonDash.DataSource = AHSProvider.seasonbuffer;
                seasonDash.Columns["Id"].Visible = false;
            }

        }


        private void openSsnPnl_Click(object sender, EventArgs e)
        {
            panel.Visible = true;

        }
        private void addSeasonBtn_Click(object sender, EventArgs e)
        {
            object seasonNum = UIHelper.TextBoxCheck(txtSeasonNum.Text.ToString(), false, true);
            if (seasonNum == null)
            {
                lblEpPnlSeasonNum.BackColor = Color.Red;
                txtSeasonNum.Focus();
                return;
            }
            object seasonName = UIHelper.TextBoxCheck(txtSeasonName.Text.ToString(), false, false);
            if (seasonName == null)
            {
                lblEpPnlSeasonName.BackColor = Color.Red;
                txtSeasonNum.Focus();
                return;
            }
            Season season = new Season() { SeasonNum = (int)seasonNum, Name = seasonName.ToString() };
            if (!AHSProvider.addToBuffer(season))
            {
                MessageBox.Show($"{seasonName} is already in buffer.");
                UIHelper.UiCleaner(panel.Controls, DefaultBackColor);
                txtSeasonNum.Focus();
                return;
            }
            seasonsList.Add(season);
            UIHelper.SetComboBox(cmbSeasonList, seasonsList);
            seasonDash.DataSource = null;
            seasonDash.DataSource = AHSProvider.seasonbuffer;
            UIHelper.UiCleaner(panel.Controls, DefaultBackColor);
            panel.Visible = false;
        }
        private void addEpBtn_click(object sender, EventArgs e)
        {
            object epName = UIHelper.TextBoxCheck(txtEpName.Text.ToString(), false, false);
            if (epName == null)
            {
                lblEpName.BackColor = Color.Red;
                txtEpName.Focus();
                return;
            }
            if (!UIHelper.ComboBoxCheck(cmbSeasonList.SelectedIndex, false))
            {
                lblEpSeason.BackColor = Color.Red;
                cmbSeasonList.Focus();
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
                UIHelper.UiCleaner(Controls, DefaultBackColor);
                txtEpName.Focus();
                return;
            }
            episodeDash.DataSource = null;
            episodeDash.DataSource = AHSProvider.episodeBuffer;
            episodeDash.Columns["Id"].Visible = false;
            UIHelper.UiCleaner(Controls, DefaultBackColor);
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
                UIHelper.UiCleaner(Controls, DefaultBackColor);
                txtEpName.Focus();
            }

        }


    }
}
