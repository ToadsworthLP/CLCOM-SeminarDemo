using System.ComponentModel.DataAnnotations;

namespace CLCOM_SeminarRestApi.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(128)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(8)]
        public string Program { get; set; }

    }
}
