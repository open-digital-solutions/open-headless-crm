using OpenDHS.Shared;

namespace OpenCRM.Finance.Services
{
    public interface IAccountingService
    {
        List<AccountingModel> GetAccountingModels();
        void Seed();
    }
}