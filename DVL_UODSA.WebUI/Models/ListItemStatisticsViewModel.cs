using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVL_UODSA.WebUI.Models
{
    public class ListItemStatisticsViewModel
    {
        public int SortedNumber { get; set; }
        public ListItemViewModel ListItem { get; set; }
        public int SortedNumbersSum { get; set; }
    }
}