using System;
using System.Collections.Generic;

namespace CaseTeamSec.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.Now;
        public int WriterId { get; set; }
        
        public int CategoryId { get; set; }
        public List<string> Category { get; set; } = new List<string>();
        
        public List<string> Tags { get; set; } = new List<string>();
        public int Likes { get; set; } = 0;
        public double Rating { get; set; } = 0.0;
        public int NumberOfRatings { get; set; } = 0;
    }
}
