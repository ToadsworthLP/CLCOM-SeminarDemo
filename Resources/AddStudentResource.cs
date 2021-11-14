using System.ComponentModel.DataAnnotations;

namespace CLCOM_SeminarRestApi.Resources
{
    public class AddStudentResource
    {
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
