using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.DotNet;

namespace StoreRescue.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Display(Name="Product Description")]
        public string ProductDescription { get; set; }
        [Required(ErrorMessage = "Please enter a product name")]
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }
        public double Price { get; set;  }
        [Required]
        public int  CategoryID { get; set; }
        public Category category { get; set; }
        public DateTime CreatedDate { get; set; }
        //public User CreatedUser { get; set; }
        [DisplayFormat( DataFormatString = "{0:d}")]

        public DateTime ModifiedDate { get; set; }
        [ForeignKey(nameof(User.UserID))]
        public int ModifiedUserID { get; set; }

        public User ModifiedUser { get; set; }
    }
}
