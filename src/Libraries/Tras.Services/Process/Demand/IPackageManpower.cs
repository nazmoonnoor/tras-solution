using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Ration;

namespace Tras.Services.Process.Demand
{
    public interface IPackageManpower
    {
        Manpower GetManpowerInfo(int packageId);
    }
}
