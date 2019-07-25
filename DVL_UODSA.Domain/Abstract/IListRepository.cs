using DVL_UODSA.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVL_UODSA.Domain.Abstract
{
    public interface IListRepository
    {
        IEnumerable<List> Lists { get; }

        void AdddList(List list);
        List<List> GetActiveLists();
        List<List> GetActiveLists(string authenticatedUserID);
        List GetListByID(int id);
        void DeleteListByID(int id);
    }
}
