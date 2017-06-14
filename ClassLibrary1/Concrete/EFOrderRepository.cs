using BioscoopB3Web.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioscoopB3Web.Domain.Entities;

namespace BioscoopB3Web.Domain.Concrete
{
    public class EFOrderRepository : IOrderRepository
    {
        private BioscoopModel BioscoopModel;

        public EFOrderRepository(BioscoopModel BioscoopModel)
        {
            this.BioscoopModel = BioscoopModel;
        }

        public bool AddOrder(Order Order)
        {
            try {
                BioscoopModel.Orders.Add(Order);
                BioscoopModel.SaveChanges();
                return true;
            } catch
            {
                return false;
            }

        }

        public bool CheckPrintIDExist(int PrintID)
        {
            var resultList = BioscoopModel.Orders.Where(o => o.PrintID == PrintID);
            var result = resultList.FirstOrDefault();
            if (result == null){
                return false;
            } else
            {
                return true;
            }
        }

        public Order GetOrderOnPrintID(int PrintID)
        {
            return BioscoopModel.Orders.Where(x => x.PrintID == PrintID).FirstOrDefault();
        }
    }
}
