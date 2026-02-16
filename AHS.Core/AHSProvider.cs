using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHSDb;
using AHSDb.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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

        public static List<Season> seasonbuffer = new List<Season>();
        public static List<Episode> episodeBuffer = new List<Episode>();
        public static List<Cast> castBuffer = new List<Cast>();
        public static List<Character> charBuffer = new List<Character>();

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
        public static bool addToBuffer(Model mod)
        {

 
            if (mod is Character)
            {
                if (charBuffer.Any(c => c.Name == ((Character)mod).Name))
                {
                    return false;
                }

                charBuffer.Add((Character)mod);
                return true;
            }
            else if (mod is Cast)
            {
                if (castBuffer.Any(c => c.Name == ((Cast)mod).Name))
                {
                    return false;
                }

                castBuffer.Add((Cast)mod);
                return true;
            }
            else if (mod is Episode)
            {
                if (episodeBuffer.Any(e => e.Name == ((Episode)mod).Name))
                {
                    //MessageBox.Show("Episode with the same name already exists in the buffer. Please change the episode name.");
                    return false;
                }
                episodeBuffer.Add((Episode)mod);
                return true;
            }
            else if (mod is Season)
            {
                if (seasonbuffer.Any(s => s.SeasonNum == ((Season)mod).SeasonNum || s.Name == ((Season)mod).Name))
                {
                    //MessageBox.Show("Season with the same name or season number already exists in the buffer. Please change the season number or name.");
                    return false;
                }
                seasonbuffer.Add((Season)mod);
                return true;
            }
            return false;
        }


    }
}
