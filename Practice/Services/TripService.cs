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
    }
}
