using StoreRescue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreRescue.Repositories
{
  public   interface ICategoryRepository
    {
         IQueryable<Category> Categories { get; }
        Category RemoveCategory(int CategoryID);
        void SaveCategory(Category category);
    }
}
