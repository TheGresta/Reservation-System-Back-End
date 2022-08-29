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
    }
}
