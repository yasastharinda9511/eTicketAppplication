using eTicketAppplication.Data.Base;
using eTicketAppplication.Models;
using eTickets.Data;

namespace eTicketAppplication.Data.Services
{
    public class ProducerService : EntityBaseRespository<Producer>, IProducerService
    {
        public ProducerService(AppDbContext context) : base(context)
        {
        }
    }
}
