using eTicketAppplication.Data.Base;
using eTicketAppplication.Models;
using eTickets.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace eTicketAppplication.Data.Services
{
    public class ActorsService : EntityBaseRespository<Actor> , IActorService
    {
        public ActorsService(AppDbContext context) :base(context) { }

    }
}
