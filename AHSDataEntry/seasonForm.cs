using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AHS.Core;

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

            string connectionString = AHSProvider.ConnectionString();

            var insertCols = AHSProvider.SeasonColumnsList.Where(c => c != "Id").ToList();
            string q = AHSProvider.InsertQueryString("Seasons", insertCols);
            string antiDoopQuery = AHSProvider.SelectQueryString(AHSProvider.seasons, insertCols);
            object seasonNum = UIHelper.TextBoxCheck(txtSeasonNum.Text.ToString(), false, true);
            object seasonName = UIHelper.TextBoxCheck(txtSeasonName.Text.ToString(), false, false);
            if (seasonNum == null)
            {
                MessageBox.Show("Please Enter A Valid Number Into Seaon Number Box");
                UIHelper.UiCleaner(Controls);
                txtSeasonNum.Focus();
                return;
            }
            if (seasonName == null)
            {
                MessageBox.Show("Please Enter a Valid Name into the Season Name Box");
                UIHelper.UiCleaner(Controls);
                txtSeasonNum.Focus();
                return;
            }
            if (UIHelper.AntiDoops(antiDoopQuery, new List<string> { txtSeasonName.Text.ToString(), txtSeasonNum.Text.ToString() }))
            {
                MessageBox.Show($"{txtSeasonName.Text.ToString()}, is already added to dataBase");
                UIHelper.UiCleaner(Controls);
                txtSeasonNum.Focus();
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(q, conn))
                {
                    cmd.Parameters.AddWithValue("@SeasonNum", seasonNum);
                    cmd.Parameters.AddWithValue("@Name", seasonName);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show($"{seasonName} added To DB as Season Num {seasonNum}");
            UIHelper.UiCleaner(this.Controls);
        }
    }
}
