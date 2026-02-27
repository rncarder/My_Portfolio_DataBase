using System.ComponentModel.DataAnnotations.Schema;

namespace AHSDb.Models
{
    public class Episode : Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Season Season { get; set; }
    }
}
