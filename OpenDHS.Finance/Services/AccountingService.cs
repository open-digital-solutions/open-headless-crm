﻿using OpenCRM.Core.DataBlock;
using OpenDHS.Shared;
using OpenDHS.Shared.Data;
using System.Text.Json;

namespace OpenCRM.Finance.Services
{
    public class AccountingService<TDBContext> : IAccountingService where TDBContext : DataContext
    {
        public readonly IDataBlockService _dataBlockService;
        public AccountingService( IDataBlockService dataBlockService)
        {
            _dataBlockService = dataBlockService;
        }

        public List<DataBlockModel<AccountingModel>> GetAccountingModels()
        {
            var blocksResult = _dataBlockService.GetDataBlockListAsync<AccountingModel>();
            return blocksResult;
        }

        public async Task SeedAsync()
        {
            var dataModel = new AccountingModel()
            {
                AccountingType = AccountingType.CREDIT,
                Ammount = 333.544M,
                Description = $"Seeded at {DateTime.UtcNow}"
            };

            DataBlockModel<AccountingModel> dataBlockModel = new()
            {
                Name = dataModel.Description,
                Description = dataModel.Description,
                Type = typeof(AccountingModel).Name,
                Data = dataModel
            };

           var result =  await _dataBlockService.AddBlock(dataBlockModel);
           Console.WriteLine(result);
        }
    }
}
