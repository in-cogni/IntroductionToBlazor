using System.ComponentModel.DataAnnotations;

namespace BlazorAcademy.Models
{
    public class TeacherSimple
    {
        [Key]
        public int teacher_id { get; set; }

        [Required]
        public string last_name { get; set; } = string.Empty;

        [Required]
        public string first_name { get; set; } = string.Empty;

        public string? middle_name { get; set; }

        [Required]
        public DateOnly birth_date { get; set; }

        public string? email { get; set; }

        public string? phone { get; set; }

        public byte[]? photo { get; set; }

        [Required]
        public DateOnly work_since { get; set; }

        [Required]
        public decimal rate { get; set; }

        public int Experience
        {
            get => (int)((DateOnly.FromDateTime(DateTime.Now).DayNumber - work_since.DayNumber) / 365.25);
        }

        public int Age
        {
            get => (int)((DateOnly.FromDateTime(DateTime.Now).DayNumber - birth_date.DayNumber) / 365.25);
        }
    }
}