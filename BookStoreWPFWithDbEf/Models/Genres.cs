using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWPFWithDbEf.Models
{
    public class Genres
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Title { get; set; } = null!;
        public virtual ICollection<Books> Books { get; set; } = null!;
    }
}
