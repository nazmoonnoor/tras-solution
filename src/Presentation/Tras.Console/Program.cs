using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Data;

namespace Tras.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new TrasObjectContext();
            var categories = ctx.RationItemCategories.ToList();

            System.Console.WriteLine("Operation done. Press any key.");
            System.Console.ReadKey();
        }
    }
}
