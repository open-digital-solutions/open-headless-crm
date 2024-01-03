using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OpenCRM.Core.DataBlock;
using OpenCRM.SwissLPD.Services;
using OpenDHS.Shared.Data;

namespace OpenCRM.SwissLPD.Areas.SwissLDP.Pages.Event
{
    public class DeleteModel : PageModel
    {
        private readonly IEventService _eventService;

        public DeleteModel(IEventService eventService)
        {
            _eventService = eventService;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            var removeBlock = _eventService.GetEvent(id);
            
            if (removeBlock == null)
            {
                return NotFound();
            }
            
            await _eventService.RemoveEvent(id);
            return RedirectToPage("./Index");
        }
    }
}
