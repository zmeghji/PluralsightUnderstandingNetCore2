using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ConferenceController : ControllerBase
    {
        private readonly IConferenceRepository conferenceRepository;

        public ConferenceController(IConferenceRepository conferenceRepository)
        {
            this.conferenceRepository = conferenceRepository;
        }
        //[HttpGet("{id}", Name = "GetById")]
        //public async Task<ConferenceModel> GetById(int id)
        //{
        //    return await conferenceRepository.GetById(id);
        //}
        public IActionResult GetAll()
        {
            var conferences = conferenceRepository.GetAll().Result;
            if (!conferences.Any())
            {
                return new NoContentResult();
            }
            return new ObjectResult(conferences);
        }

        [HttpPost]
        public ConferenceModel Add([FromBody] ConferenceModel conferenceModel)
        {
            return conferenceRepository.Add(conferenceModel).Result;
        }
    }
}
