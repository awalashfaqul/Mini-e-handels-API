using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mini_e_handels_API.Models;

namespace Mini_e_handels_API.Data.Repositories.IRepositories
{
    public interface IExperimentRepository
    {
        Experiment Create(string name, string variantA, string variantB);
        Experiment Get(int id);
        string GetVariant(int id); // return A or B randomly
    }
}