using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gruppo1_Model
{
    public class Model
    {
        [Key]
        public int ProductModelID { get; set; }
        public string Name { get; set; }
    }
}
