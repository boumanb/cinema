using BioscoopB3Web.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioscoopB3Web.Domain.Entities;

namespace BioscoopB3Web.Domain.Concrete
{
    public class EFHallLayoutRepository : IHallLayoutRepository
    {
        private BioscoopModel BioscoopModel;

        public EFHallLayoutRepository(BioscoopModel BioscoopModel)
        {
            this.BioscoopModel = BioscoopModel;
        }
        public HallLayout GetOneHallLayout(int HallLayoutID)
        {
            return BioscoopModel.HallLayouts.Find(HallLayoutID);
        }
    }
}
