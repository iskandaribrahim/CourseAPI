using System.ComponentModel.DataAnnotations;

namespace CompanyAPI.RequestModels
{
    public class StudentRequestModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public double Grade { get; set; }
        [Required]
        public int CourseId { get; set; }

    }
}
