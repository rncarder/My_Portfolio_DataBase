using System.Data;

namespace AHSDb.Models
{
    public class Season : Model
    {
        public int Id { get; set; }
        public int SeasonNum { get; set; }
        public string Name { get; set; }

    }
}
