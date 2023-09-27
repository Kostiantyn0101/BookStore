using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookStoreWPFWithDbEf.Models
{
    public class Authors
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string FullName { get; set; } = null!;
        public virtual ICollection<Books> Books { get; set; } = null!;
    }
}
