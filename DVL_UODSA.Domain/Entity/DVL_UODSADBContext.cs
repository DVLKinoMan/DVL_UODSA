using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVL_UODSA.Domain.Entity
{
    public class DVL_UODSADBContext : DbContext
    {
        public DbSet<List> Lists { get; set; }
        public DbSet<ListItem> ListItems { get; set; }
        public DbSet<SortedList> SortedLists { get; set; }
        public DbSet<SortedListItem> SortedListItems { get; set; }
        //public DbSet<User> Users { get; set; }
    }
}
