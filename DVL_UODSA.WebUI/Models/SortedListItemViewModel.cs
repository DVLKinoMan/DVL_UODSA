using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVL_UODSA.WebUI.Models
{
    public class SortedListItemViewModel
    {
        public int ID { get; set; }
        public int SortedNumber { get; set; }
        public ListItemViewModel ListItem { get; set; }
    }
}