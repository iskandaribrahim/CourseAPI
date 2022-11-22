using Microsoft.Build.Framework;

namespace CompanyAPI.RequestModels
{
    public class CourseRequestModel
    {
        [Required]
        public string Name { get; set; }

    }
}
