using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OpenCRM.SwissLPD.Services;

namespace OpenCRM.SwissLPD.Areas.SwissLDP.Pages.Event
{
    public class IndexModel : PageModel
    {
        private readonly IEventService _eventService;
        public IndexModel(IEventService eventService)
        {
            _eventService = eventService;
        }
        public void OnGet()
        {
            //TODO: Load here event list. Define page's list bind property
            //await_eventService.GetEvents();
        }
    }
}
