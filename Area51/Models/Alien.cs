using System.ComponentModel.DataAnnotations;

namespace Area51.Models
{
    public class Alien
    {
        public int ID { get; set; }

        public string NickName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateFound { get; set; }

        public float Height { get; set; }

        public float Weight { get; set; }

        public string colour { get; set; }

        public string description { get; set; }
    }
}
