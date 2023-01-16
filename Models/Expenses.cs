using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    public class Expenses
    {
        [Key]
        [Required]
        public int ExpenseId { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        [Required]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public string Category { get; set; }
        [DisplayFormat(DataFormatString = "{0:MMM-dd-yy}")]
        public DateTime Date { get; set; }
    }
}
