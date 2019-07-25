using DVL_UODSA.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVL_UODSA.Domain.Abstract
{
    public interface ISortedListRepository
    {
        IEnumerable<SortedList> SortedLists { get; }

        void SaveSortedList(SortedList sortedList);
        List<SortedList> GetActiveSortedListsByOwnerID(string ownerID);
        SortedList GetActiveSortedListByID(int id);
        void DeleteSortedListByID(int id);
        bool CanSortList(int listID, string authenticatedUserID);
        List<SortedList> GetActiveSortedListsByBaselistID(int baseListID);
    }
}
