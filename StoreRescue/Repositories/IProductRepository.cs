using StoreRescue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreRescue.Repositories
{
  public  interface IProductRepository
    {
         IQueryable<Product> Products { get; }
        void SaveProduct(Product product);
        Product RemoveProduct(int ProductID);


    }
}
