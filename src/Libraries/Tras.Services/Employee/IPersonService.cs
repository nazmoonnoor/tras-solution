using System.Collections.Generic;
using Tras.Core.Domain.Employee;
using Tras.Core.PagedList;
using Tras.Services.Process.Demand;

namespace Tras.Services.Employee
{
    public interface IPersonService
    {
        Person InsertPerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(Person person);
        Person GetPersonById(int personId);
        IEnumerable<Person> GetPeople();
        IPagedList<Person> GetPeople(int pageSize, int pageIndex, string searchText, bool showDeleted = false);
        Person GetPersonByNo(string personalNo);
        //IEnumerable<ManpowerTable> GetManpower(int rationHeadId);
    }
}
