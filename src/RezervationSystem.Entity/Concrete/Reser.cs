using Core.Entity;

namespace RezervationSystem.Entity.Concrete
{
    public class Reser : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public List<ReserRent> ObjectRents { get; set; }

        public string Descripton { get; set; }
        public decimal Price { get; set; }
    }
}
