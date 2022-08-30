using Core.DataAccess;
using Core.Utilities.Message;
using RezervationSystem.Business.Services.Abstract;
using RezervationSystem.DataAccess.Abstract;
using RezervationSystem.Dto.Concrete;
using RezervationSystem.Entity.Concrete;

namespace RezervationSystem.Business.Services.Concrete
{
    internal class ReserManager : BaseManager<Reser, ReserWriteDto, ReserReadDto>, IReserService
    {
        public ReserManager(IReserDal repositrt, ILanguageMessage languageMessage) : base(repositrt, languageMessage)
        {
        }
    }
}
