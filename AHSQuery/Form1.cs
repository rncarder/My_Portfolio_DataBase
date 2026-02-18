using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Xml;
using AHS.Core;
using AHSDb.Models;
using AHSDb;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AHSQuery
{
    public partial class Form1 : Form
    {
        public DataSet dbds = new DataSet();
        public Form1()
        {
            InitializeComponent();
            
            FetchData();

            //CmbTables.Items.AddRange(AHSProvider.seasons, AHSProvider.eps, AHSProvider.casts, AHSProvider.chars);
            //the add Range function for some reason is not working so I have to add them one by one
            CmbTables.Items.Add(AHSProvider.seasons);
            CmbTables.Items.Add(AHSProvider.eps);
            CmbTables.Items.Add(AHSProvider.casts);
            CmbTables.Items.Add(AHSProvider.chars);
        }
        private void Cmb_Select_Commit(object sender, EventArgs e)
        {
            //MessageBox.Show("cmbChang");
            int index = CmbTables.SelectedIndex;
            if (index >= 0)
            {
                //if there is a search term  
                //this updates the griddataview to display filtered results
                if (!string.IsNullOrEmpty(searchBox.Text))
                {
                    //string search = searchBox.Text.ToString();
                    
                    string search = AHSProvider.ToUpperCase(searchBox.Text);
                    dgv.DataSource = searchDataSet(search).Tables[index];
                }
                //if no search term it shows all the data in each table
                else { dgv.DataSource = dbds.Tables[index]; }
                dgv.Columns[0].Visible = false;

            }
        }
        //if new data has been entered into the database user can click the "refresh Button"
        //to update the data accessed by this app
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            this.Invalidate();
            this.Update();
            dbds.Clear();
            FetchData();
        }
        //fetches data onload or onRefresh
        public void FetchData()
        {
            List<Season> seasons = new List<Season>();
            List<Episode> eps = new List<Episode>();
            List<Character> chars = new List<Character>();
            List<Cast> casts = new List<Cast>();
            try
            {
                using (AHSDbContext db = new AHSDbContext())
                {
                    seasons = db.Seasons.ToList();
                    eps = db.Episodes.ToList();
                    casts = db.Casts.ToList();
                    chars = db.Characters.ToList();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                dbds = CreateDs(seasons, eps, casts, chars);
            }
        }
        //creates a DataSet the DataGridView usees as data source
        //this method is used to create the intial DataSet that is later used to filter
        //search results for each Table. this way the server is only connected on load and refresh
        public DataSet CreateDs(List<Season> seasons, List<Episode> eps, List<Cast> casts, List<Character> chars)
        {
            //each block of code is creating a table out of the list in the parameters of the method
            //this ensures the view of the data stays consistant 
            DataSet ds = new DataSet();
            DataTable seasonsDT = new DataTable();
            seasonsDT.TableName = AHSProvider.seasons;
            string[] seasoncolumnsString = AHSProvider.SeasonColumnsList.ToArray();
            DataColumn[] seasonColumns = Array.ConvertAll(seasoncolumnsString, str => new DataColumn(str));
            seasonsDT.Columns.AddRange(seasonColumns);
            foreach (Season s in seasons)
            {
                seasonsDT.Rows.Add(s.Id, s.SeasonNum, s.Name);
            }

            DataTable epsDt = new DataTable();
            epsDt.TableName = AHSProvider.eps;
            string[] epsColumnString = AHSProvider.episodesColums.ToArray();
            DataColumn[] epsColumns = Array.ConvertAll(epsColumnString, str => new DataColumn(str));
            epsDt.Columns.AddRange(epsColumns);
            foreach (Episode ep in eps)
            {
                epsDt.Rows.Add(ep.Id, ep.Name, ep.Season.Name);
            }
            DataTable castDt = new DataTable();
            castDt.TableName = AHSProvider.casts;
            string[] castsColumnString = AHSProvider.castColumns.ToArray();
            DataColumn[] castColumns = Array.ConvertAll(castsColumnString, str => new DataColumn(str));
            castDt.Columns.AddRange(castColumns);
            foreach (Cast c in casts)
            {
                castDt.Rows.Add(c.Id, c.Name);
            }
            DataTable charDt = new DataTable();
            charDt.TableName = AHSProvider.chars;
            string[] charsColumnString = AHSProvider.charcolumns.ToArray();
            DataColumn[] charsColumns = Array.ConvertAll(charsColumnString, str => new DataColumn(str));
            charDt.Columns.AddRange(charsColumns);
            foreach (Character c in chars)
            {
                charDt.Rows.Add(c.Id,
                    c.Name,
                    c.Cast.Name,
                    c.Season1.Name,
                    c.NumOfEpisodes1,
                    c.Season2?.Name,
                    c.NumOfEpisodes2);
            }
            DataTable[] dtArray = { seasonsDT, epsDt, castDt, charDt };
            ds.Tables.AddRange(dtArray);
            return ds;
        }
        //filters each table from the dbds(original dataset) to a list of rows that
        //has a column matching the keyword providing the user with a more focused 
        //view of the season cast or character the are trying to view
        public DataSet searchDataSet(string searchstr)
        {
            List<Season> fSeasons = dbds.Tables[0].AsEnumerable().Where(Row => Row.Field<string>(AHSProvider.SeasonColumnsList[2]).Contains(searchstr))
            .Select(row => new Season
            {
                Id = Convert.ToInt32(row[AHSProvider.SeasonColumnsList[0]]),
                SeasonNum = Convert.ToInt32(row[AHSProvider.SeasonColumnsList[1]]),
                Name = row.Field<string>(AHSProvider.SeasonColumnsList[2])
            }).ToList();
            List<Episode> fEps = dbds.Tables[1].AsEnumerable().Where(Row => Row.Field<string>("Name").Contains(searchstr) || Row.Field<string>("Season").Contains(searchstr))
                .Select(row => new Episode
                {
                    Id = Convert.ToInt32(row[AHSProvider.episodesColums[0]]),
                    Name = row.Field<string>(AHSProvider.episodesColums[1]),
                    Season = new Season
                    {
                        Name = row.Field<string>(AHSProvider.episodesColums[2])
                    }
                }).ToList();
            List<Cast> fCasts = dbds.Tables[2].AsEnumerable().Where(Row => Row.Field<string>("Name").Contains(searchstr))
                .Select(row => new Cast
                {
                    Id = Convert.ToInt32(row[AHSProvider.castColumns[0]]),
                    Name = row.Field<string>(AHSProvider.castColumns[1])
                }).ToList();
            
            List<Character> fchars = dbds.Tables[3].AsEnumerable().Where(Row => 
            (Row.Field<string>("Name")?.Contains(searchstr) ?? false) ||
             (Row.Field<string>("Cast")?.Contains(searchstr) ?? false) ||
             (Row.Field<string>("Season1")?.Contains(searchstr) ?? false) || 
             (Row.Field<string>("Season2")?.Contains(searchstr) ?? false))
                .Select(row => new Character
                {
                    Id = Convert.ToInt32(row[AHSProvider.charcolumns[0]]),
                    Name = row.Field<string>(AHSProvider.charcolumns[1]),
                    Cast = new Cast
                    {
                        Name = row.Field<string>(AHSProvider.charcolumns[2])
                    },
                    Season1 = new Season
                    {
                        Name = row.Field<string>(AHSProvider.charcolumns[3])
                    },
                    NumOfEpisodes1 = Convert.ToInt32(row[AHSProvider.charcolumns[4]]),
                    Season2 = row[AHSProvider.charcolumns[5]] == DBNull.Value ? null : 
                    new Season
                    {
                        Name = row.Field<string>(AHSProvider.charcolumns[5])
                    },
                    NumOfEpisodes2 = row[AHSProvider.charcolumns[6]] == DBNull.Value
                    ? 0 : Convert.ToInt32(row[AHSProvider.charcolumns[6]])


                }).ToList();
            return CreateDs(fSeasons, fEps, fCasts, fchars);
        }
    }
}
