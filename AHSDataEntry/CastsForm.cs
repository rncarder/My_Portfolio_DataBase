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
using AHSDb.Models;
namespace AHSDataEntry
{
    public partial class CastsForm : Form
    {
        public CastsForm()
        {
            InitializeComponent();
            if (AHSProvider.castBuffer.Count > 0) { UpdateDash(); }
        }
        public void UpdateDash()
        {
            CastDashBoard.DataSource = null;
            CastDashBoard.DataSource = AHSProvider.castBuffer;
            CastDashBoard.Columns["Id"].Visible = false;
        }
        private void addCastBtn_click(object sender, EventArgs e)
        {
            object txt = UIHelper.TextBoxCheck(txtCastName.Text.ToString(), false, false);
            if (txt == null)
            {
                lblCastName.BackColor = Color.Red;
                txtCastName.Focus();
                return;
            }
            Cast cast = new Cast() { Name = txt.ToString() };
            if (!AHSProvider.addToBuffer(cast))
            {
                MessageBox.Show($"{cast.Name} is already in buffer");
                UIHelper.UiCleaner(Controls, DefaultBackColor);
                txtCastName.Focus();
                return;
            }
            UpdateDash();
            UIHelper.UiCleaner(this.Controls, DefaultBackColor);
            txtCastName.Focus();


        }

        private async void commitCastBtn_Click(object sender, EventArgs e)
        {
            if (AHSProvider.castBuffer.Count <= 0)
            {
                MessageBox.Show("There are no casts to be added. Please add casts before committing.");
                return;
            }
            try
            {
                using (AHSDbContext db = new AHSDbContext())
                {
                    List<Cast> bufferCheck = AHSProvider.castBuffer.Where(c => !db.Casts.Any(dbCast => dbCast.Name == c.Name)).ToList();
                    if (bufferCheck.Count <= 0)
                    {
                        MessageBox.Show("All casts from buffer is already in database");
                    }
                    foreach (Cast cast in bufferCheck)
                    {
                        await db.AddAsync(cast);
                    }
                    await db.SaveChangesAsync();
                    MessageBox.Show("casts added successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                AHSProvider.castBuffer.Clear();
                if (!this.IsDisposed)
                {
                    UIHelper.UiCleaner(Controls, DefaultBackColor);
                    txtCastName.Focus();
                }
            }
        }

        private void CastDashBoard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            txtCastName.Text = AHSProvider.castBuffer[index].Name.ToString();
            AHSProvider.castBuffer.RemoveAt(index);
            UpdateDash();
        }
    }
}
