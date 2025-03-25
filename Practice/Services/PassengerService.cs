using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Practice.Models;

namespace Practice.Services
{
    internal class PassengerService
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string? patronymic { get; set; }
        public DateOnly birthdate { get; set; }
        public int passportID { get; set; }
        public string login {  get; set; }
        public string password { get; set; }

        private readonly PracticeContext practiceContext;

        public PassengerService(string name, string surname, string? patronymic, DateOnly birthdate, int passportID, string login, string password, PracticeContext practiceContext) 
        {
            this.name = name;
            this.surname = surname;
            this.birthdate = birthdate;
            this.passportID = passportID;
            this.login = login;
            this.password = password;
            this.practiceContext = practiceContext;
        }


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
                return context.Passengers.FirstOrDefault(x => x.Login == login && x.Password == password);
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
    }
}
