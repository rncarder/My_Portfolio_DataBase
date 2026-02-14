using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHS.Core
{
    public static class AHSProvider
    {
        public static string seasons = "Seasons";
        public static String eps = "Episodes";
        public static string casts = "Casts";
        public static string chars = "Characters";
        public static List<string> SeasonColumnsList = new List<string>() { "Id", "SeasonNum", "Name" };
        public static List<string> episodesColums = new List<string>() { "Id", "Name", "SeasonId" };
        public static List<string> charcolumns = new List<string>() { "Id", "Name", "CastId", "Season1Id", "Season2Id", "NumOfEpisodes1", "NumOfEpisodes2" };
        public static List<string> castColumns = new List<string>() { "Id", "Name" };

        public static List<_season> seasonbuffer = new List<_season>();

        //internal static List<_season> SeasonsToBeAdded { get => seasonsToBeAdded; set => seasonsToBeAdded = value; }

        public static string ConnectionString()
        {
            return @"Data Source=(localdb)\MSSQLLocalDB;Database=AHSDatabase;Integrated Security=True;TrustServerCertificate=True";
        }
        public static string InsertQueryString(string table, List<string> columns)
        {
            string columnsList = string.Join(", ", columns);
            string placeHolders = string.Join(", @", columns);

            string q = $"INSERT INTO {table} ({columnsList}) VALUES (@{placeHolders})";
            return q;

        }
        public static string SelectQueryString(string table, List<string> columns)
        {
            string columnlist = string.Join(",", columns);
            return $"SELECT {columnlist} From {table}";
        }



    }
}
