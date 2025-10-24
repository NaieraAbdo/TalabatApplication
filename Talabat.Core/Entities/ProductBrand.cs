using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities
{
    public class ProductBrand:BaseEntity
    {
        public string Name { get; set; }
        //public ICollection<Product> Products { get; set; } don't need it in business
        //will do it with fluent api cause it will EF will think this is 1:1
    }
}
