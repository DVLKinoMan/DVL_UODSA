using DVL_UODSA.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVL_UODSA.WebUI.Models
{
    public class CreateListViewModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Item Type")]
        public string ItemTypeName { get; set; }
        public List<ListItemViewModel> Items { get; set; }
        //public User Owner { get; set; }
        [StringLength(128)]
        public string OwnerID { get; set; }
        [Display(Name = "Privacy")]
        public bool IsPrivate { get; set; }
    }
}