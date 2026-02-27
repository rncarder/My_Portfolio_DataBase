using System.Collections.Generic;
using AHSDb.Models;
using Microsoft.EntityFrameworkCore;

namespace AHSDataEntry
{
    public partial class Form1 : Form
    {
        public int combBoxSel;
        public System.Collections.Generic.List<Button> btns = new List<Button>();
        public bool isLoggedIn;
        public Form1()
        {
            InitializeComponent();
            btns.Add(SeasonBtn);
            btns.Add(epBtn);
            btns.Add(castBtn);
            btns.Add(CharBtn);
            checkLogin();
        }
        public void checkLogin()
        {
            foreach (Button b in btns)
            {
                if (!isLoggedIn)
                {
                    b.Visible = false;
                }
                else
                {
                    b.Visible = true;
                }
            }
            if (isLoggedIn)
            {
                loginBtn.Text = "logout";
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {

            if (!isLoggedIn)
            {
                LoginForm loginForm = new LoginForm(this);
                loginForm.Show();
            }
            else
            {
                isLoggedIn = false;
                loginBtn.Text = "login";
                checkLogin();
            }
        }

        private void seasonBtn_click(object sender, EventArgs e)
        {
            seasonForm seasonForm = new seasonForm();
            seasonForm.Show();
        }

        private void epBtn_click(object sender, EventArgs e)
        {
            EpisodeForm episodeForm = new EpisodeForm();
            episodeForm.Show();
        }

        private void castBtn_click(object sender, EventArgs e)
        {
            CastsForm castsForm = new CastsForm();
            castsForm.Show(); 
        }

        private void charBtn_click(object sender, EventArgs e)
        {
            CharacterForm characterForm = new CharacterForm();
            characterForm.Show();
        }

    }
}
