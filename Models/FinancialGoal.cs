using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthFinance.Models
{
    public class FinancialGoal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(1, double.MaxValue, ErrorMessage = "O valor deve ser maior ou igual a 1")]
        public decimal TargetAmount { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue)]
        public decimal CurrentAmount { get; set; } = 0;

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User? Owner { get; set; }
    }
}
