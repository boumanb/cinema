using BioscoopB3Web.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopB3Web.Domain.Abstract
{
    public interface IOrderRepository
    {
        bool AddOrder(Order Order);
        Order GetOrderOnPrintID(int PrintID);
        bool CheckPrintIDExist(int PrintID);

    }
}
