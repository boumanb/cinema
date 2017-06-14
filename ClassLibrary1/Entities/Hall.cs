using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopB3Web.Domain.Entities
{
    public class Hall
    {
        [Key]
        public int HallID { get; set; }
        public int Capacity { get; set; }
        public int HallLayoutID { get; set; }
        public virtual HallLayout HallLayout { get; set; }
    }
}
