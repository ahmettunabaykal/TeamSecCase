using CaseTeamSec.Models;
using System.Collections.Generic;

namespace CaseTeamSec.Repositories
{
    public interface IWriterRepository
    {
        Writer GetWriterById(int id);
        IEnumerable<Writer> GetAllWriters();
        Writer? GetById(int id);
        void Add(Writer writer);
        void Update(Writer writer);
        void Delete(int id);
        
    }
}
