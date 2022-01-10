using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBootstrap.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(450)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
