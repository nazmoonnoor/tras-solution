using System.Collections.Generic;
using Tras.Core.Domain.Configuration;
using Tras.Core.PagedList;

namespace Tras.Services.Configuration
{
    public interface ILookupService
    {
        Lookup InsertLookup(Lookup lookup);
        void UpdateLookup(Lookup lookup);
        void DeleteLookup(Lookup lookup);
        Lookup GetLookupById(int lookupId);
        IEnumerable<Lookup> GetLookupList(); 
        IPagedList<Lookup> GetLookupList(int pageSize, int pageIndex, string searchText, string orderBy, bool asc = true);
        IEnumerable<Lookup> GetLookupByType(string lookupType);
        IEnumerable<Lookup> GetCachedLookupList();
    }
}