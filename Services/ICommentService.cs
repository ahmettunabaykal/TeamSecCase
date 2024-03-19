using CaseTeamSec.Models;
using System.Collections.Generic;

namespace CaseTeamSec.Services
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetComments();
        Comment GetComment(int id);
        void CreateComment(Comment comment);
        void UpdateComment(Comment comment);
        void DeleteComment(int id, int writerId);

    }
}
