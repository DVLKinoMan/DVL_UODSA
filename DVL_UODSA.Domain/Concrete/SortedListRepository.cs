using DVL_UODSA.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVL_UODSA.Domain.Entity;

namespace DVL_UODSA.Domain.Concrete
{
    public class SortedListRepository : ISortedListRepository
    {
        private DVL_UODSADBContext context = new DVL_UODSADBContext();
        public IEnumerable<SortedList> SortedLists
        {
            get
            {
                return context.SortedLists;
            }
        }

        public void SaveSortedList(SortedList sortedList)
        {
            context.SortedLists.Add(sortedList);
            context.SaveChanges();
        }

        public List<SortedList> GetActiveSortedListsByOwnerID(string ownerID)
        {
            List<SortedList> result = context.SortedLists.Include("BaseList").Where(l => l.IsDeleted == false && !string.IsNullOrEmpty(ownerID) && l.OwnerID == ownerID).ToList();

            return result;
        }

        public SortedList GetActiveSortedListByID(int id)
        {
            var result = context.SortedLists.Include("BaseList").Include("Items").Include("Items.ListItem").FirstOrDefault(sl => sl.IsDeleted == false && sl.ID == id);

            return result;
        }

        public void DeleteSortedListByID(int id)
        {
            var result = context.SortedLists.FirstOrDefault(sl => sl.ID == id);
            result.IsDeleted = true;
            context.SaveChanges();
        }

        public bool CanSortList(int listID, string authenticatedUserID)
        {
            return !context.SortedLists.Any(sl => !sl.IsDeleted && sl.BaseListID == listID && sl.OwnerID == authenticatedUserID);
        }

        public List<SortedList> GetActiveSortedListsByBaselistID(int baseListID)
        {
            return context.SortedLists.Include("Items").Include("Items.ListItem").Where(sl => sl.IsDeleted == false && sl.BaseListID == baseListID).ToList();
        }
    }
}
