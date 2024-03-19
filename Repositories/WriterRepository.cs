using CaseTeamSec.Models;
using System.Collections.Generic;
using System.Linq;

namespace CaseTeamSec.Repositories
{
    public class WriterRepository : IWriterRepository
    {
        private readonly List<Writer> _writers = new List<Writer>();
        private readonly IArticleRepository _articleRepository;

        public WriterRepository(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public Writer GetWriterById(int id)
        {
            return _writers.FirstOrDefault(w => w.Id == id);
        }

        public IEnumerable<Writer> GetAllWriters()
        {
            return _writers;
        }


        public Writer? GetById(int id)
        {
            return _writers.FirstOrDefault(w => w.Id == id);
        }

        public void Add(Writer writer)
        {
            writer.Id = _writers.Count + 1;
            _writers.Add(writer);
        }

        public void Update(Writer writer)
        {
            var existingWriter = GetById(writer.Id);
            if (existingWriter != null)
            {
                int index = _writers.IndexOf(existingWriter);
                _writers[index] = writer;
            }
        }

        public void Delete(int id)
        {
            var writer = GetById(id);
            if (writer != null)
            {

                _articleRepository.DeleteByWriter(id);

                _writers.RemoveAll(w => w.Id == id);
            }
        }
    }
}
