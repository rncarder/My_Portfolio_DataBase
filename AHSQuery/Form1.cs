using System.Data;
using AHS.Core;
using AHS.Core.Interfaces;

namespace AHSQuery
{
    public partial class Form1 : Form
    {
        AHSProvider provider;
        public Form1()
        {
            InitializeComponent();
            provider = new AHSProvider();
            CmbTables.Items.AddRange(provider.GetKeys());

        }
        private void Cmb_Select_Commit(object sender, EventArgs e)
        {
            if (CmbTables.SelectedItem != null)
            {
                string selected = CmbTables.SelectedItem.ToString();
                List<ISearchable> sourcelist = provider.Getlist(selected);
                List<dynamic> searchedList = provider.searchList(searchBox.Text.ToString(), sourcelist).Cast<dynamic>().ToList();
                dgv.DataSource = searchedList;
            }
            
        }
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            this.Update();
            provider = new AHSProvider();
        }



        
    }
}
