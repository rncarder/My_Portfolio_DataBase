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
    public partial class LoginForm : Form
    {
        public Form1 form;
        public LoginForm()
        {
            InitializeComponent();

        }
        public LoginForm(Form1 form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void loginEnterBtn_click(object sender, EventArgs e)
        {
            //i opted to use a ui layer of authentication to provide a frictionless demonstration
            if (txtUserName.Text == "editor" &&  txtPassword.Text == "admin")
            {
                form.isLoggedIn = true;
                form.checkLogin();
                this.Close();
            }
            /*
             * 
             * the code below is there to show i can implement security authorization logic using
             * server side permissions by making a connection string with the provided credintials 
             * if the credintials is accepeted then the ui on the first form will become available
             * if the connection fails it means the credintials were invalid and the ui on the first form will not become
             * available ensuring no one without permission can manipulate the database in any way..
             * 
             * 
            string connString = $"server=(localdb)\\MSSQLLocalDB;Database=AHSDataBase;User Id={txtUserName.Text};Password={txtPassword.Text}";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    form.isLoggedIn = true;
                    form.checkLogin();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            */
        }
    }
}
