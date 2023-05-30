using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Entites
{
    public sealed class Product : EntityBase
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal? Price { get; private set; }

        public int? Stock { get; private set; }

        public Category Category;
        public int? CategoryId { get; private set; }
    }
}
