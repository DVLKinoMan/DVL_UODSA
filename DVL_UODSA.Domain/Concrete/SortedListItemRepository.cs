using DVL_UODSA.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVL_UODSA.Domain.Entity;

namespace DVL_UODSA.Domain.Concrete
{
    public class SortedListItemRepository : ISortedListItemRepository
    {
        private DVL_UODSADBContext context = new DVL_UODSADBContext();
        public IEnumerable<SortedListItem> SortedListItems
        {
            get
            {
                return context.SortedListItems;
            }
        }
    }
}
