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
    public class PersonalizationController : ControllerBase
    {
        private readonly IPersonalizationRepository _personalizationRepository;

        public PersonalizationController(IPersonalizationRepository personalizationRepository)
        {
            _personalizationRepository = personalizationRepository;
        }

        [HttpGet("{segment}")]
        public ActionResult<PersonalizedContent> GetContentForSegment(string segment)
        {
            var content = _personalizationRepository.GetContentForSegment(segment);
            if (content == null)
            {
                return NotFound();
            }
            return Ok(content.pcMessage);
        }

        [HttpPost]
        public IActionResult AddContent(PersonalizedContent content)
        {
            _personalizationRepository.Add(content);
            return Ok(new { message = "Personalized content added successfully." });
        }
    }
}