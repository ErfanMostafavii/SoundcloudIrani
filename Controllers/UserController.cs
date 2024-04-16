using car_service.Models.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using soundcloud_.Models;
using soundcloud_.Models.Utilitis;
using soundcloud_.Models.ViewModels;
using soundcloud_.Service.Commands.Musics;
using soundcloud_.Service.Commands.UserRegister;
using soundcloud_.Service.Queries.Authentication;
using soundcloud_.UploadUserName;
using System.Security.Claims;

namespace soundcloud_.Controllers
{
    public class UserController : Controller
    {
        IUserRegister _UserRegister;
        IUserAuthenticate _UserAuthenticate;
        private readonly IWebHostEnvironment _webhostenviroment;

        public UserController(IWebHostEnvironment webhostenviroment,IUserRegister UserRegister, IUserAuthenticate UserAuthenticate)
        {
            _webhostenviroment = webhostenviroment;

            _UserRegister = UserRegister;
            _UserAuthenticate = UserAuthenticate;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> RegisterUser(Register user)
        {
            if (ModelState.IsValid)
            {
                if (user.Password==user.Password_2)
                {
                    UploadUserImage uplm = new UploadUserImage(_webhostenviroment);

                    Role r = new Role();
                    User u=new User();
                    u.id = user.id;
                    u.Name = user.Name;
                    u.Email = user.Email;
                    u.family = user.family;
                    u.Password = user.Password;
                    u.Roleid = 1;
                    r.RoleName = "User";
                  
                    u.UserPhoto = uplm.upload(user.UserPhoto);

                    var result = _UserRegister.AddUser(u);
                    ViewBag.res = result;
                    return View("RegisterUser");
                }

            }
            return View();
        }
      //  [Route("")] 
      //  [Route("/Login")]
        public IActionResult Login()
        {
            return View();
        }
      //  [Route("/Login")]

        [HttpPost]
        public IActionResult Login(LoginViewModel user)
        {
            var userinfo = _UserAuthenticate.Authenticate(user.UserName,user.Password);
            if (userinfo==null)
            {

            }
            else
            { 
                string userRole=UserRoles.User;
                if (userinfo.RoleId==2)
                {
                    userRole = UserRoles.Admin;
                }
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,userinfo.UserId.ToString()),
                    new Claim(ClaimTypes.Name,userinfo.name.ToString()+" "+ userinfo.family.ToString()),
              

                    new Claim(ClaimTypes.Role,userRole)

                };
                var identitity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identitity);
                var properties=new AuthenticationProperties() { 
                
                IsPersistent = true,
                ExpiresUtc = DateTime.Now.AddMinutes(45)
                
                
                };
                HttpContext.SignInAsync(principal, properties);
                ViewBag.Userinfo = userinfo;

                if (userRole== "admin")
                {
                    return RedirectToAction(nameof(Index), "Admin");

                }
                else if (userRole == "user")
                {
                    return RedirectToAction(nameof(Index), "UserPanel");

                }


            }
            return View();
        }



        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
