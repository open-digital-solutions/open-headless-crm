using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OpenCRM.Core.Web.Models;

namespace OpenCRM.Core.Web.Pages
{
    public class _BreadCrumbPartialModel : PageModel
    {

        [BindProperty]
        public BreadCrumbLinkModel? SingleLink { get; set; } = new BreadCrumbLinkModel
        {
            Area = "",
            IsActive = true,
            Name = "Home",
            Page = "/"
        };
        public void OnGet()
        {

        }
    }
}
