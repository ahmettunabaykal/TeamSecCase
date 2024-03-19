using CaseTeamSec.Models;
using CaseTeamSec.Repositories;
using System.Collections.Generic;
using CaseTeamSec.Services;


namespace CaseTeamSec.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public IEnumerable<Comment> GetComments()
        {
            return _commentRepository.GetAll();
        }

        public Comment GetComment(int id)
        {
            var repository = _commentRepository.GetById(id);
            if (repository == null)
            {
                throw new KeyNotFoundException($"Comment with ID {id} not found.");
            }
            return repository;
        }

        public void CreateComment(Comment comment)
        {
            _commentRepository.Add(comment);
        }

        public void UpdateComment(Comment comment)
        {
            _commentRepository.Update(comment);
        }

        public void DeleteComment(int id, int writerId)
        {
            var comment = _commentRepository.GetById(id);
            if (comment == null || comment.WriterId != writerId)
            {
                throw new KeyNotFoundException($"Comment with ID {id} not found or writer mismatch.");
            }
            _commentRepository.Delete(id);
        }

    }
}
