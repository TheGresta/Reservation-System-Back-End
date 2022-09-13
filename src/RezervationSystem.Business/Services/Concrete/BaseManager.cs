using Core.DataAccess;
using Core.Dto;
using Core.Entity;
using Core.Exceptions;
using Core.Paging;
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

        public BaseManager(IRepository<TEntity> repository, ILanguageMessage languageMessage)
        {
            Repository = repository;
            LanguageMessage = languageMessage;
        }

        public virtual async Task<DataResult<TReadDto>> AddAsync(TWriteDto writeDto)
        {
            TEntity entity = writeDto.Adapt<TEntity>();

            TEntity addedEntity = await Repository.AddAsync(entity);

            if (addedEntity == null)
                throw new BusinessException(LanguageMessage.FailureAdd);

            return new SuccessDataResult<TReadDto>(addedEntity.Adapt<TReadDto>(), LanguageMessage.SuccessAdd);
        }

        public virtual async Task<DataResult<TReadDto>> DeleteAsync(int id)
        {
            TEntity entity = await Repository.GetAsync(x => x.Id == id);
            if (entity == null)
                throw new BusinessException(LanguageMessage.FailureGet);

            TEntity deletedEntity = await Repository.DeleteAsync(entity);

            if (deletedEntity == null)
                throw new BusinessException(LanguageMessage.FailureDelete);

            return new SuccessDataResult<TReadDto>(deletedEntity.Adapt<TReadDto>(), LanguageMessage.SuccessDelete);
        }

        public virtual async Task<DataResult<TReadDto>> GetByIdAsync(int id)
        {
            IPaginate <TEntity> entity = await Repository.GetAllAsync(x => x.Id == id);
            if (entity == null)
                throw new BusinessException(LanguageMessage.FailureGet);

            TReadDto readDto = entity.Adapt<TReadDto>();
            return new SuccessDataResult<TReadDto>(readDto, LanguageMessage.SuccessGet);
        }

        public virtual async Task<DataResult<IPaginate<TReadDto>>> GetListAsync()
        {
            IPaginate<TEntity> entities = await Repository.GetAllAsync();

            if (paginate.Items == null)
                throw new BusinessException(LanguageMessage.FailureGet);

            IPaginate<TReadDto> returnedPaginate = paginate.Adapt<IPaginate<TReadDto>>();
            return new SuccessDataResult<IPaginate<TReadDto>>(returnedPaginate, LanguageMessage.SuccessGet);
        }

        public virtual async Task<DataResult<TReadDto>> UpdateAsync(int id, TWriteDto writeDto)
        {
            TEntity updatedEntity = await Repository.GetAsync(x => x.Id == id);
            if (updatedEntity == null)
                throw new BusinessException(LanguageMessage.FailureGet);

            writeDto.Adapt(updatedEntity);

            TEntity entity = await Repository.UpdateAsync(updatedEntity);

            if (entity == null)
                throw new BusinessException(LanguageMessage.FailureUpdate);

            return new SuccessDataResult<TReadDto>(entity.Adapt<TReadDto>(), LanguageMessage.SuccessUpdate);
        }
    }
}
