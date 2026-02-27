using System.ComponentModel.DataAnnotations.Schema;

namespace AHSDb.Models
{
    public class Character : Model
    {
        public int Id {  get; set; }

        public string Name { get; set; }
        public Cast Cast { get; set; }
        [NotMapped]
        public string CastName { get; set; }
        public Season Season1 { get; set; }
        [NotMapped]
        public String Season1Name { get; set; }
        public int NumOfEpisodes1 { get; set; }
        public Season? Season2 { get; set; }

        [NotMapped]
        public String? Season2Name { get;set; }
        public int? NumOfEpisodes2 { get; set; }


    }
}
