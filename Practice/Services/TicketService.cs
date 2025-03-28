using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Practice.Models;

namespace Practice.Services
{
    class TicketService
    {
        public static async void CreateTicket(Ticket pass)
        {
            using (PracticeContext context = new PracticeContext())
            {
                context.Tickets.Add(pass);
                await context.SaveChangesAsync();
            }
        }

        public static async void CancelTicket(Passenger pass)
        {
            using (PracticeContext context = new PracticeContext())
            {
                await context.Tickets.Where(t => t.PassengerId == pass.Id).ExecuteDeleteAsync();
                await context.SaveChangesAsync();
            }
        }
    }
}
