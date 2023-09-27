using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWPFWithDbEf.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public virtual Books Book { get; set; } = null!;
        public DateTime Time { get; set; }
        public int Count { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
    }
}
