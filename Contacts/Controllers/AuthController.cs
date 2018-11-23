using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Contacts.Models;
using Contacts.Services;
using Contacts.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="model">Данные для входа</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.FindUser(model.Email, model.Password);
                if (user != null)
                {
                    await Authenticate(user);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="model">Данные для регистрации</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var isExist = await _userService.IsUserFoundByEmail(model.Email);
                if (!isExist)
                {
                    var newUser = new User {Email = model.Email, Password = model.Password};
                    await _userService.InsertUser(newUser);   

                    await Authenticate(newUser);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Пользователь с таким e-mail уже существует");
            }
            return View(model);
        }

        /// <summary>
        /// Аутентификация
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        private async Task Authenticate(User user)
        {
            //TODO Сделать через Identity
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim("userId", user.Id.ToString())
            };
            // Создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // Установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        /// <summary>
        /// Выход из системы
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }
    }
}