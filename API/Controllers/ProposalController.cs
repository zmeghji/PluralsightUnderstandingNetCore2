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
    public class ProposalController : ControllerBase
    {
        private readonly IProposalRepository proposalRepository;

        public ProposalController(IProposalRepository proposalRepository)
        {
            this.proposalRepository = proposalRepository;
        }
        [HttpGet("{conferenceId}")]
        public async Task<IActionResult> GetAll(int conferenceId)
        {
            var proposals = await proposalRepository.GetAll(conferenceId);
            if (!proposals.Any())
            {
                return new NoContentResult();
            }
            return new ObjectResult(proposals);
        }

        [HttpGet("{id}", Name ="GetById")]
        public async Task<ProposalModel> GetById(int id)
        {
            return await proposalRepository.GetById(id);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProposalModel proposalModel)
        {
            var addedProposal = proposalRepository.Add(proposalModel).Result;
            return CreatedAtRoute("GetById", new { id = addedProposal.Id }, addedProposal);
        }

        [HttpPut("{proposalId}")]
        public IActionResult Approve(int proposalId)
        {
            try
            {
                var approvedProposal = proposalRepository.Approve(proposalId).Result;
                return new ObjectResult(approvedProposal);
            }
            catch(InvalidOperationException ex)
            {
                return NotFound();
            }
        }
    }
}
