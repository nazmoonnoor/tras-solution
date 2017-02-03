using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Tras.Core.Domain.Common;
using Tras.Core.Helpers;
using Tras.Services.Configuration;
using Tras.Services.Employee;
using Tras.Services.Ration;
using Tras.Services.Residence;

namespace Tras.Web.Extensions
{
    public static class ServiceExtensions
    {
        public static IEnumerable<SelectListItem> GetSelectList(this ILookupService lookupService, AppConstant.LookupType lookupType, object selectedId = null, bool isDropdown = true)
        {
            string type = lookupType.ConvertToString().ToUpper();
            var list = lookupService.GetLookupByType(type);
            var selectList = list.Select(item => new SelectListItem
            {
                Value = item.Key, 
                Text = item.Value,
                Selected = selectedId != null && item.Key == selectedId.ToString()
            }).ToList();
            
            if (isDropdown)
            {
                selectList.Insert(0, new SelectListItem {Value = "", Text = "Please select..."});
            }
            return selectList;
        }

        public static IEnumerable<SelectListItem> GetSelectList(this IDepartmentService departmentService, object selectedId = null, bool isDropdown = true)
        {
            var list = departmentService.GetDepartments();
            var selectList = list.Select(item => new SelectListItem
            {
                Value = item.DepartmentId.ToString(),
                Text = item.Name,
                Selected = selectedId != null && item.DepartmentId == (int) selectedId
            }).ToList();
            
            if (isDropdown)
            {
                selectList.Insert(0, new SelectListItem {Value = "", Text = "Please select..."});
            }
            return selectList;
        }

        public static IEnumerable<SelectListItem> GetSelectList(this IDirectorService directorService, object selectedId = null, bool isDropdown = true)
        {
            var list = directorService.GetDirectors();
            var selectList = list.Select(item => new SelectListItem
            {
                Value = item.DirectorId.ToString(),
                Text = item.Name,
                Selected = selectedId != null && item.DirectorId == (int) selectedId
            }).ToList();
            
            if (isDropdown)
            {
                selectList.Insert(0, new SelectListItem {Value = "", Text = "Please select..."});
            }
            return selectList;
        }

        public static IEnumerable<SelectListItem> GetSelectList(this IUnitService unitService, object selectedId = null, bool isDropdown = true)
        {
            var list = unitService.GetUnits();
            var selectList = list.Select(item => new SelectListItem
            {
                Value = item.UnitId.ToString(),
                Text = item.Name,
                Selected = selectedId != null && item.UnitId == (int) selectedId
            }).ToList();
            
            if (isDropdown)
            {
                selectList.Insert(0, new SelectListItem {Value = "", Text = "Please select..."});
            }
            return selectList;
        }

        public static IEnumerable<SelectListItem> GetSelectList(this IRankService rankService, object selectedId = null, bool isDropdown = true)
        {
            var list = rankService.GetRanks();
            var selectList = list.Select(item => new SelectListItem
            {
                Value = item.RankId.ToString(),
                Text = item.Name,
                Selected = selectedId != null && item.RankId == (int) selectedId
            }).ToList();
            
            if (isDropdown)
            {
                selectList.Insert(0, new SelectListItem {Value = "", Text = "Please select..."});
            }
            return selectList;
        }

        public static IEnumerable<SelectListItem> GetSelectList(this IRationHeadService rationHeadService, object selectedId = null, bool isDropdown = true)
        {
            var list = rationHeadService.GetHeads();
            var selectList = list.Select(item => new SelectListItem
            {
                Value = item.HeadId.ToString(),
                Text = item.HeadName,
                Selected = selectedId != null && item.HeadId == (int)selectedId
            }).ToList();
            
            if (isDropdown)
            {
                selectList.Insert(0, new SelectListItem {Value = "", Text = "Please select..."});
            }
            return selectList;
        }
        public static IEnumerable<SelectListItem> GetSelectList(this IMessService messService, object selectedId = null, bool isDropdown = true)
        {
            var list = messService.GetMesses();
            var selectList = list.Select(item => new SelectListItem
            {
                Value = item.MessId.ToString(),
                Text = item.MessName,
                Selected = selectedId != null && item.MessId == (int)selectedId
            }).ToList();
            
            if (isDropdown)
            {
                selectList.Insert(0, new SelectListItem {Value = "", Text = "Please select..."});
            }
            return selectList;
        }

        public static IEnumerable<SelectListItem> GetSelectList(this IRationItemCategoryService rationItemCategoryService, object selectedId = null, bool isDropdown = true)
        {
            var list = rationItemCategoryService.GetRationItemCategories();
            var selectList = list.Select(item => new SelectListItem
            {
                Value = item.CategoryId.ToString(),
                Text = item.CategoryName,
                Selected = selectedId != null && item.CategoryId == (int)selectedId
            }).ToList();
            
            if (isDropdown)
            {
                selectList.Insert(0, new SelectListItem {Value = "", Text = "Please select..."});
            }
            return selectList;
        }

        public static IEnumerable<SelectListItem> GetSelectList(this IPackageService packageService, object selectedId = null, bool isDropdown = true)
        {
            var list = packageService.GetPackages();
            var selectList = list.Select(item => new SelectListItem
            {
                Value = item.PackageId.ToString(),
                Text = item.PackageCode,
                Selected = selectedId != null && item.PackageId == (int)selectedId
            }).ToList();
            
            if (isDropdown)
            {
                selectList.Insert(0, new SelectListItem {Value = "", Text = "Please select..."});
            }
            return selectList;
        }

        public static IEnumerable<SelectListItem> GetSelectList(this IRationSubHeadService rationSubHeadService, object selectedId = null, bool isDropdown = true)
        {
            var list = rationSubHeadService.GetSubHeads();
            var selectList = list.Select(item => new SelectListItem
            {
                Value = item.SubHeadId.ToString(),
                Text = item.SubHeadName,
                Selected = selectedId != null && item.SubHeadId == (int)selectedId
            }).ToList();
            
            if (isDropdown)
            {
                selectList.Insert(0, new SelectListItem {Value = "", Text = "Please select..."});
            }
            return selectList;
        }
        public static IEnumerable<SelectListItem> GetSelectList(this IStationService stationService, object selectedId = null)
        {
            var list = stationService.GetStations();
            var selectList = list.Select(item => new SelectListItem
            {
                Value = item.StationId.ToString(),
                Text = item.Name,
                Selected = selectedId != null && item.StationId == (int)selectedId
            }).ToList();
            selectList.Insert(0, new SelectListItem { Value = "", Text = "Please select..." });
            return selectList;
        }
        public static IEnumerable<SelectListItem> GetSelectList(this IPersonPackageService personPackageService, object selectedId = null)
        {
            var list = personPackageService.GetPersonPackages();
            var selectList = list.Select(item => new SelectListItem
            {
                Value = item.PackageId.ToString(),
                Text = item.Package.PackageCode,
                Selected = selectedId != null && item.PackageId == (int)selectedId
            }).ToList();
            selectList.Insert(0, new SelectListItem { Value = "", Text = "Please select..." });
            return selectList;
        }

    }
}