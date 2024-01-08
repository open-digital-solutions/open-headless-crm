using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OpenCRM.Core.DataBlock;
using OpenCRM.Core.Web.Models;
using OpenCRM.Core.Web.Pages;
using OpenCRM.SwissLPD.Services;

namespace OpenCRM.SwissLPD.Areas.SwissLDP.Pages.Event
{
    public class IndexModel : PageModel
    {
        private readonly IEventService _eventService;

        [BindProperty]
        public List<DataBlockModel<EventModel>> EventList { get; set; } = new List<DataBlockModel<EventModel>>();

        [BindProperty]
        public _BreadCrumbPartialModel BreadCrumbPartialModel { get; set; } = new _BreadCrumbPartialModel();

        public IndexModel(IEventService eventService)
        {
            _eventService = eventService;
        }

        public void OnGet()
        {
            var events = _eventService.GetEvents();
            if (events != null)
            {
                EventList = events;
            }

            BreadCrumbLinkModel newLink = new BreadCrumbLinkModel()
            {
                Area = "",
                IsActive = true,
                Name = "Event",
                Page = "/Event"
            };

            BreadCrumbPartialModel.Links.Add(newLink);
        }
    }
}
