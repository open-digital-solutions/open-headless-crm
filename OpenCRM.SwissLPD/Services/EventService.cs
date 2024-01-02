using OpenCRM.Core.DataBlock;
using OpenDHS.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCRM.SwissLPD.Services
{
        public class EventService<TDBContext> : IEventService where TDBContext : DataContext
        {
        public readonly IDataBlockService _dataBlockService;
        public EventService(IDataBlockService dataBlockService)
        {
            _dataBlockService = dataBlockService;
        }
        public DataBlockModel<EventModel> AddEvent(DataBlockModel<EventModel> model)
        {
            throw new NotImplementedException();
        }

        public DataBlockModel<EventModel> GetEvent(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<DataBlockModel<EventModel>> GetEvents()
        {
            throw new NotImplementedException();
        }

        public Task RemoveEvent(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task Seed()
        {
            throw new NotImplementedException();
        }
    }
}
