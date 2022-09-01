using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess;
using Core.Utilities.Message;
using Core.Utilities.Result;
using RezervationSystem.Business.Services.Abstract;
using RezervationSystem.Business.Validators.FluentValidation;
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

        [ValidationAspect(typeof(ReserWriteDtoValidator))]
        public override async Task<DataResult<ReserReadDto>> AddAsync(ReserWriteDto writeDto)
        {
            return await base.AddAsync(writeDto);
        }

        [ValidationAspect(typeof(ReserWriteDtoValidator))]
        public async override Task<DataResult<ReserReadDto>> UpdateAsync(int id, ReserWriteDto writeDto)
        {
            return await base.UpdateAsync(id, writeDto);
        }
    }
}
