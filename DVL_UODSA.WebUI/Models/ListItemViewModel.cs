using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVL_UODSA.WebUI.Models
{
    public class ListItemViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Image")]
        public byte[] Image { get; set; }
        [Display(Name = "Image String")]
        public string ImageString
        {
            get;
            //{
            //    if (Image != null)
            //        return Convert.ToBase64String(Image);
            //    return string.Empty;
            //}
            set;
            //{

            //    if (string.IsNullOrEmpty(value))
            //        Image = null;
            //    else
            //    {
            //        ImageString = value;
            //        //var index = value.IndexOf("base64,");
            //        //if (index >= 0)
            //        //    Image = Convert.FromBase64String(value.Substring(index + 7));
            //        //else Image = Convert.FromBase64String(value);
            //    }
            //}
        }
        [Display(Name = "Description")]
        public string Description { get; set; }
        //public int OwnerUserID { get; set; }
        //public bool Editable
        //{
        //    get
        //    {
        //        int id = 1;//Should be Session User id
        //        if (OwnerUserID == id)
        //            return true;
        //        else return false;
        //    }
        //}
        //public int ItemNumber { get; set; }
    }
}