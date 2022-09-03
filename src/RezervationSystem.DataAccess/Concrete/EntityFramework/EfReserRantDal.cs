using Core.DataAccess.EntityFramework;
using RezervationSystem.DataAccess.Abstract;
using RezervationSystem.DataAccess.Contexts;
using RezervationSystem.Entity.Concrete;

namespace RezervationSystem.DataAccess.Concrete.EntityFramework
{
    public class EfReserRentDal : EfRepositoryBase<ReserRent, RezervationSystemDbContext>, IReserRentDal
    {
        public EfReserRentDal(RezervationSystemDbContext context) : base(context)
        {
        }
    }
}