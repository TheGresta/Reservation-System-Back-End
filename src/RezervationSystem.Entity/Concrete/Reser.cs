using Core.Entity;

namespace RezervationSystem.Entity.Concrete
{
    public class Reser : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<ReserRent> ObjectRents { get; set; }

        public string Descripton { get; set; }
        public decimal Price { get; set; }

        public Reser()
        {
            ObjectRents = new HashSet<ReserRent>();
        }

        public Reser(int id, string name, string address, string descripton, decimal price, int userId, DateTime createDate) : this()
        {
            Id = id;
            Name = name;
            Address = address;
            Descripton = descripton;
            Price = price;
            UserId = userId;
            CreateDate = createDate;
        }
    }
}
