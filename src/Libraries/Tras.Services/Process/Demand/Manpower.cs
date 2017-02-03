using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tras.Services.Process.Demand
{
    public class Manpower
    {
        public int TotalNoOfPerson
        {
            get
            {
                return
                    TotalNoOfOwn +
                    TotalNoOfSpouse +
                    TotalNoOfKidsMinor +
                    TotalNoOfKidsHalf +
                    TotalNoOfKidsAdult +
                    TotalNoOfBatMan;


            } 
        }

        public int TotalNoOfOwn { get; set; }
        public int TotalNoOfSpouse { get; set; }
        public int TotalNoOfKidsMinor { get; set; }
        public int TotalNoOfKidsHalf { get; set; }
        public int TotalNoOfKidsAdult { get; set; }
        public int TotalNoOfBatMan { get; set; }
    }
}
