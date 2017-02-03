using System;
using System.Collections.Generic;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Ration;

namespace Tras.Data
{
    public class TrasInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TrasObjectContext>
    {
        protected override void Seed(TrasObjectContext context)
        {
            //RationItemCategory 
            var rationItemCategory = new List<RationItemCategory>
            {
                new RationItemCategory{ CategoryId = 1, CategoryName = "Fresh Food", Active=Active.Y, LastUpdatedDate = DateTime.Now},
                new RationItemCategory{ CategoryId = 2, CategoryName = "Spice Food", Active=Active.Y, LastUpdatedDate = DateTime.Now},
                new RationItemCategory{ CategoryId = 3, CategoryName = "Dry Food", Active=Active.Y, LastUpdatedDate = DateTime.Now},
            };

            //rationItemCategory.ForEach(s => context.RationItemCategories.Add(s));
            //context.SaveChanges();

            //RationItem 
            var rationItems = new List<RationItem>
            {
                new RationItem{ ItemId = 1, CategoryId = 1, ItemName = "Beaf", Active=Active.Y, LastUpdatedDate = DateTime.Now},
                new RationItem{ ItemId = 2, CategoryId = 2, ItemName = "Chili Powder", Active=Active.Y, LastUpdatedDate = DateTime.Now},
                new RationItem{ ItemId = 3, CategoryId = 3, ItemName = "Rice", Active=Active.Y, LastUpdatedDate = DateTime.Now},
            };

            //rationItems.ForEach(s => context.RationItems.Add(s));
            //context.SaveChanges();
        }
    }
}
