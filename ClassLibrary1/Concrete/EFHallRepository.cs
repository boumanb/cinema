using BioscoopB3Web.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioscoopB3Web.Domain.Entities;

namespace BioscoopB3Web.Domain.Concrete
{
    public class EFHallRepository : IHallRepository
    {
        private BioscoopModel BioscoopModel;

        public EFHallRepository(BioscoopModel BioscoopModel)
        {
            this.BioscoopModel = BioscoopModel;
        }

        public IEnumerable<Hall> GetAllHalls()
        {
            return BioscoopModel.Halls;
        }

        public Hall GetOneHall(int HallID)
        {
            return BioscoopModel.Halls.Find(HallID);
        }
    }
}
