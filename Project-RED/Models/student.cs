using Project_RED.Models;

namespace project_red.Models
{
    public class student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GradeLevel { get; set; }
        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
