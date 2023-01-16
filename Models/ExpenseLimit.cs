using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    public class ExpenseLimit
    {
        [Key]
        [Required]
        public int LimitID { get; set; }
        [Required]
        public int Expense_Limit { get; set; }
    }
}
