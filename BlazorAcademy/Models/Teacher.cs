using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAcademy.Models
{
    public class Teacher : Human
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int teacher_id { get; set; }

        [Required]
        public DateOnly work_since { get; set; }

        [Required]
        public decimal rate { get; set; }

        public int Experience { get => (int)((DateOnly.FromDateTime(DateTime.Now).DayNumber - work_since.DayNumber) / 365.25); }
    }
}