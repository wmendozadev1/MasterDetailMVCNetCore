using TestMVCNetCore.Extension;
using TestMVCNetCore.Interfaces;
using TestMVCNetCore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TestMVCNetCore.Controllers
{
    
    public class AccountController : BaseController
    {
    

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUserCompany _userCompany;
        private readonly ICompany _companyRepo;
        private readonly ILogger<AccountController> _logger;


        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IUserCompany userCompany, ICompany companyRepo,ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userCompany = userCompany;
            _companyRepo = companyRepo;
            _logger = logger;
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email

                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                   

                    //add role here
                    //await _userManager.AddToRoleAsync(user, "Admin");
                    return RedirectToAction("RegisterSuccess", "Account");
                }
            }
            ModelState.AddModelError("", "Invalid Register.");
            return View(model);
        }

        public IActionResult Login()
        {
            //PopulateViewbags();

            return View();
        }

     

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)  //,CompanyLoginViewModel companyLoginViewModel
        {
            if (ModelState.IsValid)
            {
                //var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);
                if(true) //(result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.Email);

                    UserCompany userCompa = _userCompany.GetUserCompanybyAspNetUser_Id(user.Id.ToString());
                    Company companyEntity = _companyRepo.GetItem(userCompa.Comp_Id);

                    //get UserRoles

                    ///check if the user currently has any roles
                    var currentRoles = await this._userManager.GetRolesAsync(user);
                       var currentRol_Name = currentRoles.FirstOrDefault();



                    //set variables session 
                    //HttpContext.Session.SetString("UserEmail", user.Email);
                    //HttpContext.Session.SetString("AspNetUser_Id", user.Id.ToString());
                    //HttpContext.Session.SetString("Comp_Name", companyEntity.Comp_Name);
                    //HttpContext.Session.SetInt32("Comp_Id", userCompa.Comp_Id);
                    //HttpContext.Session.SetString("Rol_Name", currentRol_Name);

                    //var principal = new ClaimsPrincipal();
                    //var claimUserEmail = new Claim("UserEmail", user.Email);
                    //var claimAspNetUser_Id = new Claim("AspNetUser_Id", user.Id.ToString());
                    //var claimComp_Name = new Claim("Comp_Name", companyEntity.Comp_Name);
                    //var claimComp_Id = new Claim("Comp_Id", userCompa.Comp_Id.ToString());
                    //var claimRol_Name = new Claim("Rol_Name", currentRol_Name);

                    //var claimUserEmail = new Claim(CustomClaim.Email, user.Email);
                    //var claimAspNetUser_Id = new Claim(CustomClaim.AspNetUser_Id, user.Id.ToString());
                    //var claimComp_Name = new Claim(CustomClaim.Comp_Name, companyEntity.Comp_Name);
                    //var claimComp_Id = new Claim(CustomClaim.Comp_Id, userCompa.Comp_Id.ToString());
                    //var claimRol_Name = new Claim(CustomClaim.Rol_Name, currentRol_Name);

                    //var claim = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    //claim.AddClaim(claimUserEmail);
                    //claim.AddClaim(claimAspNetUser_Id);
                    //claim.AddClaim(claimComp_Name);
                    //claim.AddClaim(claimComp_Id);
                    //claim.AddClaim(claimRol_Name);

                    //principal.AddIdentity(claim);

                    //await HttpContext.SignInAsync(principal);
                    //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


                    var principal = new ClaimsPrincipal();

                    var claims = new ClaimsIdentity(new Claim[]
                    {
                      new Claim(ClaimTypes.Name, user.Email),
                      new Claim(ClaimTypes.Role, currentRol_Name),
                      new Claim("AspNetUser_Id", user.Id.ToString()),
                      new Claim("Comp_Id",userCompa.Comp_Id.ToString()),
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                    principal.AddIdentity(claims);
                    await HttpContext.SignInAsync(principal);


                    //_logger.LogInformation("UserEmail : " + HttpContext.Session.GetString("UserEmail"));
                    //_logger.LogInformation("AspNetUser_Id : " + HttpContext.Session.GetString("AspNetUser_Id"));
                    //_logger.LogInformation("Comp_Name : " + HttpContext.Session.GetString("Comp_Name"));
                    //_logger.LogInformation("Rol_Name : " + HttpContext.Session.GetString("Rol_Name"));
                    //_logger.LogInformation("Comp_Id : " + Convert.ToInt32(HttpContext.Session.GetInt32("Comp_Id")).ToString());


                    return RedirectToAction("Index", "Home");

                }
            }
            ModelState.AddModelError("", "ID Invalido o Contraseña");
            return View(model);
        }

        public ActionResult RegisterSuccess()
        {
            return View();
        }

        public ActionResult LoginSuccess()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }


        public  IActionResult Logout()
        {
            HttpContext.Session.Clear();
             HttpContext.SignOutAsync();
             _signInManager.SignOutAsync();
           
            return RedirectToAction("Index", "Home");
        }


    }
}
