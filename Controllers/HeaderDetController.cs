using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMVCNetCore.Context;
using TestMVCNetCore.Models;

namespace TestMVCNetCore.Controllers
{
    public class HeaderDetController : Controller
    {

        private readonly TestMVCNetCoreContext _context;

        public HeaderDetController(TestMVCNetCoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            List<Header> headerList = new List<Header>();
            headerList = _context.Header.ToList();

            return View(headerList);
        }

        public IActionResult Create()
        {
            Header item = new Header();

            ListTypeOption();

            item.Header_Detail.Add(new Header_Detail() { Header_Detail_Id = 1 });

            return View(item);
        }


        private List<TypeOption> ListTypeOption()
        {

            List<TypeOption> typeOptionList = new List<TypeOption>();

            typeOptionList = _context.TypeOption.OrderBy(a => a.TypOpt_Name).ToList();

            typeOptionList.Insert(0, new TypeOption { TypOption_Id = 0, TypOpt_Name = "----Seleccione----" });

            ViewBag.ListTypeOption = typeOptionList;

            return typeOptionList;
        }


        [HttpPost]
        public IActionResult Create(Header header) 
        {
            bool result = false;
            string errMessage = "";

            try
            {

                if (errMessage == "")
                {

                    _context.Header.Add(header);
                    var registro = _context.SaveChanges();

                    if (header.Header_Id > 0)
                    {
                        foreach (Header_Detail det in header.Header_Detail)
                        {
                            det.Header_Id = header.Header_Id;
                        }
                    }
                    
                    _context.Header.Attach(header);
                    _context.Entry(header).State = EntityState.Modified;
                    _context.SaveChanges();


                    result = true;


                }
            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message;
            }
            if (result == false)
            {
                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                //ListTypeOption();
                return View(header);

                
            }
            else
            {
                TempData["SuccessMessage"] = "Guardado exitosamente.";

                return RedirectToAction(nameof(Index));

            }
        }

        [HttpPost]
        public JsonResult  calculateJson( float numberValue)
        {
            float numberCalculated = 0;

            numberCalculated = numberValue * numberValue;

            return Json(numberCalculated);
        }

    }
}
