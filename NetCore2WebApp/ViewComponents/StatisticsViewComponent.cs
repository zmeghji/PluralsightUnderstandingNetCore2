using Microsoft.AspNetCore.Mvc;
using NetCore2WebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore2WebApp.ViewComponents
{
    public class StatisticsViewComponent : ViewComponent
    {
        private readonly IConferenceService ConferenceService;

        public StatisticsViewComponent(IConferenceService conferenceService)
        {
            this.ConferenceService = conferenceService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string statsCaption)
        {
            ViewBag.Caption = statsCaption;
            return View(await ConferenceService.GetStatistics());
        }
    }
}
