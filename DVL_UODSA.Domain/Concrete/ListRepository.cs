using DVL_UODSA.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVL_UODSA.Domain.Entity;

namespace DVL_UODSA.Domain.Concrete
{
    public class ListRepository : IListRepository
    {
        private DVL_UODSADBContext context = new DVL_UODSADBContext();
        public IEnumerable<List> Lists
        {
            get
            {
                return context.Lists;
            }
        }
        public void AdddList(List list)
        {
            context.Lists.Add(list);
            context.SaveChanges();
        }

        public void DeleteListByID(int id)
        {
            var list = context.Lists.Include("Items").FirstOrDefault(l => l.ID == id);
            //context.ListItems.RemoveRange(list.Items);
            //context.Lists.Remove(list);
            list.IsDeleted = true;
            context.SaveChanges();
        }

        public List<List> GetActiveLists()
        {
            List<List> result = context.Lists.Include("Items").Where(l => l.IsDeleted == false).ToList();

            return result;
        }

        public List<List> GetActiveLists(string authenticatedUserID)
        {
            List<List> result = context.Lists.Include("Items").Where(l => l.IsDeleted == false && (!l.IsPrivate || (!string.IsNullOrEmpty(authenticatedUserID) && l.OwnerID == authenticatedUserID))).ToList();

            return result;
        }

        public List GetListByID(int id)
        {
            List l = context.Lists.Include("Items").FirstOrDefault(li => li.ID == id);

            return l;
        }
    }
}
