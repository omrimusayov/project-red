namespace project_red.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}