using Microsoft.AspNetCore.Mvc;
using NetCore2WebApp.Services;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore2WebApp.Controllers
{
    public class ProposalController: Controller
    {
        private readonly IConferenceService ConferenceService;
        private readonly IProposalService ProposalService;

        public ProposalController(IConferenceService conferenceService, IProposalService proposalService)
        {
            this.ConferenceService = conferenceService;
            this.ProposalService = proposalService;
        }
        public async Task<IActionResult> Index(int conferenceId)
        {
            var conference = await ConferenceService.GetById(conferenceId);
            ViewBag.Title = $"Proposals for Conference {conference.Name} {conference.Location}";
            ViewBag.ConferenceId = conferenceId;
            return View(await ProposalService.GetAll(conferenceId));
        }
        public IActionResult Add(int conferenceId)
        {
            return View(new ProposalModel { ConferenceId = conferenceId });
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProposalModel proposalModel)
        {
            if (ModelState.IsValid)
            {
                await ProposalService.Add(proposalModel);
            }
            return RedirectToAction("Index", new { conferenceId = proposalModel.ConferenceId });
        }

        public async Task<IActionResult> Approve(int proposalId)
        {
            var proposalModel = await ProposalService.Approve(proposalId);
            return RedirectToAction("Index", new { conferenceId = proposalModel.ConferenceId });
        }
    }
}
