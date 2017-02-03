using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Services.Process.Dispersion;

namespace Tras.Services.Process.Demand
{
    public class FoodPackage
    {
        public int PackageId { get; set; }
        public string PackageCode { get; set; }

        public int SubHeadId { get; set; }

        public string SubHeadName { get; set; }
        public List<FoodPackageItem> Items { get; set; }

    }
}
