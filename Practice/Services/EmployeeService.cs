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
