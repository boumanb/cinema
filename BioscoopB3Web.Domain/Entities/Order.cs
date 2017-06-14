using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1.Entities
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int StudentTickets { get; set; }
        public int ElderlyTickets { get; set; }
        public int ChildTickets { get; set; }
        public int NormalTickets { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual Ticket Ticket { get; set; }

    }
}
