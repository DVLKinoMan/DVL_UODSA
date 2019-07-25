using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVL_UODSA.WebUI.Models
{
    public class SortedListViewModel
    {
        public int ID { get; set; }
        public string OwnerID { get; set; }
        public List<SortedListItemViewModel> Items { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public ListViewModel BaseList { get; set; }
    }
}