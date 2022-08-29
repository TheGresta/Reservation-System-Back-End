using Core.Dto;

namespace RezervationSystem.Dto.Concrete
{
    public class ReserRentWriteDto : IWriteDto
    {
        public int? CustomerId { get; set; }
        public int ReserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
