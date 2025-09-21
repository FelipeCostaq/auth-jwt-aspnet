using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthFinance.Models
{
    public class CompletedGoal
    {
        [Key]
        public int Id
        {
            get; set;
        }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TargetAmount
        {
            get; set;
        }

        [Required]
        public DateTime CompletedAt
        {
            get; set;
        }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; } = null!;
    }
}
