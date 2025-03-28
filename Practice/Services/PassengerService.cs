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
    internal class PassengerService
    {
        public static void CheckLogin(string login)
        {
            using (PracticeContext context = new PracticeContext())
            {
                if (string.IsNullOrWhiteSpace(login))
                {
                    throw new ArgumentException("Логин не может быть пустым или содержать пробелы", nameof(login));
                }
                var passenger = context.Passengers.Where(x => x.Login == login).FirstOrDefault();
                if (passenger != null)
                {
                    throw new InvalidOperationException($"Пользователь с логином: {login} уже существует. Придумайте новый.");
                }
            }
        }

        public static Passenger? Authorization(string login, string password)
        {
            using (PracticeContext context = new PracticeContext())
            {
                return context.Passengers.Where(x => x.Login == login && x.Password == password)
                    .Include(p => p.Tickets)
                    .ThenInclude(x => x.Trip)
                    .ThenInclude(x => x.RouteNavigation)
                    .Include(p => p.Tickets)
                    .ThenInclude(x => x.Trip)
                    .ThenInclude(x => x.Driver)
                    .Include(p => p.Tickets)
                    .ThenInclude(x => x.Trip)
                    .ThenInclude(x => x.Bus)
                    .FirstOrDefault();
            }
        }

        public async static void Registration(Passenger pass)
        {
            using (PracticeContext context = new PracticeContext())
            {
                context.Passengers.Add(pass);
                await context.SaveChangesAsync();
            }

        }

        public async static void UpdateProfile(Passenger pass)
        {
            using (PracticeContext context = new PracticeContext())
            {
                context.Passengers.Update(pass);
                await context.SaveChangesAsync();
            }
        }
        public async static void DeleteProfile(Passenger passenger)
        {
            using (PracticeContext context = new PracticeContext())
            {
                context.Passengers.Remove(passenger);
                await context.Tickets.Where(t => t.PassengerId == passenger.Id).ExecuteDeleteAsync();
                await context.SaveChangesAsync();
            }
        }
    }
}
