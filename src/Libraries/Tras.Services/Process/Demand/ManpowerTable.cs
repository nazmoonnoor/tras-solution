using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tras.Services.Process.Demand
{
    public class ManpowerTable
    {
        public int PersonId { get; set; }
        public int PackageId { get; set; }

        public string PeopleTypeKey { get; set; }
        public string JobTypeKey { get; set; }
        public int Own { get; set; }
        public int Spouse { get; set; }
        public int KidsMinor { get; set; }
        public int KidsHalf { get; set; }
        public int KidsAdult { get; set; }
        public int BatMan { get; set; }



    }
}
