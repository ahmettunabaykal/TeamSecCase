using CaseTeamSec.Models;
using System.Collections.Generic;

namespace CaseTeamSec.Repositories
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetAll();
        Comment? GetById(int id);
        void Add(Comment comment);
        void Update(Comment comment);
        void Delete(int id);

        void DeleteByArticle(int articleId); 
    }
}
