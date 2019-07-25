using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVL_UODSA.Domain.Entity
{
    public class SortedList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        //[ForeignKey("Owner")]
        [StringLength(128)]
        public string OwnerID { get; set; }
        //[Required]
        //public User Owner { get; set; }

        //[Required]
        [ForeignKey("BaseList")]
        public int? BaseListID { get; set; }

        public List BaseList { get; set; }

        public bool IsDeleted { get; set; } = false;

        public ICollection<SortedListItem> Items { get; set; }
    }
}
