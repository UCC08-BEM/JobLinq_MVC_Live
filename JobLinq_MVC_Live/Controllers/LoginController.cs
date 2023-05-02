using JobLinq_MVC_Live.Models;
using JobLinq_MVC_Live.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JobLinq_MVC_Live.Controllers
{
    public class LoginController : Controller
    {
        public LoginController(DBJobLinqContext dBJobLinqContext)
        {
            DBJobLinqContext = dBJobLinqContext;
        }

        public DBJobLinqContext DBJobLinqContext { get; } // dbcontext sınıfını bir değişgen olarak tanımlamak gerekiyor.

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginVM login)
        {
            var user = DBJobLinqContext.Users.Where(u => u.UserEmail == login.UserEmail);
            // db tarafındaki tabloda ekrandan girilen email adresi ile ilgili bir kayıt varmı?

            if (user.Any()) // email bilgisi uyan herhangi bir kayıt bulduysan  
            {
                if (user.Where(u=> u.UserPassword==login.UserPassword).Any()) // password bilgisi uyan herhangi bir kayıt varmı 
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }

            }



            return View();

        }

    }
}
