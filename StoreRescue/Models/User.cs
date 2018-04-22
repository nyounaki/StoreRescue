using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace StoreRescue.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        //public User CreatedUser { get; set; }

        public DateTime ModifiedDate { get; set; }
        public User ModifiedUser { get; set; }
    }
}