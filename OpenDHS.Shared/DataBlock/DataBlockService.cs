using Microsoft.AspNetCore.Http;
using OpenDHS.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCRM.Core.DataBlock
{
    public class DataBlockService<TDBContext> : IDataBlockService where TDBContext : DataContext
    {
    }
}
