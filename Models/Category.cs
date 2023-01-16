using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string CategoryName { get; set; }
        [Required]
        public int CategoryLimit { get; set; }
    }
}
