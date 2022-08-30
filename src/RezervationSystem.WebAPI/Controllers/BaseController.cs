using Core.Dto;
using Core.Entity;
using Microsoft.AspNetCore.Mvc;
using RezervationSystem.Business.Services.Abstract;

namespace RezervationSystem.WebAPI.Controllers
{
    [ApiController]
    public class BaseController<TEntity, TWriteDto, TReadDto> : ControllerBase
        where TEntity : BaseEntity, new()
        where TWriteDto : class, IWriteDto, new()
        where TReadDto : class, IReadDto, new()
    {

        protected readonly IBaseService<TEntity, TWriteDto, TReadDto> BaseService;

        public BaseController(IBaseService<TEntity, TWriteDto, TReadDto> baseService)
        {
            BaseService = baseService;
        }

        [NonAction]
        public async Task<IActionResult> AddAsync(TWriteDto writeDto)
        {
            var result = await BaseService.AddAsync(writeDto);
            return Ok(result);
        }

        [NonAction]
        public async Task<IActionResult> UpdateAsync(int id, TWriteDto writeDto)
        {
            var result = await BaseService.UpdateAsync(id, writeDto);
            return Ok(result);
        }

        [NonAction]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await BaseService.DeleteAsync(id);
            return Ok(result);
        }

        [NonAction]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await BaseService.GetByIdAsync(id);
            return Ok(result);
        }

        [NonAction]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await BaseService.GetListAsync();
            return Ok(result);
        }
    }
}
