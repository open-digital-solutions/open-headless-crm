using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OpenCRM.Finance.Services;
using OpenDHS.Shared;

namespace OpenCRM.Finance.Areas.Finance.Pages.Accounting
{
    public class IndexModel : PageModel
    {
        private readonly IAccountingService _accountingDataService;
        public IndexModel(IAccountingService accountingDataService)
        {
            _accountingDataService = accountingDataService;
        }

        [BindProperty]
        public List<AccountingModel> AccountingList { get; set; } = new List<AccountingModel>();

        public void OnGet()
        {
            var data = _accountingDataService.GetAccountingModels();
            if (data != null)
            {
                AccountingList = data;
            }
        }
    }
}
