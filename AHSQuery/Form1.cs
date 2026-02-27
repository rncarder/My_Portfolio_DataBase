using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Xml;
using AHS.Core;
using AHS.Core.DTOs;
using AHSDb.Models;
using AHSDb;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;
using System.Linq.Expressions;

namespace AHSQuery
{
    public partial class Form1 : Form
    {
        AHSProvider provider = new AHSProvider();
        public Dictionary<string, List<object>> masterDict = new Dictionary<string, List<object>>();
        public Form1()
        {
            InitializeComponent();
            masterDict = provider.MakeDict();
            CmbTables.Items.AddRange(masterDict.Keys.ToArray());


        }
        private void Cmb_Select_Commit(object sender, EventArgs e)
        {
            string selected = CmbTables.SelectedItem.ToString();
            List<object> source = provider.searchList(searchBox.Text.ToString(), masterDict[selected]);
            dgv.DataSource = source;
            if (source.Count > 0)
            {
                dgv.Columns["Id"].Visible = false;
                dgv.Columns["Name"].DisplayIndex = 0;
            }
        }
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            //this.Invalidate();
            this.Update();
            masterDict.Clear();
        }



        
    }
}
