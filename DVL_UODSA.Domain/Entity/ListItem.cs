using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVL_UODSA.Domain.Entity
{
    public class ListItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(800)]
        public string Description { get; set; }
        public string ImageString { get; set; }
        [Required]
        public int NumberInList { get; set; }

        //[Required]
        [ForeignKey("BaseList")]
        public int? BaseListID { get; set; }
        public List BaseList { get; set; }
    }
}
