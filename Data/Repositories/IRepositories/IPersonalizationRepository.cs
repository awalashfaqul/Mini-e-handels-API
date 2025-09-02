using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mini_e_handels_API.Models;

namespace Mini_e_handels_API.Data.Repositories.IRepositories
{
    public interface IPersonalizationRepository
    {
        PersonalizedContent GetContentForSegment(string segment);
        void Add(PersonalizedContent content);
    }
}