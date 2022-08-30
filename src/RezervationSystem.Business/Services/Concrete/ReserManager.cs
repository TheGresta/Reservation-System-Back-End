using Core.Utilities.Message;
using RezervationSystem.Business.Services.Abstract;
using RezervationSystem.DataAccess.Abstract;
using RezervationSystem.Dto.Concrete;
using RezervationSystem.Entity.Concrete;

namespace RezervationSystem.Business.Services.Concrete
{
    public class ReserManager : BaseManager<Reser, ReserWriteDto, ReserReadDto>, IReserService
    {
        public ReserManager(IReserDal repository, ILanguageMessage languageMessage) : base(repository, languageMessage)
        {
        }
    }
}
