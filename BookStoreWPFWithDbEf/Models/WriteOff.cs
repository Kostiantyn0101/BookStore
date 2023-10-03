using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWPFWithDbEf.Models
{
    public class WriteOff
    {
        public int Id { get; set; }
        public virtual Books Book { get; set; } = null!;
        public int Count { get; set; }
        public DateTime Time { get; set; }
        [StringLength(100)]
        public string Description { get; set; } = null!;

    }
}
