using Microsoft.AspNetCore.Mvc;
using JobLinq_MVC_Live.Models;

namespace JobLinq_MVC_Live.Controllers
{
    public class RegisterController : Controller
    {
        public RegisterController(DBJobLinqContext dBJobLinqContext)
        {
            DBJobLinqContext=dBJobLinqContext;
        }

        public DBJobLinqContext DBJobLinqContext { get; } // dbcontext sınıfını bir değişgen olarak tanımlamak gerekiyor.

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user) {

            // View tarafında girilen bilgilerin VT tarafına atanması
            var data = new User()
            {
                UserEmail = user.UserEmail,
                UserPassword = user.UserPassword,
                UserType = user.UserType
            };

            // Verilerin DB ye yazılması
            // Burada benim DBContexti kullanarak yazma işlemi gerçekleşecek. Bu yüzden en başlangıca bu yanımı yapmak gerekiyor (Constructor ile).

            DBJobLinqContext.Users.Add(data);
            DBJobLinqContext.SaveChanges();

            return RedirectToAction("Index", "Home");

        }
    }
}
