using AHS.Core;
using AHSDb.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        }
        private void addSeason_Click(object sender, EventArgs e)
        {
            
            object seasonNum = UIHelper.TextBoxCheck(txtSeasonNum.Text.ToString(), false, true);
            if (seasonNum == null)
            {
                MessageBox.Show("Please Enter A Valid Number Into Seaon Number Box");
                //UIHelper.UiCleaner(Controls);
                txtSeasonNum.Focus();
                return;
            }
            object seasonName = UIHelper.TextBoxCheck(txtSeasonName.Text.ToString(), false, false);
            //MessageBox.Show($"season name: {seasonName}");
            if (seasonName == null)
            {
                MessageBox.Show("Please Enter a Valid Name into the Season Name Box");
                //UIHelper.UiCleaner(Controls);
                txtSeasonName.Focus();
                return;
            }

            if (AHSProvider.seasonbuffer.Any(s => s.seasonNum == (int)seasonNum || s.Name == seasonName.ToString()))
            {
                MessageBox.Show($"{seasonName.ToString()} or Season Number {seasonNum.ToString()} is already added to the pending list");
                UIHelper.UiCleaner(Controls);
                txtSeasonNum.Focus();
                return;
            }
            AHSProvider.seasonbuffer.Add(new _season { seasonNum = (int)seasonNum, Name = seasonName.ToString() });

            //MessageBox.Show($"season name: {season.Name} seasonnum: {season.seasonNum}");
            UIHelper.UiCleaner(Controls);
            //AHSProvider.seasonbuffer.Add(season);
           

        }



        private void commitBtn_Click(object sender, EventArgs e)
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
                    
                    var nonexsisisting = AHSProvider.seasonbuffer.Where(s => !db.Seasons.Any(s2 => s2.SeasonNum == s.seasonNum || s2.Name == s.Name)).ToList();
                    if (nonexsisisting.Count <= 0)
                    {
                        MessageBox.Show("All Seasons in the pending list already exist in the database");
                        AHSProvider.seasonbuffer.Clear();
                        return;
                    }
                    
                    foreach (var season in nonexsisisting)
                    {
                        db.Add(new AHSDb.Models.Season
                        {
                            SeasonNum = season.seasonNum,
                            Name = season.Name
                        });
                    }
                    db.SaveChanges();
                    AHSProvider.seasonbuffer.Clear();
                    UIHelper.UiCleaner(Controls);
                    MessageBox.Show("data entered into database");
                    txtSeasonNum.Focus();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"An error occurred while connecting to the database: {ex.Message}");
            }
            
        }
    }
}
