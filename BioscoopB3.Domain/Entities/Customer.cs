using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1.Entities
{
    public class Customer
    {
        [Key]
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
