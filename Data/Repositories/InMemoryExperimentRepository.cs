using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mini_e_handels_API.Models;
using Mini_e_handels_API.Data.Repositories.IRepositories;

namespace Mini_e_handels_API.Data.Repositories
{
    public class InMemoryExperimentRepository : IExperimentRepository
    {
        // Implementation of the IExperimentRepository interface
        // This class manages experiments in memory for A/B testing
        private readonly List<Experiment> _experiments = new(); 

        public Experiment Create(string name, string variantA, string variantB)
        {
            var experiment = new Experiment
            {
                experimentId = _experiments.Count + 1,
                experimentName = name,
                experimentVariantA = variantA,
                experimentVariantB = variantB
            };
            _experiments.Add(experiment);
            return experiment;
        }

        public Experiment Get(int id)
        {
            return _experiments.FirstOrDefault(e => e.Id == id);
        }

        public string GetVariant(int id)
        {
            var experiment = Get(id);
            if (experiment == null)
                return null;

            // Randomly return either VariantA or VariantB
            return new Random().Next(2) == 0 ? experiment.experimentVariantA : experiment.experimentVariantB;
        }
    }
}
