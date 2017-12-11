using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Entity;
using HRM.Data.Interfaces;

namespace HRM.Data
{
    public class AttendanceRepository : Repository<Attendance>, IAdvertiserListRepository
    {
        public bool Insert(AdvertiserList entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(AdvertiserList entity)
        {
            throw new NotImplementedException();
        }

        AdvertiserList IRepository<AdvertiserList>.Get<Tkey>(Tkey id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<AdvertiserList> IRepository<AdvertiserList>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
