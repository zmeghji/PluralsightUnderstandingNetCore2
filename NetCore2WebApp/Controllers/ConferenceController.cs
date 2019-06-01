using Microsoft.AspNetCore.Mvc;
using NetCore2WebApp.Services;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore2WebApp.Controllers
{
    public class ConferenceController: Controller
    {
        private readonly IConferenceService ConferenceService;
        public ConferenceController(IConferenceService conferenceService)
        {
            this.ConferenceService = conferenceService;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Conference Overview";
            return View(await ConferenceService.GetAll());
        }
        public IActionResult Add()
        {
            ViewBag.Title = "Add Conference";
            return View(new ConferenceModel());
        }
        [HttpPost]
        public async Task<IActionResult> Add(ConferenceModel conferenceModel)
        {
            if (ModelState.IsValid)
            {
                await ConferenceService.Add(conferenceModel);
            }
            return RedirectToAction("index");
        }
    }
}
