namespace CaseTeamSec.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty; 
        public DateTime AddedDate { get; set; } = DateTime.Now;

        public int ArticleId { get; set; }

        public int WriterId { get; set; } 
    }
}
