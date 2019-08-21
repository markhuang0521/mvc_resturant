using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resturant.Models
{
    public class MenuItemVm
    {
        public MenuItem MenuItem { get; set; }
        public IEnumerable<SubCategory> SubCategory { get; set; }
        public IEnumerable<Category> Category { get; set; }
    }
}
