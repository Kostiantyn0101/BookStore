using BookStoreWPFWithDbEf.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWPFWithDbEf.ViewModels
{
    public class BooksVM
    {
        private ICollection<ReceiptGoodViewModel> _receiptGoods;
        private ICollection<SaleGoodViewModel> _saleGoods;
        public AuthorsVM(Authors model)
        {
            Model = model; 
            _receiptGoods = model.ReceiptGoods.Select(x => new ReceiptGoodViewModel(x)).ToList();
            _saleGoods = model.SaleGoods.Select(x => new SaleGoodViewModel(x)).ToList();
        }
        public Authors Model { get; set; }
        public int Id { get => Model.Id; }
        public string FullName
        {
            get => Model.FullName;
            set
            {
                Model.FullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }
        public StatusViewModel Status
        {
            get => new StatusViewModel(Model.Status);
            set
            {
                Model.Status = value.Model;
                OnPropertyChanged(nameof(Status));
            }
        }



        public int Id { get; set; }
        [StringLength(100)]
        public string Title { get; set; } = null!;
        [StringLength(100)]
        public string Publisher { get; set; } = null!;
        public int TotalPages { get; set; } = 0;
        public int Year { get; set; } = 0;
        [Column(TypeName = "decimal(18,4)")]
        public decimal SalePrice { get; set; } = 0;
        [Column(TypeName = "decimal(18,4)")]
        public decimal CostPrice { get; set; } = 0;
        public bool IsNew { get; set; } = false;
        public virtual Authors Authors { get; set; } = null!;
        public virtual Genres Genres { get; set; } = null!;
        public int? ContinuationOfBookId { get; set; }
        [ForeignKey("ContinuationOfBookId")]
        public virtual Books ContinuationOfBook { get; set; } = null!;

        [InverseProperty(nameof(ReceiptBook.Book))]
        public virtual ICollection<ReceiptBook> Receipts { get; set; } = null!;
        [InverseProperty(nameof(SaleBook.Book))]
        public virtual ICollection<SaleBook> Sales { get; set; } = null!;
        [InverseProperty(nameof(Reservation.Book))]
        public virtual ICollection<Reservation> Reservations { get; set; } = null!;
    }
}
