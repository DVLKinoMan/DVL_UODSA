using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVL_UODSA.Domain.Entity
{
    public class List
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(800)]
        public string Description { get; set; }
        [Required]
        [StringLength(50)]
        public string ItemTypeName { get; set; }
        [Required]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        [Required]
        public bool IsPrivate { get; set; } = false;
        public bool IsDeleted { get; set; } = false;

        //[ForeignKey("Owner")]
        //[Required]
        [StringLength(128)]
        public string OwnerID { get; set; }
        //public User Owner { get; set; }

        public ICollection<ListItem> Items { get; set; }
    }
}
