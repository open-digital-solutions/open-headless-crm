using OpenDHS.Shared;
using OpenDHS.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OpenCRM.Finance.Services
{
    
    public class AccountingDataService<TDBContext> where TDBContext : DataContext
    {
        public TDBContext _dbContext { get; set; }
        public AccountingDataService(TDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public void Seed()
        {
            var dataModel = new AccountingDataModel()
            {
                AccountingType = AccountingType.DEBIT,
                Ammount = 0,
                Description = "Seeded debit description"
            };

            DataBlockEntity dataBlock = new()
            {
                Name = "Seeded Accounting Data Block Name",
                Description = "Seeded Accounting Data Block Description",
                Type = typeof(AccountingDataModel).Name,
                Data = JsonSerializer.Serialize(dataModel)
             };

             _dbContext.Add(dataBlock);
             _dbContext.SaveChanges();
        }

    }
}
