using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
    public class AcademyModels
    {
        public int Id { get; set; }
        [Column("discipline_name")]
        public string? Discipline_name { get; set; }
        [Column("number_of_lessons")]
        public int Number_of_lessons {  get; set; }
    }
}
