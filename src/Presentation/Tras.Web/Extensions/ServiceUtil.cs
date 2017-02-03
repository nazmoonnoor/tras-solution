using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Microsoft.Ajax.Utilities;
using Tras.Core.Domain.Common;
using Tras.Core.Helpers;
using Tras.Services.Configuration;
using Tras.Web.Models.Configuration;

namespace Tras.Web.Extensions
{
    public class ServiceUtil
    {
        public static LookupViewModel FatchLookup(AppConstant.LookupType lookupType, string key)
        {
            string type = lookupType.ConvertToString();
            var lookupService = DependencyResolver.Current.GetService(typeof(ILookupService));
            var lookupList = ((ILookupService)lookupService).GetCachedLookupList();
            var dataModel = lookupList.FirstOrDefault(l => (l.Key == key && l.LookupType == type.ToUpper()));
            return dataModel != null ? dataModel.ToModel() : null;
        }

        public static string FatchLookupValue(AppConstant.LookupType lookupType, string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return string.Empty;
            }
            return FatchLookup(lookupType, key).Value;
        }
    }
}