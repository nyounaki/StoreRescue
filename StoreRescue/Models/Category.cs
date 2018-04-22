using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StoreRescue.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Please enter a name")]

        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        [DisplayFormat(DataFormatString ="{0:d}")]
        public DateTime CreatedDate { get; set; }
        //public User CreatedUser { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime ModifiedDate { get; set; }
        public User ModifiedUser { get; set; }
        
        [InverseProperty(nameof(Product.category))]
        public List<Product> Products { get; set; }
    }
}
