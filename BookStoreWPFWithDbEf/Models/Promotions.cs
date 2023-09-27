using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWPFWithDbEf.Models
{
    public class Promotions
    {
        public int Id { get; set; }
        public virtual Books Book { get; set; } = null!;
        public int Discount { get; set; } = 0;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

    }
}
