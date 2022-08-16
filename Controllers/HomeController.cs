using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TestMVCNetCore.Interfaces;
using TestMVCNetCore.Models;

namespace TestMVCNetCore.Controllers
{
    [Authorize]
    public class HomeController : BaseController  //Controller
    {
        private readonly IUserCompany _userCompany;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUserCompany userCompany)
        {
            _logger = logger;
            _userCompany = userCompany;
        }

        public IActionResult Index()
        {

            var identity = (ClaimsIdentity)User.Identity;

            string userId = string.Empty;
            //userId = HttpContext.Session.GetString("AspNetUser_Id");
            userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;


            int comp_Id = 0;
            //comp_Id = Convert.ToInt32(HttpContext.Session.GetInt32("Comp_Id"));
            var userComp = _userCompany.GetUserCompanybyAspNetUser_Id(userId);
            comp_Id = userComp.Comp_Id; // _userCompany.GetUserCompanybyAspNetUser_Id(userId).Comp_Id;

            string Comp_Name = string.Empty;
            //var company = _userCompany.GetListUsersCompany(comp_Id).FirstOrDefault();
            //Comp_Name = company.Comp_Name;


            string rolName = string.Empty;
            rolName = identity.FindFirst(ClaimTypes.Role).Value;
            string rolName_Temp = string.Empty;

            var userEmail = identity.FindFirst(ClaimTypes.Email).Value;


            //_logger.LogInformation("Index-HomeController-UserEmail : " + HttpContext.Session.GetString("UserEmail"));
            //_logger.LogInformation("Index-HomeController-AspNetUser_Id : " + HttpContext.Session.GetString("AspNetUser_Id"));
            //_logger.LogInformation("Index-HomeController-Comp_Name : " + HttpContext.Session.GetString("Comp_Name"));
            //_logger.LogInformation("Index-HomeController-Rol_Name : " + HttpContext.Session.GetString("Rol_Name"));
            //_logger.LogInformation("Index-HomeController-Comp_Id : " + Convert.ToInt32(HttpContext.Session.GetInt32("Comp_Id")).ToString());


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
