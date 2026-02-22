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
using System.Reflection;

namespace AHSQuery
{
    public partial class Form1 : Form
    {
        public List<Season> seasons = new List<Season>();
        public List<Episode> eps = new List<Episode>();
        public List<Character> chars = new List<Character>();
        public List<Cast> casts = new List<Cast>();
        public Dictionary<string, DataTable> masterDict = new Dictionary<string, DataTable>();
        public Form1()
        {
            InitializeComponent();

            FetchData();
            CmbTables.Items.AddRange(masterDict.Keys.ToArray());


        }
        private void Cmb_Select_Commit(object sender, EventArgs e)
        {
            string selected = CmbTables.SelectedItem.ToString();
            if (string.IsNullOrEmpty(searchBox.Text))
            {
                dgv.DataSource = masterDict[selected];
            }
            else { dgv.DataSource = searchDict(searchBox.Text.ToString())[selected]; }
            dgv.Columns["Id"].Visible = false;
        }
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            //this.Invalidate();
            this.Update();
            masterDict.Clear();
            FetchData();
        }
        public void FetchData()
        {
            //since this is a small database i figure best to load all data at once to reduce trips to server
            try
            {
                using (AHSDbContext db = new AHSDbContext())
                {
                    seasons = db.Seasons.ToList();
                    eps = db.Episodes.ToList();
                    casts = db.Casts.ToList();
                    chars = db.Characters.ToList();
                }
                Assembly ex = Assembly.GetExecutingAssembly();
                masterDict.Add("Seasons", createDT(seasons));
                masterDict.Add("Episodes", createDT(eps));
                masterDict.Add("Casts", createDT(casts));
                masterDict.Add("Characters", createDT(chars));
                Type[] types = ex.GetTypes();
                foreach (Type type in types)
                {
                    Console.WriteLine("Class {0}", type.Name);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
            }
        }
        public DataTable createDT(IEnumerable<AHSDb.Model> modList)
        {
            List<AHSDb.Model> mods = modList.ToList();

            if (modList is List<Season>)
            {
                DataTable seasonsDT = new DataTable();
                seasonsDT.Columns.Add("Id", typeof(int));
                seasonsDT.Columns.Add("SeasonNum", typeof(int));
                seasonsDT.Columns.Add("Name", typeof(string));
                foreach (Season s in modList)
                {
                    seasonsDT.Rows.Add(s.Id, s.SeasonNum, s.Name);
                }
                return seasonsDT;
            }
            else if (modList is List<Episode>)
            {
                DataTable epsDt = new DataTable();
                epsDt.TableName = AHSProvider.eps;
                epsDt.Columns.Add("Id", typeof(int));
                epsDt.Columns.Add("Name", typeof(string));
                epsDt.Columns.Add("Season", typeof(string));
                foreach (Episode ep in modList)
                {
                    epsDt.Rows.Add(ep.Id, ep.Name, ep.Season.Name);
                }
                return epsDt;
            }
            else if (modList is List<Cast>)
            {
                DataTable castDt = new DataTable();
                castDt.TableName = AHSProvider.casts;
                castDt.Columns.Add("Id", typeof(int));
                castDt.Columns.Add("Name", typeof(string));
                foreach (Cast c in modList)
                {
                    castDt.Rows.Add(c.Id, c.Name);
                }
                return castDt;
            }
            else
            {
                DataTable charDt = new DataTable();
                charDt.Columns.Add("Id", typeof(int));
                charDt.Columns.Add("Name", typeof(string));
                charDt.Columns.Add("Cast", typeof(string));
                charDt.Columns.Add("Season1", typeof(string));
                charDt.Columns.Add("NumOfEps1", typeof(int));
                charDt.Columns.Add("Season2", typeof(string));
                charDt.Columns.Add("NumOfEps2", typeof(int));
                foreach (Character c in modList)
                {
                    charDt.Rows.Add(c.Id,
                        c.Name,
                        c.Cast.Name,
                        c.Season1.Name,
                        c.NumOfEpisodes1,
                        c.Season2?.Name,
                        c.NumOfEpisodes2);
                }
                return charDt;
            }

        }

        public Dictionary<string, DataTable> searchDict(string keyword)
        {
            Dictionary<string, DataTable> sDict = new Dictionary<string, DataTable>();
            List<Season> mSeasons = seasons.Where(s => s.Name.Contains(keyword)).ToList();
            List<Episode> mEps = eps.Where(e => e.Name.Contains(keyword) || e.Season.Name.Contains(keyword)).ToList();
            List<Cast> mCasts = casts.Where(c => c.Name.ToString().Contains(keyword)).ToList();
            List<Character> mChars = chars.Where(c => c.Name.Contains(keyword)
            || c.Cast.Name.ToString().Contains(keyword)
            || c.Season1.Name.Contains(keyword)
            || (c.Season2 == null ? false : c.Season2.Name.Contains(keyword))).ToList();
            //sDict.Add("Seasons", createDT(mSeasons));
            //sDict.Add("Episodes", createDT(mEps));
            //sDict.Add("Casts", createDT(mCasts));
            //sDict.Add("Characters", createDT(mChars));
            return sDict;
        }
        
    }
}
