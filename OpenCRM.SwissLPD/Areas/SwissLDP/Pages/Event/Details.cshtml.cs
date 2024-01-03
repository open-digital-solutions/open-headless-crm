using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OpenCRM.Core.DataBlock;
using OpenCRM.SwissLPD.Services;
using OpenDHS.Shared.Data;

namespace OpenCRM.SwissLPD.Areas.SwissLDP.Pages.Event
{
    public class DetailsModel : PageModel
    {
        private readonly IEventService _eventService;

        public DetailsModel(IEventService eventService)
        {
            _eventService = eventService;
        }

        public DataBlockModel<EventModel> Model { get; set; } = default!;

        public IActionResult OnGet(Guid id)
        {
            var dataModel = _eventService.GetEvent(id);
            
            if (dataModel == null)
            {
               return NotFound();
            }
         
            Model = dataModel;
            return Page();
        }
    }
}
