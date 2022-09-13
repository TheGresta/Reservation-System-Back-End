using Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace RezervationSystem.Entity.Concrete
{
    public class ReserRent : BaseEntity
    {
        public int CustomerId { get; set; }

        public int ReserId { get; set; }
        [ForeignKey("ReserId")]
        public Reser Reser { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ReserRent()
        {
            new Reser();
        }
        public ReserRent(int id, int customerId, int reserId, DateTime startDate, DateTime endDate, DateTime createDate) : this()
        {
            Id = id;
            CustomerId = customerId;
            ReserId = reserId;
            StartDate = startDate;
            EndDate = endDate;
            CreateDate = createDate;
        }
        public ReserRent(int id, int reserId, DateTime startDate, DateTime endDate, DateTime createDate) : this()
        {
            Id = id;
            ReserId = reserId;
            StartDate = startDate;
            EndDate = endDate;
            CreateDate = createDate;
        }
    }
}
