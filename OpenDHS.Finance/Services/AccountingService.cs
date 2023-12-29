using OpenCRM.Core.DataBlock;
using OpenDHS.Shared;
using OpenDHS.Shared.Data;
using System.Text.Json;

namespace OpenCRM.Finance.Services
{

    public class AccountingService<TDBContext> : IAccountingService where TDBContext : DataContext
    {
        public TDBContext _dbContext { get; set; }
        public readonly IDataBlockService _dataBlockService;
        public AccountingService(TDBContext dBContext, IDataBlockService dataBlockService)
        {
            _dbContext = dBContext;
            _dataBlockService = dataBlockService;
        }

        public List<DataBlockModel<AccountingModel>> GetAccountingModels()
        {
            var blocksResult = _dataBlockService.GetDataBlockListAsync<AccountingModel>();

            return blocksResult;
        }

        public void Seed()
        {
            var dataModel = new AccountingModel()
            {
                AccountingType = AccountingType.DEBIT,
                Ammount = 0,
                Description = "Seeded debit description"
            };

            DataBlockEntity dataBlock = new()
            {
                Name = "Seeded Accounting Data Block Name",
                Description = "Seeded Accounting Data Block Description",
                Type = typeof(AccountingModel).Name,
                Data = JsonSerializer.Serialize(dataModel)
            };

            _dbContext.Add(dataBlock);
            _dbContext.SaveChanges();
        }

    }
}
