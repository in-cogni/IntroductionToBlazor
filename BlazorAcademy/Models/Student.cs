using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAcademy.Models
{
    public class Student:Human
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int stud_id {  get; set; }
        //[Required]
        //public string? last_name { get; set; }
        //[Required]
        //public string? first_name { get; set; }
        //public string? middle_name { get; set; }
        //public DateTime birth_date { get; set; }
        //[EmailAddress]
        //public string? email { get; set; }
        //[Phone]
        //public string? phone { get; set; }
        //public byte[]? photo { get; set; }
        //[Required]
        //public int group {  get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int stud_id { get; set; }
        [Required]
        public int group {  get; set; }
    }
}
