using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopB3Web.Domain.Entities
{
    public class HallLayout
    {
        [Key]
        public int HallLayoutID { get; set; }
        public int Rows { get; set; }
        public int SeatsPerRow { get; set; }

    }
}
