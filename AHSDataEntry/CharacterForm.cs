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
    public partial class CharacterForm : Form
    {
        public CharacterForm()
        {
            InitializeComponent();
            DataSet ds = new DataSet();
            string q = $"{AHSProvider.SelectQueryString(AHSProvider.casts, AHSProvider.castColumns)}; " +
                $"{AHSProvider.SelectQueryString(AHSProvider.seasons, AHSProvider.SeasonColumnsList)}";
            string connectionString = AHSProvider.ConnectionString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(q, conn))
                {
                    using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                    {
                        a.Fill(ds);
                    }

                }
            }
            DataTable castDt = ds.Tables[0];
            DataTable seasonDt = ds.Tables[1];
            DataTable seasonDt2 = ds.Tables[1];

            cmbCastList.DataSource = castDt;
            cmbCastList.DisplayMember = "Name";
            cmbCastList.ValueMember = "Id";
            cmbCastList.SelectedIndex = -1;

            cmbSeasonList1.DataSource = seasonDt;
            cmbSeasonList1.DisplayMember = "Name";
            cmbSeasonList1.ValueMember = "Id";
            cmbSeasonList1.SelectedIndex = -1;

            cmbSeasonList2.DataSource = seasonDt2;
            cmbSeasonList2.BindingContext = new BindingContext();
            cmbSeasonList2.DisplayMember = "Name";
            cmbSeasonList2.ValueMember = "Id";
            cmbSeasonList2.SelectedIndex = -1;

        }

        private void charAddBtn_click(object sender, EventArgs e)
        {
            object charName = UIHelper.TextBoxCheck(txtcharName.Text.ToString(), false, false);
            if(charName == null)
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
            object ep2 = UIHelper.TextBoxCheck(txtEp2.Text, true, false);
            if(!UIHelper.ComboBoxCheck(cmbSeasonList1.SelectedIndex, false))
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
            List<string> colsList = AHSProvider.charcolumns.Where(i => i != "Id").ToList();
            string sQuery = AHSProvider.SelectQueryString(AHSProvider.chars, colsList);
            if (UIHelper.AntiDoops(sQuery, new List<string> { charName.ToString() }))
            {
                UIHelper.UiCleaner(Controls);
                txtcharName.Focus();
            }

            string q = AHSProvider.InsertQueryString(AHSProvider.chars, colsList);
            string connectionString = AHSProvider.ConnectionString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(q, conn))
                {
                    cmd.Parameters.AddWithValue("@" + AHSProvider.charcolumns[1], charName);
                    cmd.Parameters.AddWithValue("@" + AHSProvider.charcolumns[2], cmbCastList.SelectedValue);
                    cmd.Parameters.AddWithValue("@" + AHSProvider.charcolumns[3], cmbSeasonList1.SelectedValue);
                    cmd.Parameters.AddWithValue("@" + AHSProvider.charcolumns[4], cmbSeasonList2.SelectedValue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@" + AHSProvider.charcolumns[5], ep1);

                    cmd.Parameters.AddWithValue("@" + AHSProvider.charcolumns[6], ep2);
                    cmd.ExecuteNonQuery();

                }
            }
            MessageBox.Show($"{txtcharName.Text.ToString()} Has successfully Been Added To the Database");
            UIHelper.UiCleaner(Controls);
            txtcharName.Focus();
        }
    }
}
