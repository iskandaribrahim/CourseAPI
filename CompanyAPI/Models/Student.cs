namespace CompanyAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }
        public Course Course { get; set; }

    }
}
