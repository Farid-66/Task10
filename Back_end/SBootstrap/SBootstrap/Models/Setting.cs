using System.ComponentModel.DataAnnotations;

namespace SBootstrap.Models
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(150)]
        public string Substring { get; set; }
    }
}
