using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Practice.Models;

namespace Practice.Services
{
    class TripService
    {
        public static List<Trip> Trip()
        {
            using (PracticeContext context = new PracticeContext())
            {
                return context.Trips
                    .Include(t => t.Bus)
                    .Include(t => t.Driver)
                    .Include(t => t.RouteNavigation)
                    .OrderBy(t => t.Id)
                    .ToList();
            }
        }
        
        public async static void DeleteTrip(Trip trip)
        {
            using (PracticeContext context = new PracticeContext())
            {
                context.Trips.Remove(trip);
                await context.Tickets
                    .Where(t => t.TripId == trip.Id)
                    .ExecuteDeleteAsync();
                await context.SaveChangesAsync();
            }
        }

        public async static void CreateTrip(Trip trip)
        {
            using (PracticeContext ctx = new PracticeContext())
            {
                ctx.Trips.Add(trip);
                await ctx.SaveChangesAsync();
            }
        }

        public async static void UpdateTrip(Trip trip)
        {
            using (PracticeContext context = new PracticeContext())
            {
                context.Trips.Update(trip);
                await context.SaveChangesAsync();
            }
        }
    }
}
