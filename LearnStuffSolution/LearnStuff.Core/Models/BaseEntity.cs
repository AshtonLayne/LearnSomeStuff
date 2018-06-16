using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnStuff.Core.Models
{
    public abstract class BaseEntity
    {
        public string ID { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public BaseEntity()
        {
            this.ID = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.Now;

        }
    }
}
