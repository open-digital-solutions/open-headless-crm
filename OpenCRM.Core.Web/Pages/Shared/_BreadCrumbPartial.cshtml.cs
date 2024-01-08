using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OpenCRM.Core.Web.Models;
using System.Xml.Linq;

namespace OpenCRM.Core.Web.Pages
{
    public class _BreadCrumbPartialModel : PageModel
    {

        [BindProperty]
        public List<BreadCrumbLinkModel> Links { get; set; } = new List<BreadCrumbLinkModel>();

        public _BreadCrumbPartialModel()
        {
            Links.Add(new BreadCrumbLinkModel
            {
                Area = "",
                IsActive = true,
                Name = "Home",
                Page = "/"
            });
        }

        public void OnGet()
        {
            
        }
    }
}
