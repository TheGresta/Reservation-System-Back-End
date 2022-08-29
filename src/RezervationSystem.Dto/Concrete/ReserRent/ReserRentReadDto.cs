using Core.Dto;
using RezervationSystem.Entity.Concrete;

namespace RezervationSystem.Dto.Concrete
{
    public class ReserRentReadDto : IReadDto
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int ReserId { get; set; }
        public Reser Reser { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
