namespace WebApplication12.Models
{
    public class Message
    {
        public int Id { get; set; } = DB.allMessages.Count + 1;
        public string Text { get; set; }
        public DateTime DataCreate { get; set; } = DateTime.Now;

    }
}
