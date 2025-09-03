using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mini_e_handels_API.Data.Repositories.IRepositories;
using Mini_e_handels_API.Models;

namespace Mini_e_handels_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExperimentController : ControllerBase
    {
        private readonly IExperimentRepository _experimentRepository;

        public ExperimentController(IExperimentRepository experimentRepository)
        {
            _experimentRepository = experimentRepository;
        }

        [HttpPost]
        public ActionResult<Experiment> CreateExperiment([FromBody] Experiment experiment)
        {
            var createdExperiment = _experimentRepository.Create(experiment.experimentName, experiment.experimentVariantA, experiment.experimentVariantB);
            return CreatedAtAction(nameof(GetExperiment), new { id = createdExperiment.experimentId }, createdExperiment);
        }

        [HttpGet("{id}")]
        public ActionResult<Experiment> GetExperiment(int id)
        {
            var experiment = _experimentRepository.Get(id);
            if (experiment == null)
            {
                return NotFound();
            }
            return Ok(experiment);
        }

        [HttpGet("{id}/variant")]
        public ActionResult<string> GetVariant(int id)
        {
            var variant = _experimentRepository.GetVariant(id);
            if (variant == null)
            {
                return NotFound();
            }
            return Ok(variant);
        }
    }
}