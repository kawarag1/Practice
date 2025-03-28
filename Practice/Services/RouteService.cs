using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Models;

namespace Practice.Services
{
    internal class RouteService
    {
        public static List<Route> GetRoutes()
        {
            using (PracticeContext context = new PracticeContext())
            {
                return context.Routes.ToList();
            }
        }
    }
}
