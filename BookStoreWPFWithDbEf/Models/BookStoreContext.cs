using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWPFWithDbEf.Models
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext()
        {
        }
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer("Data Source=LAPTOP-UVAUHJMP\\SQLEXPRESS;Initial Catalog=BookStore;" +
           "Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;" +
           "Connect Timeout=60;Encrypt=False;Trust Server Certificate=False");


        public virtual DbSet<Authors> Authors { get; set; } = null!;
        public virtual DbSet<Books> Books { get; set; } = null!;
        public virtual DbSet<Customers> Customers { get; set; } = null!;
        public virtual DbSet<Genres> Genres { get; set; } = null!;
        public virtual DbSet<Promotions> Promotions { get; set; } = null!;
        public virtual DbSet<ReceiptBook> ReceiptBook { get; set; } = null!;
        public virtual DbSet<Reservation> Reservation { get; set; } = null!;
        public virtual DbSet<SaleBook> SaleBook { get; set; } = null!;

    }
}
