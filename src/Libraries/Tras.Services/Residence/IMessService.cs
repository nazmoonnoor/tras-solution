using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Residence;
using Tras.Core.PagedList;

namespace Tras.Services.Residence
{
    public interface IMessService
    {
        Mess InsertMess(Mess mess);
        void UpdateMess(Mess mess);
        void DeleteMess(Mess mess);
        Mess GetMessById(int messId);
        IEnumerable<Mess> GetMesses();
        IPagedList<Mess> GetMesses(int pageSize, int pageIndex, bool showDeleted = false);
    }
}
