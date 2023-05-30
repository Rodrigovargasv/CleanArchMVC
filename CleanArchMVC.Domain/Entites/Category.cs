using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Entites
{
    public sealed class Category : EntityBase
    {

        public string Name { get; private set; }

        public ICollection<Product> Products { get;}

    }
}
