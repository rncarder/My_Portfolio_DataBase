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

namespace AHSDataEntry
{
    public partial class EpisodeForm : Form
    {
        public string connectionString = AHSProvider.ConnectionString();
        public string query = AHSProvider.SelectQueryString(AHSProvider.seasons, AHSProvider.SeasonColumnsList.Where(n => n != "SeaonNum").ToList());
        DataSet ds = new DataSet();
        public EpisodeForm()
        {
            InitializeComponent();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using(SqlDataAdapter a =  new SqlDataAdapter(cmd))
                    {
                        a.Fill(ds);
                    }
                }

            }
            cmbSeasonList.DataSource = ds.Tables[0];
            cmbSeasonList.DisplayMember = "Name";
            cmbSeasonList.ValueMember = "Id";
            cmbSeasonList.SelectedIndex = -1;
            
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

            List<string> colList = AHSProvider.episodesColums.Where(i => i != "Id").ToList();
            string q = AHSProvider.InsertQueryString(AHSProvider.eps, colList);
            if (UIHelper.AntiDoops(AHSProvider.SelectQueryString(AHSProvider.eps, colList), new List<string> { txtEpName.Text.ToString() }))
            {
                UIHelper.UiCleaner(Controls);
                txtEpName.Focus();
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(q, conn))
                {
                    if (txtEpName.Text != null && cmbSeasonList.SelectedIndex >= 0)
                    {
                        cmd.Parameters.AddWithValue("@" + AHSProvider.episodesColums[1], epName);
                        cmd.Parameters.AddWithValue("@" + AHSProvider.episodesColums[2], cmbSeasonList.SelectedValue);
                    }
                    int x = cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show($"{epName} has succesfully been added to the Database");
            UIHelper.UiCleaner(Controls);
            txtEpName.Focus();
        }
    }
}
