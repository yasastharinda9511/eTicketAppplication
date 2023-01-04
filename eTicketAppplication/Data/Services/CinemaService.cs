using eTicketAppplication.Data.Base;
using eTicketAppplication.Models;
using eTickets.Data;

namespace eTicketAppplication.Data.Services
{
    public class CinemaService : EntityBaseRespository<Cinema>, ICinemaService
    {
        public CinemaService(AppDbContext context) : base(context) { }
    }
}
