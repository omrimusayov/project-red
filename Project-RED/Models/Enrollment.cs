namespace project_red.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string Semester { get; set; }
    }
}