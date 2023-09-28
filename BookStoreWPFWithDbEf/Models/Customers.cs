using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWPFWithDbEf.Models
{
    public class Customers
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [StringLength(50)]
        public string Email { get; set; } = null!;
        [StringLength(30)]
        public string PhoneNumber { get; set; } = null!;
        [StringLength(20)]
        public string Login { get; set; } = null!;
        [StringLength(20)]
        public string Password { get; set; } = null!;
        public bool IsAdmin { get; set; } = false;
    }
}
