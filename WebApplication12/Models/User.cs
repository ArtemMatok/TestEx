namespace WebApplication12.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Message Message { get; set; }
        public DateTime DataCreate { get; set; }
        public List<Message> Messages { get; set; }
    }
}
