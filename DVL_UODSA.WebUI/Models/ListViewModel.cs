using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVL_UODSA.WebUI.Models
{
    public class ListViewModel
    {
        [Display(Name = "ID")]
        public int ID { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Item Type")]
        public string ItemTypeName { get; set; }
        [Display(Name = "Is Private")]
        public bool IsPrivate { get; set; }
        public string OwnerID { get; set; }
        public bool CanEdit { get; set; }
        public bool CanSort { get; set; }
        public int? SortedListID { get; set; }
        public List<ListItemViewModel> Items { get; set; }
    }
}