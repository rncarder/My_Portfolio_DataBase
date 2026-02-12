using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Xml;
using AHS.Core;

namespace AHSQuery
{
    public partial class Form1 : Form
    {
        public DataSet ds = new DataSet();
        public Form1()
        {
            InitializeComponent();
            FetchData();
            SetDataRelations();
            CmbTables.Items.AddRange(AHSProvider.seasons, AHSProvider.eps, AHSProvider.casts, AHSProvider.chars);
        }


        public void SetDataRelations()
        {
            DataRelation castRel = new DataRelation("CharCast",
                ds.Tables[AHSProvider.casts].Columns[AHSProvider.castColumns[0]],
                ds.Tables[AHSProvider.chars].Columns[AHSProvider.charcolumns[2]]);
            ds.Relations.Add(castRel);
            ds.Tables[AHSProvider.chars].Columns.Add("Cast", typeof(string), "Parent(CharCast).name");

            DataRelation SeasonRel = new DataRelation("CharSeason",
                ds.Tables[AHSProvider.seasons].Columns[AHSProvider.SeasonColumnsList[0]],
                ds.Tables[AHSProvider.chars].Columns[AHSProvider.charcolumns[3]]);
            ds.Relations.Add(SeasonRel);
            ds.Tables[AHSProvider.chars].Columns.Add("Season1", typeof(string), "Parent(CharSeason).name");

            DataRelation season2Rel = new DataRelation("CharSeason2",
                ds.Tables[AHSProvider.seasons].Columns[AHSProvider.SeasonColumnsList[0]],
                ds.Tables[AHSProvider.chars].Columns[AHSProvider.charcolumns[4]]);
            ds.Relations.Add(season2Rel);
            ds.Tables[AHSProvider.chars].Columns.Add("Season2", typeof(string), "Parent(CharSeason2).name");

            DataRelation epSeasonRel = new DataRelation("epSeason",
                ds.Tables[AHSProvider.seasons].Columns[AHSProvider.SeasonColumnsList[0]],
                ds.Tables[AHSProvider.eps].Columns[AHSProvider.episodesColums[2]]);
            ds.Relations.Add(epSeasonRel);
            ds.Tables[AHSProvider.eps].Columns.Add("Season", typeof(string), "Parent(epSeason).name");


        }

        private void Cmb_Select_Commit(object sender, EventArgs e)
        {
            //MessageBox.Show("cmbChang");
            int index = CmbTables.SelectedIndex;
            if (index >= 0)
            {
                dgv.DataSource = ds.Tables[index];
                if (index == 0)
                {
                    dgv.Columns[AHSProvider.SeasonColumnsList[0]].Visible = false;
                    dgv.Columns[AHSProvider.SeasonColumnsList[1]].DisplayIndex = 0;
                    dgv.Columns[AHSProvider.SeasonColumnsList[2]].DisplayIndex = 1;


                }
                else if (index == 1)
                {
                    dgv.Columns[AHSProvider.episodesColums[0]].Visible = false;
                    dgv.Columns[AHSProvider.episodesColums[1]].DisplayIndex = 0;
                    dgv.Columns[AHSProvider.episodesColums[2]].DisplayIndex = 1;
                }
                else if (index == 2)
                {
                    dgv.Columns[AHSProvider.castColumns[0]].Visible = false;
                    dgv.Columns[AHSProvider.castColumns[1]].DisplayIndex = 0;
                }
                else if (index == 3)
                {
                    dgv.Columns[AHSProvider.charcolumns[0]].Visible = false;//id
                    dgv.Columns[AHSProvider.charcolumns[2]].Visible = false;//castid
                    dgv.Columns[AHSProvider.charcolumns[3]].Visible = false;//season1 id
                    dgv.Columns[AHSProvider.charcolumns[4]].Visible = false;//season2 id

                    dgv.Columns[AHSProvider.charcolumns[1]].DisplayIndex = 0;//name
                    dgv.Columns["Cast"].DisplayIndex = 1;//cast name
                    dgv.Columns["Season1"].DisplayIndex = 2;//season1 name
                    dgv.Columns[AHSProvider.charcolumns[5]].DisplayIndex = 3;//season1numofeps
                    dgv.Columns["Season2"].DisplayIndex = 4;//season2 name
                    dgv.Columns[AHSProvider.charcolumns[6]].DisplayIndex = 5;//season2
                }
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            this.Invalidate();
            this.Update();
            ds.Clear();
            FetchData();
        }
        public void FetchData()
        {
            string connectionString = AHSProvider.ConnectionString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlDataAdapter a = new SqlDataAdapter("", conn))
                    {
                        // 1. Fill Seasons explicitly
                        a.SelectCommand.CommandText = AHSProvider.SelectQueryString("Seasons", AHSProvider.SeasonColumnsList);
                        a.Fill(ds, "Seasons");

                        // 2. Fill Episodes explicitly
                        a.SelectCommand.CommandText = AHSProvider.SelectQueryString("Episodes", AHSProvider.episodesColums);
                        a.Fill(ds, "Episodes");

                        // 3. Fill Casts explicitly
                        a.SelectCommand.CommandText = AHSProvider.SelectQueryString("Casts", AHSProvider.castColumns);
                        a.Fill(ds, "Casts");

                        // 4. Fill Characters explicitly
                        a.SelectCommand.CommandText = AHSProvider.SelectQueryString("Characters", AHSProvider.charcolumns);
                        a.Fill(ds, "Characters");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
