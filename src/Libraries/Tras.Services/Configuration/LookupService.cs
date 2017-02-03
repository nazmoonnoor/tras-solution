using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Configuration;
using Tras.Core.PagedList;
using Tras.Data.Infrastructure;

namespace Tras.Services.Configuration
{
    public class LookupService : ILookupService
    {
        private readonly IRepository<Lookup> _lookupRepository;
        private readonly ICacheManager _cacheManager;

        private const string LookupAllCacheKey = "lookup-all";

        public LookupService(IRepository<Lookup> lookupRepository, ICacheManager cacheManager)
        {
            _lookupRepository = lookupRepository;
            _cacheManager = cacheManager;
        }

        public Lookup InsertLookup(Lookup lookup)
        {
            if (lookup == null)
                throw new ArgumentNullException("lookup");

            return _lookupRepository.Insert(lookup);
        }

        public void UpdateLookup(Lookup lookup)
        {
            if (lookup == null)
                throw new ArgumentNullException("lookup");

            _lookupRepository.Update(lookup);
        }

        public void DeleteLookup(Lookup lookup)
        {
            if (lookup == null)
                throw new ArgumentNullException("lookup");

            _lookupRepository.Delete(lookup);
        }

        public Lookup GetLookupById(int lookupId)
        {
            if (lookupId == 0)
                return null;

            return _lookupRepository.GetById(lookupId);
        }

        public IEnumerable<Lookup> GetLookupList()
        {
            return _lookupRepository.Table.Where(x => x.Deleted == false).ToList();
        }

        public IPagedList<Lookup> GetLookupList(int pageSize, int pageIndex, string searchText, string orderBy, bool asc = true)
        {
            var query = _lookupRepository.Table.Where(l => l.Deleted == false);
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                query = query.Where(
                    p => (p.LookupType != null && p.LookupType.ToLower().Contains(searchText.ToLower())
                        || (p.Key != null && p.Key.ToLower().Contains(searchText.ToLower()))
                        || (p.Value != null && p.Value.ToLower().Contains(searchText.ToLower()))
                        || (p.Description != null && p.Description.ToLower().Contains(searchText.ToLower()))
                        || (p.Order.ToString().ToLower().Contains(searchText.ToLower()))
                        ));
            }

            query = query.OrderByDescending(l => l.LookupType).ThenBy(n => n.LookupId);

            var lookups = new PagedList<Lookup>(query, pageIndex, pageSize);
            return lookups;
        }

        public IEnumerable<Lookup> GetLookupByType(string lookupType)
        {
            if (lookupType == string.Empty)
                throw new ArgumentNullException();

            return _lookupRepository.Filter(x => x.LookupType == lookupType).OrderBy(it => it.Order).ToList();
        }

        public IEnumerable<Lookup> GetCachedLookupList()
        {
            string key = string.Format(LookupAllCacheKey);
            int cacheTime = AppConstant.TableCacheTime;
            return _cacheManager.Get(key, cacheTime, () => _lookupRepository.Table.Where(x => x.Deleted == false).ToList());
        }
    }
}