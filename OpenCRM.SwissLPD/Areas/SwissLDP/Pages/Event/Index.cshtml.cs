using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OpenCRM.Core.DataBlock;
using OpenCRM.Core.Web.Models;
using OpenCRM.Core.Web.Pages;
using OpenCRM.Core.Web.Pages.Shared;
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

        [BindProperty]
        public _TablePartialModel TablePartialModel { get; set; } = new _TablePartialModel();

        public IndexModel(IEventService eventService)
        {
            _eventService = eventService;

            BreadCrumbPartialModel.Links[0].IsActive = false;

            BreadCrumbPartialModel.Links.Add(new BreadCrumbLinkModel()
            {
                Area = "",
                IsActive = true,
                Name = "Event",
                Page = "Event"
            });

            TablePartialModel.Headers.Add("ID");
            TablePartialModel.Headers.Add("Description");
            TablePartialModel.Headers.Add("StartDate");
            TablePartialModel.Headers.Add("EndDate");
        }

        public void OnGet()
        {
            var events = _eventService.GetEvents();
            if (events != null)
            {
                EventList = events;
                //foreach(var item in events)
                //{
                //    TablePartialModel.Lines.Add(new List<string>()
                //    {
                //        item.ID.ToString(),
                //        item.Data.Description,
                //        item.Data.StartDate.ToString(),
                //        item.Data.EndDate.ToString()
                //    });
                //}
            }
        }
    }
}
