using Core.DataAccess;
using Core.Utilities.Message;
using RezervationSystem.Business.Services.Abstract;
using RezervationSystem.DataAccess.Abstract;
using RezervationSystem.Dto.Concrete;
using RezervationSystem.Entity.Concrete;

namespace RezervationSystem.Business.Services.Concrete
{
    public class ReserRentManager : BaseManager<ReserRent, ReserRentWriteDto, ReserRentReadDto>, IReserRentService
    {
        public ReserRentManager(IReserRentDal repositrt, ILanguageMessage languageMessage) : base(repositrt, languageMessage)
        {
        }
    }
}
