using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Tras.Core.Domain.Configuration;
using Tras.Core.Domain.Employee;
using Tras.Core.Domain.Ration;
using Tras.Core.Domain.Residence;
using Tras.Core.PagedList;
using Tras.Web.Models.Configuration;
using Tras.Web.Models.Employee;
using Tras.Web.Models.Ration;
using Tras.Web.Models.Residence;


namespace Tras.Web.Extensions
{
    public static class MappingExtensions
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return Mapper.Map(source, destination);
        }

        public static IList<TDestination> ToMappedList<TSource, TDestination>(this IList<TSource> list)
        {
            IEnumerable<TDestination> sourceList = Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(list);
            return sourceList.ToList();
        }

        public static IPagedList<TDestination> ToMappedPagedList<TSource, TDestination>(this IPagedList<TSource> list)
        {
            IEnumerable<TDestination> sourceList = Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(list);
            IPagedList<TDestination> pagedResult = new StaticPagedList<TDestination>(sourceList, list.GetMetaData());
            return pagedResult;
        }

        #region Lookup 
        
        public static Lookup ToEntity(this LookupViewModel viewModel)
        {
            return viewModel.MapTo<LookupViewModel, Lookup>();
        }

        public static Lookup ToEntity(this LookupViewModel viewModel, Lookup destination)
        {
            return viewModel.MapTo(destination);
        }

        public static LookupViewModel ToModel(this Lookup model)
        {
            return model.MapTo<Lookup, LookupViewModel>();
        }

        public static LookupViewModel ToModel(this Lookup model, LookupViewModel destination)
        {
            return model.MapTo(destination);
        }
        
        #endregion

        #region Person

        public static Person ToEntity(this PersonViewModel viewModel)
        {
            return viewModel.MapTo<PersonViewModel, Person>();
        }

        public static PersonViewModel ToModel(this Person model)
        {
            return model.MapTo<Person, PersonViewModel>();
        }

        public static Person ToEntity(this BattalionProfileViewModel viewModel)
        {
            return viewModel.MapTo<BattalionProfileViewModel, Person>();
        }

        public static BattalionProfileViewModel ToModelBatttalion(this Person model)
        {
            return model.MapTo<Person, BattalionProfileViewModel>();
        }
        #endregion

        #region Family Info

        public static FamilyInfo ToEntity(this FamilyInfoViewModel viewModel)
        {
            return viewModel.MapTo<FamilyInfoViewModel, FamilyInfo>();
        }

        public static FamilyInfoViewModel ToModel(this FamilyInfo model)
        {
            return model.MapTo<FamilyInfo, FamilyInfoViewModel>();
        }

        public static PersonPackage ToEntity(this PersonPackageViewModel viewModel)
        {
            return viewModel.MapTo<PersonPackageViewModel, PersonPackage>();
        }
        public static PersonPackageViewModel ToModel(this PersonPackage model)
        {
            return model.MapTo<PersonPackage, PersonPackageViewModel>();
        }
        #endregion

        #region Department

        public static Department ToEntity(this DepartmentViewModel viewModel)
        {
            return viewModel.MapTo<DepartmentViewModel, Department>();
        }

        public static DepartmentViewModel ToModel(this Department entity)
        {
            return entity.MapTo<Department, DepartmentViewModel>();
        }
        #endregion

        #region Rank

        public static Rank ToEntity(this RankViewModel viewModel)
        {
            return viewModel.MapTo<RankViewModel, Rank>();
        }

        public static RankViewModel ToModel(this Rank entity)
        {
            return entity.MapTo<Rank, RankViewModel>();
        }
        #endregion

        #region Director

        public static Director ToEntity(this DirectorModel model)
        {
            return model.MapTo<DirectorModel, Director>();
        }

        public static DirectorModel ToModel(this Director entity)
        {
            return entity.MapTo<Director, DirectorModel>();
        }
        #endregion

        #region Unit

        public static Unit ToEntity(this UnitViewModel viewModel)
        {
            return viewModel.MapTo<UnitViewModel, Unit>();
        }

        public static UnitViewModel ToModel(this Unit entity)
        {
            return entity.MapTo<Unit, UnitViewModel>();
        }
        #endregion

        #region RationHeads

        public static RationHead ToEntity(this RationHeadViewModel viewModel)
        {
            return viewModel.MapTo<RationHeadViewModel, RationHead>();
        }

        public static RationHeadViewModel ToModel(this RationHead entity)
        {
            return entity.MapTo<RationHead, RationHeadViewModel>();
        }
        #endregion

        #region RationSubHeads

        public static RationSubHead ToEntity(this RationSubHeadViewModel viewModel)
        {
            return viewModel.MapTo<RationSubHeadViewModel, RationSubHead>();
        }

        public static RationSubHeadViewModel ToModel(this RationSubHead entity)
        {
            return entity.MapTo<RationSubHead, RationSubHeadViewModel>();
        }
        #endregion

        #region Mess

        public static Mess ToEntity(this MessViewModel viewModel)
        {
            return viewModel.MapTo<MessViewModel, Mess>();
        }

        public static MessViewModel ToModel(this Mess entity)
        {
            return entity.MapTo<Mess, MessViewModel>();
        }
        #endregion

        #region Room

        public static Room ToEntity(this RoomViewModel viewModel)
        {
            return viewModel.MapTo<RoomViewModel, Room>();
        }

        public static RoomViewModel ToModel(this Room entity)
        {
            return entity.MapTo<Room, RoomViewModel>();
        }
        #endregion

        #region Package

        public static Package ToEntity(this PackageViewModel viewModel)
        {
            return viewModel.MapTo<PackageViewModel, Package>();
        }

        public static PackageViewModel ToModel(this Package entity)
        {
            return entity.MapTo<Package, PackageViewModel>();
        }
        #endregion

        #region PackageItem

        public static PackageItem ToEntity(this PackageItemViewModel viewModel)
        {
            return viewModel.MapTo<PackageItemViewModel, PackageItem>();
        }

        public static PackageItemViewModel ToModel(this PackageItem entity)
        {
            return entity.MapTo<PackageItem, PackageItemViewModel>();
        }
        #endregion

        #region RationItemCategory

        public static RationItemCategory ToEntity(this RationItemCategoryViewModel viewModel)
        {
            return viewModel.MapTo<RationItemCategoryViewModel, RationItemCategory>();
        }

        public static RationItemCategoryViewModel ToModel(this RationItemCategory entity)
        {
            return entity.MapTo<RationItemCategory, RationItemCategoryViewModel>();
        }
        #endregion

        #region RationItem
        public static RationItem ToEntity(this RationItemViewModel viewModel)
        {
            return viewModel.MapTo<RationItemViewModel, RationItem>();
        }

        public static RationItemViewModel ToModel(this RationItem entity)
        {
            return entity.MapTo<RationItem, RationItemViewModel>();
        }
        #endregion
    }
}