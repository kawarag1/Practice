using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Models;

namespace Practice.Services
{
    internal class EmployeeService
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string? patronymic { get; set; }
        public int passportID { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int RoleID { get; set; }


        private readonly PracticeContext practiceContext;

        public EmployeeService(string name, string surname, string? patronymic, int RoleID, int passportID, string login, string password, PracticeContext context)
        {
            this.name = name;
            this.surname = surname;
            this.RoleID =  RoleID;
            this.passportID = passportID;
            this.login = login;
            this.password = password;
            this.practiceContext = context;
        }

        public static Employee? Authorization(string login, string password)
        {
            using (PracticeContext context = new PracticeContext())
            {
                return context.Employees.FirstOrDefault(x => x.Login == login && x.Password == password);
            }
        }
        public async static void Registration(Employee newEmployee)
        {
            using (PracticeContext context = new PracticeContext())
            {
                context.Employees.Add(newEmployee);
                await context.SaveChangesAsync();
            }

        }
    }
}
