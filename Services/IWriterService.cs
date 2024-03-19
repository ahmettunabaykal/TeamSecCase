using CaseTeamSec.Models;
using System.Collections.Generic;

namespace CaseTeamSec.Services
{
    public interface IWriterService
    {
        IEnumerable<Writer> GetWriters();
        Writer GetWriter(int id);
        void CreateWriter(Writer writer);
        void UpdateWriter(Writer writer);
        void DeleteWriter(int id);
    }
}
