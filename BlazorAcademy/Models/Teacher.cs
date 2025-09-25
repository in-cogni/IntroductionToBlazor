using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace BlazorAcademy.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short teacher_id { get; set; }
        [StringLength(50)]
        public string? last_name { get; set; }
        [StringLength(50)]
        public string? first_name { get; set; }
        [StringLength(50)]
        public string? middle_name { get; set; }
        public DateTime birth_date { get; set; }
        [EmailAddress]
        [StringLength(50)]
        public string? email { get; set; }
        [Phone]
        [StringLength(16)]
        public string? phone { get; set; }
        public byte[]? photo { get; set; }
        public DateTime work_since { get; set; }
        public decimal rate { get; set; }
    }
}
