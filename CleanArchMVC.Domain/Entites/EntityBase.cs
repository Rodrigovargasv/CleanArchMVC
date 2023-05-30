using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Entites
{
    public abstract class EntityBase
    {
        // Used how Id base to category class and product 
        // Usado como Id base para classe categoria e produto

        public int Id { get;  protected set; }
    }
}
