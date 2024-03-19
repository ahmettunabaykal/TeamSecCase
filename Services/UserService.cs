using CaseTeamSec.Models;
using System.Collections.Generic;
using System.Linq;

namespace CaseTeamSec.Services
{
    public class UserService
    {
        private readonly List<Writer> _writers = new List<Writer>();

        public Writer Register(string name, string bio)
        {
            var writer = new Writer
            {
                Id = _writers.Count + 1,
                Name = name,
                Bio = bio,
                
            };

            _writers.Add(writer);
            return writer;
        }

        public Writer? Authenticate(string name)
        {
            return _writers.FirstOrDefault(w => w.Name == name);
        }
    }
}
