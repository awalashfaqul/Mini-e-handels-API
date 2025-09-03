using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mini_e_handels_API.Models;
using Mini_e_handels_API.Data.Repositories.IRepositories;

namespace Mini_e_handels_API.Data.Repositories
{
    public class InMemoryPersonalizationRepository : IPersonalizationRepository
    {
        private readonly List<PersonalizedContent> _contents = new();

        public PersonalizedContent GetContentForSegment(string segment)
        {
            return _contents.FirstOrDefault(c => c.pcSegment == segment);
        }

        public void Add(PersonalizedContent content)
        {
            _contents.Add(content);
        }
    }
}