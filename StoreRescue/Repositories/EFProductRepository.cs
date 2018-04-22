using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreRescue.Models;

namespace StoreRescue.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        ApplicationDBContext context;

        public EFProductRepository(ApplicationDBContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Product> Products => context.Products;//.Include(p=>p.category) ;

        public Product RemoveProduct(int ProductID)
        {
            Product _prod = context.Products.Where(p => p.ProductID == ProductID).FirstOrDefault();
            if (_prod != null )
            {
                context.Products.Remove(_prod);
                context.SaveChanges();
                return (_prod);
            }
            else
            { return null; }
        }

        public void SaveProduct(Product product)
        {
           
                if (product.ProductID ==0 )
            {
                context.Products.Add(product);
            }
            else
            {
                Product _prod = context.Products.Where(p => p.ProductID == product.ProductID).FirstOrDefault();
                _prod.CategoryID = product.CategoryID;
                _prod.Price = product.Price;
                _prod.ProductName = product.ProductName;
                _prod.ProductDescription = product.ProductDescription;
                
            }
            context.SaveChanges();
        }
    }
}
