using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using LearnStuff.Core.Models;

namespace LearnStuff.DataAccess.InMemory
{
    public class CategoryCache
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> categories;

        public CategoryCache()
        {
            categories = cache["categories"] as List<ProductCategory>;
            if (categories == null)
            {
                categories = new List<ProductCategory>();
            }
        }

        public void CommitToMemory()
        {
            cache["categories"] = categories;
        }

        public void Insert(ProductCategory pc)
        {
            categories.Add(pc);
        }

        public void Update(ProductCategory pc)
        {
            ProductCategory categoryToUpdate = categories.Find(p => p.CategoryID == pc.CategoryID);

            if (categoryToUpdate != null)
            {
                categoryToUpdate = pc;
            }
            else
            {
                throw new Exception("Category not found");
            }
        }

        public ProductCategory Find(string ID)
        {
            ProductCategory pc = categories.Find(c => c.CategoryID == ID);

            if (pc != null)
            {
                return pc;
            }
            else
            {
                throw new Exception("Category not found");
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return categories.AsQueryable();
        }

        public void Delete(string ID)
        {
            ProductCategory categoryToDelete = categories.Find(pc => pc.CategoryID == ID);

            if (categoryToDelete != null)
            {
                categories.Remove(categoryToDelete);
            }
            else
            {
                throw new Exception("Category not found");
            }
        }
    }
}
