using CaseTeamSec.Models;
using System.Collections.Generic;
using System.Linq;

namespace CaseTeamSec.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly List<Comment> _comments = new List<Comment>();

        public IEnumerable<Comment> GetAll()
        {
            return _comments;
        }

        public Comment? GetById(int id)
        {
            return _comments.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Comment comment)
        {
            
            comment.Id = _comments.Any() ? _comments.Max(c => c.Id) + 1 : 1;
            _comments.Add(comment);
        }

        public void Update(Comment comment)
        {
            var existingComment = GetById(comment.Id);
            if (existingComment != null)
            {
                int index = _comments.IndexOf(existingComment);
                _comments[index] = comment;
            }
        }

        public void Delete(int id)
        {
            var comment = GetById(id);
            if (comment != null)
            {
                _comments.Remove(comment);
            }
        }

        public void DeleteByArticle(int articleId)
        {
            _comments.RemoveAll(comment => comment.ArticleId == articleId);
        }


        public void DeleteByWriter(int writerId)
        {
            _comments.RemoveAll(comment => comment.WriterId == writerId);
        }

    }
}
