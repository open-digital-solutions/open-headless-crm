using OpenCRM.Core.DataBlock;
using OpenDHS.Shared;

namespace OpenCRM.Finance.Services
{
    public interface IAccountingService
    {
        List<DataBlockModel<AccountingModel>> GetAccountingModels();
        Task SeedAsync();
    }
}