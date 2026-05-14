using FrontToBackSqlConnection.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace FrontToBackSqlConnection.Models
{
    public class Category:BaseEntity
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Sehv yazdin")]
        public string? Name { get; set; }
        public List<Product>? Products { get; set; }
    }
}
