namespace project_red.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }

        public ICollection<student> Students { get; set; } = new List<student>();
    }
}