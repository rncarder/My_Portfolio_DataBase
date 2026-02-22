using AHS.Core;
using AHSDb.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AHSDataEntry
{
    public partial class seasonForm : Form
    {
        public seasonForm()
        {
            InitializeComponent();
            if (AHSProvider.seasonbuffer.Count > 0)
            {
                bufferDash.DataSource = AHSProvider.seasonbuffer;
                bufferDash.Columns["Id"].Visible = false;
            }
            
        }
        private void addSeason_Click(object sender, EventArgs e)
        {

            object seasonNum = UIHelper.TextBoxCheck(txtSeasonNum.Text.ToString(), false, true);
            if (seasonNum == null)
            {
                lblSeasonNum.BackColor = Color.Red;
                txtSeasonNum.Focus();
                return;
            }
            object seasonName = UIHelper.TextBoxCheck(txtSeasonName.Text.ToString(), false, false);
            //MessageBox.Show($"season name: {seasonName}");
            if (seasonName == null)
            {
                lblSeasonName.BackColor = Color.Red;
                txtSeasonName.Focus();
                return;
            }

            if (!AHSProvider.addToBuffer(new Season { SeasonNum = (int)seasonNum, Name = seasonName.ToString() }))
            {
                MessageBox.Show($"{seasonName.ToString()} or Season Number {seasonNum.ToString()} is already added to the pending list");
                UIHelper.UiCleaner(Controls, DefaultBackColor);
                txtSeasonNum.Focus();
                return;
            }
            UIHelper.UiCleaner(Controls, DefaultBackColor);
            txtSeasonNum.Focus();
            bufferDash.DataSource = null;
            bufferDash.DataSource = AHSProvider.seasonbuffer;
            bufferDash.Columns["Id"].Visible = false;

        }



        private async void commitBtn_Click(object sender, EventArgs e)
        {

            //MessageBox.Show("is working");
            if (AHSProvider.seasonbuffer.Count <= 0)
            {
                MessageBox.Show("There are no seasons to be added");
                return;
            }
            try
            {
                using (AHSDbContext db = new AHSDbContext())
                {
                    //MessageBox.Show("context");

                    var nonexsisisting = AHSProvider.seasonbuffer.Where(s => !db.Seasons.Any(s2 => s2.SeasonNum == s.SeasonNum || s2.Name == s.Name)).ToList();
                    if (nonexsisisting.Count <= 0)
                    {
                        MessageBox.Show("All Seasons in the pending list already exist in the database");
                        AHSProvider.seasonbuffer.Clear();
                        return;
                    }

                    foreach (var season in nonexsisisting)
                    {
                        await db.AddAsync(new Season { SeasonNum = season.SeasonNum, Name = season.Name });
                    }
                    await db.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"An error occurred while connecting to the database: {ex.Message}");
            }
            finally
            {
                UIHelper.UiCleaner(Controls, DefaultBackColor);
                MessageBox.Show("seasons saved");
                AHSProvider.seasonbuffer.Clear();
            }

        }

        private void bufferDash_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            txtSeasonNum.Text = AHSProvider.seasonbuffer[rowIndex].SeasonNum.ToString();
            txtSeasonName.Text = AHSProvider.seasonbuffer[rowIndex].Name.ToString();
            AHSProvider.seasonbuffer.RemoveAt(rowIndex);
            bufferDash.DataSource = null;
            bufferDash.DataSource = AHSProvider.seasonbuffer;
            bufferDash.Columns["id"].Visible = false;
            Debug.WriteLine($"rowindex; {e.RowIndex}");
        }

    }
}
