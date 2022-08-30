using Microsoft.AspNetCore.Mvc;
using RezervationSystem.Business.Services.Abstract;
using RezervationSystem.Dto.Concrete;
using RezervationSystem.Entity.Concrete;

namespace RezervationSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ResersController : BaseController<Reser, ReserWriteDto, ReserReadDto>
    {
        public ResersController(IReserService baseService) : base(baseService)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await base.GetListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return await base.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReserWriteDto reserWriteDto)
        {
            return await base.AddAsync(reserWriteDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] ReserWriteDto reserWriteDto)
        {
            return await base.UpdateAsync(id, reserWriteDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return await base.DeleteAsync(id);
        }

    }
}
