using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVL_UODSA.Domain.Entity
{
    public class SortedListItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int SortedNumber { get; set; }

        //[Required]
        [ForeignKey("ListItem")]
        public int? ListItemID { get; set; }
        public ListItem ListItem { get; set; }

        //[Required]
        [ForeignKey("SortedList")]
        public int? SortedListID { get; set; }
        public SortedList SortedList { get; set; }
    }
}
