namespace CaseTeamSec.Models
{
    public class Writer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public DateTime AddedDate { get; set; } = DateTime.Now;

    }
}
