using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gruppo1_Model
{
    public class Category
    {
        [Key]
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }

    }
}
