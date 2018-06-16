using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnStuff.Core.Models
{
    public class ProductCategory
    {
        public string CategoryID { get; set; }
        public string CategoryDescription { get; set; }

        public ProductCategory()
        {
            this.CategoryID = Guid.NewGuid().ToString();
        }
    }
}
