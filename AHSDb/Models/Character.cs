namespace AHSDb.Models
{
    public class Character
    {
        public int Id {  get; set; }

        public string Name { get; set; }
        public Cast Cast { get; set; }
        public Season Season1 { get; set; }
        public Season? Season2 { get; set; }
        public int NumOfEpisodes1 { get; set; }

        public int? NumOfEpisodes2 { get; set; }

    }
}
