using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorAcademy.Models
{
    public class Discipline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(TypeName = "SMALLINT")]
        public short discipline_id { get; set; }

        [Required]
        public string discipline_name { get; set; } 

        [Required]
        public byte number_of_lessons { get; set; }
    }
}