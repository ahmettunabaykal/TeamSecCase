
namespace CaseTeamSec.Models
{
    public class Tag
    {
        public int Id { get; set; }
    public string Name { get; set; } = string.Empty; 
        public List<Article> Articles { get; set; } = new List<Article>();
    }
}