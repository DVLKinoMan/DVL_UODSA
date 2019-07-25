using DVL_UODSA.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVL_UODSA.Domain.Abstract
{
    public interface ISortedListItemRepository
    {
        IEnumerable<SortedListItem> SortedListItems { get; }
    }
}
