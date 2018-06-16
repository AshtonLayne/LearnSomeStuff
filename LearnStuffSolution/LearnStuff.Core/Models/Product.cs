using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnStuff.Core.Models
{
    public class Product : BaseEntity
    {
        

        [StringLength (20)]
        [DisplayName ("Product Name")]
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }

        [Range(0,1000)]
        public string Price { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }


    }
}
