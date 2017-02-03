using System;
using System.Collections.Generic;
using System.Linq;
using Tras.Core.Domain.Ration;
using Tras.Core.PagedList;
using Tras.Data.Infrastructure;

namespace Tras.Services.Ration
{
    public class PackageService : IPackageService
    {
        private readonly IRepository<Package> _packageRepository;
        private readonly IRepository<PackageItem> _packageItemRepository;

        public PackageService(IRepository<Package> packageRepository, IRepository<PackageItem> packageItemRepository)
        {
            _packageRepository = packageRepository;
            _packageItemRepository = packageItemRepository;
        }
        public Package InsertPackage(Package package)
        {
            if(package==null)
                throw new ArgumentNullException("package");
            return _packageRepository.Insert(package);
        }

        public void UpdatePackage(Package package)
        {
            if (package == null)
                throw new ArgumentNullException("package");
            package.LastUpdatedDate= DateTime.Now;
            _packageRepository.Update(package);
        }

        public void DeletePackage(Package package)
        {
            if (package == null)
                throw new ArgumentNullException("package");
            _packageRepository.Delete(package);
        }

        public Package GetPackageById(int packageId)
        {
            if (packageId == 0)
                return null;
            return _packageRepository.GetById(packageId);
        }

        public IEnumerable<PackageItem> GetPackageItemsById(int packageId)
        {
            return packageId != 0 ? _packageItemRepository.Table.Where(it => it.PackageId == packageId) : null;
        }

        public IEnumerable<Package> GetPackages()
        {
            return _packageRepository.Table.ToList();
        }

        public IPagedList<Package> GetPackages(int pageSize, int pageIndex, bool showDeleted = false)
        {
            var query = _packageRepository.Table;
            if (!showDeleted)
                query = query.Where(r => r.Deleted == false);
            query = query.OrderByDescending(r => r.PackageId).ThenBy(r => r.PackageCode);
            var packages = new PagedList<Package>(query, pageIndex, pageSize);
            return packages;
        }

        public IEnumerable<Package> GetPackageByRationSubHead(int rationSubHeadId)
        {
            return _packageRepository.Table.Where(p => p.SubHeadId == rationSubHeadId);
        }
    }
}
