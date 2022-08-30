using Core.Dto;
using Core.Entity;
using Core.Utilities.Result;

namespace RezervationSystem.Business.Services.Abstract
{
    public interface IBaseService<TEntity, TWriteDto, TReadDto>
        where TEntity : BaseEntity, new()
        where TWriteDto : class, IWriteDto, new()
        where TReadDto : class, IReadDto, new()
    {
        Task<IResult> AddAsync(TWriteDto writeDto);
        Task<IResult> UpdateAsync(int id, TWriteDto writeDto);
        Task<IResult> DeleteAsync(int id);

        Task<DataResult<TReadDto>> GetByIdAsync(int id);
        Task<DataResult<List<TReadDto>>> GetListAsync();

    }
}
