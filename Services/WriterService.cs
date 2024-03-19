using CaseTeamSec.Models;
using CaseTeamSec.Repositories;
using System.Collections.Generic;
namespace CaseTeamSec.Services
{
    public class WriterService : IWriterService
    {
        private readonly IWriterRepository _writerRepository;
        private readonly IArticleRepository _articleRepository; 

        public WriterService(IWriterRepository writerRepository, IArticleRepository articleRepository)
        {
            _writerRepository = writerRepository;
            _articleRepository = articleRepository;
        }

        public IEnumerable<Writer> GetWriters()
        {
            return _writerRepository.GetAllWriters();
        }

        public Writer GetWriter(int id)
        {
            var writer = _writerRepository.GetById(id);
            if (writer == null)
            {
                throw new KeyNotFoundException($"Writer with ID {id} not found.");
            }
            return writer;
        }

        public void CreateWriter(Writer writer)
        {
            _writerRepository.Add(writer);
        }

        public void UpdateWriter(Writer writer)
        {
            _writerRepository.Update(writer);
        }

        public void DeleteWriter(int id)
        {

            _articleRepository.DeleteByWriter(id);


            _writerRepository.Delete(id);
        }
    }
}
