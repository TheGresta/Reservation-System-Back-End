using Core.Dto;

namespace RezervationSystem.Dto.Concrete
{
    public class ReserReadDto : IReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ReserRentReadDto> ReserRents { get; set; }
        public string Address { get; set; }
        public string Descripton { get; set; }
        public decimal Price { get; set; }

        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
