using System.Globalization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice;
using Practice.Models;
using Practice.Services;

namespace SomeTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void AuthTest()
        {
            var _result = PassengerService.Authorization("123", "123");
            bool result;

            if (_result == null)
            {
                result = false;
            }
            else
            {
                result = true;
            }
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void RegTest()
        {
            string login = "1234";
            string password = "1234";

            Passenger pass = new Passenger
            {
                Login = login,
                Password = password,
                Name = "Alex",
                Surname = "Alex",
                PassportId = 12344567890
            };
            string bd = "2005-12-12";
            if (DateOnly.TryParseExact(bd, "yyyy-MM-dd",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly date))
            {
                pass.Birthdate = date;
            }
            PassengerService.Registration(pass);

            var _result = PassengerService.Authorization(login, password);
            bool result;

            if (_result == null)
            {
                result = false;
            }
            else
            {
                result = true;
            }
            Assert.IsTrue(result);
        }
    }
}
