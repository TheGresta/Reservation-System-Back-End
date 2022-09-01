using Core.Dto;

namespace RezervationSystem.Dto.Concrete
{
    public class ReserWriteDto : IWriteDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Descripton { get; set; }
        public decimal Price { get; set; }
    }
}
