using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AHS.Core;
using Microsoft.Data.SqlClient;

namespace AHSDataEntry
{
    public partial class CastsForm : Form
    {
        public CastsForm()
        {
            InitializeComponent();
        }

        private void addCastBtn_click(object sender, EventArgs e)
        {
            String connectionstring = AHSProvider.ConnectionString();
            List<string> colList = AHSProvider.castColumns.Where(c => c != "Id").ToList();
            string q = AHSProvider.InsertQueryString(AHSProvider.casts, colList);
            string SQuery = AHSProvider.SelectQueryString(AHSProvider.casts, colList);
            if (UIHelper.AntiDoops(SQuery, colList))
            {
                UIHelper.UiCleaner(Controls);
                txtCastName.Focus();
                return;
            }
            object txt = UIHelper.TextBoxCheck(txtCastName.Text.ToString(), false, false);
            if(txt == null)
            {
                MessageBox.Show("Please enter a Name into the text box");
                UIHelper.UiCleaner(Controls);
                txtCastName.Focus();
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(q, conn))
                {
                    cmd.Parameters.AddWithValue("@" + AHSProvider.castColumns[1], txtCastName.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show($"{txtCastName.Text} was added to the Casts table");

            UIHelper.UiCleaner(this.Controls);
            txtCastName.Focus();


        }

    }
}
