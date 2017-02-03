using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tras.Services.Process.Demand;
using Tras.Services.Process.Dispersion;

namespace Tras.Services.Process
{
    public interface IRationDemandService
    {
        IList<RationBox> CalculateByItems(int rationSubHeadId, int rationItemCategoryId, int numberOfDays);

   
    }
}
