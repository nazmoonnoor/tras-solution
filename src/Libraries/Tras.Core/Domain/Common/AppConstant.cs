using System.Configuration;
using Tras.Core.Helpers;

namespace Tras.Core.Domain.Common
{
    public class AppConstant
    {
        //TODO: keep it in config.
        public static int PageSize = 15;
        public const string RationSubHeadNameForCivil = "Normal For Civilian";
        public const string RationHeadNameForSubsidy = "Subsidy";
        public const string RationHeadNameForNormal = "Normal";
        public const string RationHeadNameForFree = "Free";
        //public const string RationItemCategoryForFreshItem = "Ration Fresh Item";
        //public const string RationItemCategoryForSpicyItem = "Ration Spicy Item";
        public const string RationItemCategoryForRegularItem = "Ration Item";
        public static int TableCacheTime
        {
            get { return ConfigurationManager.AppSettings["table:CacheTime"].ToInt(); }
        }

        public enum LookupType
        {
            Person_Type = 0,
            Category,
            Family_Type,
            Marital_Status,
            Gender,
            Job_Type,
            Month_Range
        }

        public enum PageAction
        {
            List,
            Create,
            Edit,
            Detail
        }

        public enum InputWidthType
        {
            Small,
            Medium,
            Large
        }

        public enum PersonCategory
        {
            Officer = 1,
            Soldier = 2
        }

        public enum TransactionType
        {
            RationHandOut = 1
        }
    }
}
