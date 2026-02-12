using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
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
    public partial class CharacterUpdatForm : Form
    {
        public CharacterUpdatForm()
        {
            InitializeComponent();
            var charList = AHSProvider.charcolumns.Where(c => c != "Id").ToList();

            string q = $"{AHSProvider.SelectQueryString(AHSProvider.chars, charList)} " +
                $"{AHSProvider.SelectQueryString(AHSProvider.casts, AHSProvider.castColumns)} " +
                $"{AHSProvider.SelectQueryString(AHSProvider.seasons, AHSProvider.SeasonColumnsList)}";
            string connectionString = AHSProvider.ConnectionString();
            DataTable charTable = new DataTable();
            DataTable castTable = new DataTable();
            DataTable seasonTable = new DataTable();
            DataSet ds = new DataSet();
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
                charTable = ds.Tables[0];
                castTable = ds.Tables[1];
                seasonTable = ds.Tables[2];

                cmbCharNameSelect.DisplayMember = "Name";
                cmbCharNameSelect.ValueMember = "Id";
                cmbCharNameSelect.DataSource = charTable;
                cmbCharNameSelect.SelectedIndex = -1;



                cmbCastEdit.DisplayMember = "Name";
                cmbCastEdit.ValueMember = "Id";
                cmbCastEdit.DataSource = castTable;
                cmbCastEdit.SelectedIndex = -1;


                cmbSeason1Edit.DisplayMember = "Name";
                cmbSeason1Edit.ValueMember = "Id";
                cmbSeason1Edit.DataSource = seasonTable;
                cmbSeason1Edit.SelectedIndex = -1;

                cmbSeason2Edit.DisplayMember = "Name";
                cmbSeason2Edit.ValueMember = "Id";
                cmbSeason2Edit.DataSource = seasonTable;
                cmbSeason2Edit.SelectedIndex = -1;

                cmbRemoveChar.DisplayMember = "Name";
                cmbRemoveChar.ValueMember = "Id";
                cmbRemoveChar.DataSource = charTable;
                cmbRemoveChar.SelectedIndex = -1;

            }
        }


        private void charEditBtn_click(object sender, EventArgs e)
        {
            string connectionstring = AHSProvider.ConnectionString();
            string q = AHSProvider.SelectQueryString("Characters", AHSProvider.charcolumns.Where(c => c != "Id").ToList());
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(q, conn))
                {
                    using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                    {
                        a.Fill(dt);
                    }
                }
            }
            DataRowView dr = cmbCharNameSelect.SelectedItem as DataRowView;
            if (dr != null)
            {
                cmbCastEdit.SelectedValue = dr["CastId"];
                cmbSeason1Edit.SelectedValue = dr["Season1Id"];
                cmbSeason2Edit.SelectedValue = dr["Season2Id"];
                txtCharNameEdit.Text = dr["Name"].ToString();
                txtEp1Edit.Text = dr["NumOfEpisodes1"].ToString();
                txtEp2Edit.Text = dr["NumOfEpisodes2"].ToString();

            }
        }

        private void removeCharBtn_click(object sender, EventArgs e)
        {

        }
    }
}
