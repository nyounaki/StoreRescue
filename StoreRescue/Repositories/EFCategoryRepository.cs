using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreRescue.Models;

namespace StoreRescue.Repositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        ApplicationDBContext context;

        public EFCategoryRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public IQueryable<Category> Categories => context.Categories;

        public Category RemoveCategory(int CategoryID)
        {
            Category _cat = context.Categories.Where(c => c.CategoryID == CategoryID).FirstOrDefault();
            if ( !(_cat is null))
                { context.Categories.Remove(_cat);
                context.SaveChanges();
                return _cat;
            }
            return null;


        }

        public void SaveCategory(Category category)
        {
            if (category.CategoryID==0)
            {
                context.Categories.Add(category);
            }
            else
            {
                Category _cat = context.Categories.Where(c => c.CategoryID == category.CategoryID).FirstOrDefault();
                if (!(_cat  is null ))
                {
                    _cat.CategoryName = category.CategoryName;
                    _cat.CategoryDescription = category.CategoryDescription;

                }
            }
            context.SaveChanges();
        }
    }
}
