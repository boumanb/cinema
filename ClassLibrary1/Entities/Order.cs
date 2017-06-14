using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BioscoopB3Web.Domain.Entities
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int StudentTickets { get; set; }
        public int ElderlyTickets { get; set; }
        public int ChildTickets { get; set; }
        public int NormalTickets { get; set; }
        public int TotalTickets { get; set; }
        public int PopcornArrangement { get; set; }
        public decimal StudentTicketsPrice { get; set; }
        public decimal ChildTicketsPrice { get; set; }
        public decimal ElderlyTicketsPrice { get; set; }
        public decimal NormalTicketsPrice { get; set; }
        public decimal TotalPrice { get; set; }    
        public decimal PopcornArrangementPrice { get; set; }
        public int PrintID { get; set; }


        public int getTotalTickets()
        {
            TotalTickets = StudentTickets + ElderlyTickets + ChildTickets + NormalTickets;
            return TotalTickets;
        }

    }
}
