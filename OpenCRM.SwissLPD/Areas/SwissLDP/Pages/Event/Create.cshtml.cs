using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OpenCRM.Core.DataBlock;
using OpenCRM.SwissLPD.Services;
using OpenDHS.Shared.Data;

namespace OpenCRM.SwissLPD.Areas.SwissLDP.Pages.Event
{
    public class CreateModel : PageModel
    {
		private readonly IEventService _eventService;

		public CreateModel(IEventService eventService)
		{
			_eventService = eventService;
		}

		public IActionResult OnGet()
		{
			return Page();
		}

		[BindProperty]
		public EventModel Model { get; set; } = default!;

		public IActionResult OnPost()
		{
			if (ModelState.IsValid)
			{
				var dataModel = new EventModel()
				{
					Description = Model.Description,
					StartDate = Model.StartDate,
					EndDate = Model.EndDate,
				};

				var dataBlockModel = new DataBlockModel<EventModel>()
				{
					Name = dataModel.Description,
					Description = dataModel.Description,
					Type = typeof(EventModel).Name,
					Data = dataModel
				};

				_eventService.AddEvent(dataBlockModel);
				return RedirectToPage("./Index");
			}

            return Page();
        }
    }
}
