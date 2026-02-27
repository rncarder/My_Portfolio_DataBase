using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHS.Core.DTOs;
using AHSDb;
using AHSDb.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace AHS.Core
{
    public class AHSProvider
    {
        public AHSDbContext context = new AHSDbContext();

        public static List<Season> seasonbuffer = new List<Season>();
        public static List<Episode> episodeBuffer = new List<Episode>();
        public static List<Cast> castBuffer = new List<Cast>();
        public static List<Character> charBuffer = new List<Character>();

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
        public string ToUpperCase(string entry)
        {
            if (entry.Length > 0)
            {
                char e = entry[0];
                char end = entry[entry.Length - 1];
                if (char.IsWhiteSpace(e))
                {
                    string newEntry = entry.Remove(0, 1);
                    return ToUpperCase(newEntry);
                }
                if (char.IsWhiteSpace(end))
                {
                    string newEntry = entry.Remove(entry.Length - 1);
                    return ToUpperCase(newEntry);
                }
            }
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(entry);
            
        }
        public Dictionary<string, List<object>> MakeDict()
        {
            Dictionary<string, List<object>> dict = new Dictionary<string, List<object>>();
            List<DTOs.SeasonReadDto> seasons = context.Seasons.AsNoTracking().Select(s => new DTOs.SeasonReadDto
            {
                Id = s.Id,
                Name = s.Name,
                SeasonNum = s.SeasonNum,

            }).ToList();
            List<DTOs.EpisodeReadDto> eps = context.Episodes.AsNoTracking().
                Select(e => new DTOs.EpisodeReadDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    seasonName = e.Season.Name
                }).ToList();
            List<DTOs.CastReadDto> casts = context.Casts.AsNoTracking().Select(c => new CastReadDto
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            List<DTOs.CharacterReadDto> chars = context.Characters.AsNoTracking().Select(c => new CharacterReadDto
            {
                Id = c.Id,
                Name = c.Name,
                CastMember = c.Cast.Name,
                Season1Name = c.Season1.Name,
                numOfEps1 = c.NumOfEpisodes1,
                Season2Name = c.Season2 == null ? "N/A" : c.Season2.Name,
                numOfEps2 = c.NumOfEpisodes2 ?? 0

            }).ToList();
            /*

            Console.WriteLine(dict.Values.ToString);
            */
            dict.Add("Seasons", seasons.Cast<object>().ToList());
            dict.Add("Episodes", eps.Cast<object>().ToList());
            dict.Add("Casts", casts.Cast<object>().ToList());
            dict.Add("Characters", chars.Cast<object>().ToList());
            return dict;
        }
        public List<object> searchList(string keyword, List<object> sourcelist)
        {
            if (string.IsNullOrEmpty(keyword)) { return sourcelist; }
            List<object> filteredList = new List<object>();
            foreach(var item in sourcelist)
            {
                var props = item.GetType().GetProperties();
                bool ismatch = false;
                foreach(var p in props)
                {
                    if(p.PropertyType == typeof(string))
                    {
                        string val = p.GetValue(item)?.ToString() ?? "";
                        if (val.Contains(keyword))
                        {
                            ismatch = true;
                            break;
                        }
                    }
                }
                if (ismatch) { filteredList.Add(item); }
            }
            return filteredList;
        }

    }
}
