using Core.DataAccess;
using Core.Dto;
using Core.Entity;
using Core.Exceptions;
using Core.Utilities.Message;
using Core.Utilities.Result;
using FluentValidation.Resources;
using Mapster;
using RezervationSystem.Business.Services.Abstract;

namespace RezervationSystem.Business.Services.Concrete
{
    public class BaseManager<TEntity, TWriteDto, TReadDto> : IBaseService<TEntity, TWriteDto, TReadDto>
        where TEntity : BaseEntity, new()
        where TWriteDto : class, IWriteDto, new()
        where TReadDto : class, IReadDto, new()

    {
        protected readonly IRepository<TEntity> Repository;
        protected readonly ILanguageMessage LanguageMessage;

        public BaseManager(IRepository<TEntity> repositrt, ILanguageMessage languageMessage)
        {
            Repository = repositrt;
            LanguageMessage = languageMessage;
        }

        public async Task<IResult> AddAsync(TWriteDto writeDto)
        {
            TEntity entity = writeDto.Adapt<TEntity>();

            TEntity addedEntity = await Repository.AddAsync(entity);

            if (addedEntity == null)
                throw new BusinessException(LanguageMessage.FailureAdd);

            return new SuccessResult(LanguageMessage.SuccessAdd);
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            TEntity entity = await Repository.GetAsync(x => x.Id == id);
            if (entity == null)
                throw new BusinessException(LanguageMessage.FailureGet);

            TEntity deletedEntity = await Repository.DeleteAsync(entity);
            if (deletedEntity == null)
                throw new BusinessException(LanguageMessage.FailureDelete);

            return new SuccessResult(LanguageMessage.SuccessDelete);
        }

        public async Task<DataResult<TReadDto>> GetByIdAsync(int id)
        {
            TEntity entity = await Repository.GetAsync(x => x.Id == id);
            if (entity == null)
                throw new BusinessException(LanguageMessage.FailureGet);

            TReadDto readDto = entity.Adapt<TReadDto>();
            return new SuccessDataResult<TReadDto>(readDto, LanguageMessage.SuccessGet);
        }

        public async Task<DataResult<List<TReadDto>>> GetListAsync()
        {
            List<TEntity> entities = await Repository.GetAllAsync();

            if (entities == null)
                throw new BusinessException(LanguageMessage.FailureGet);

            List<TReadDto> readDtos = entities.Adapt<List<TReadDto>>();
            return new SuccessDataResult<List<TReadDto>>(readDtos, LanguageMessage.SuccessGet);
        }

        public async Task<IResult> UpdateAsync(int id, TWriteDto writeDto)
        {
            TEntity updatedEntity = await Repository.GetAsync(x => x.Id == id);
            if(updatedEntity == null)
                throw new BusinessException(LanguageMessage.FailureGet);

            writeDto.Adapt(updatedEntity);

            TEntity entity = await Repository.UpdateAsync(updatedEntity);

            if (entity == null)
                throw new BusinessException(LanguageMessage.FailureUpdate);

            return new SuccessResult(LanguageMessage.SuccessUpdate);
        }
    }
}
