using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestApp.BLL.Util;
using TestAppTP.Models;

namespace TestAppTP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUtilService _utilService;
        public HomeController(ILogger<HomeController> logger, IUtilService utilService)
        {
            _logger = logger;
            _utilService = utilService;
        }



        public IActionResult Index()
        {
            var requestStock = new RequestStockViewModel();
            try
            {

                var target = 80;// Minimo a tener en stock
                var itemCount = new List<int>  {10,20,30,40, 100};//valores de los contenedores

                var queryResult = _utilService.Restock(itemCount, target);
                if (queryResult > 0)
                {
                    if (queryResult > target)
                    {
                        requestStock.Message = ("Hay que revender " + queryResult + "unidades");
                    }
                    else
                    {
                        requestStock.Message = ("Falta por comprar " + queryResult + " para completar stock");
                    }
                }
            }
            catch (Exception ex)
            {
                requestStock.Message = ex.Message;
            }
            return View(requestStock);



        }

        [HttpGet]
        public IActionResult Test2()
        {            
            return View();
        }
        [HttpPost]
        public IActionResult Test2(StudentViewModel studentView)
        {
            var studentViewModel = new StudentViewModel();
            if (ModelState.IsValid)
            {
                var responseAverage = _utilService.ResponseNotes(studentView);
                studentViewModel.Message = "Promedio de las notas del estudiante es: " + responseAverage;
            }
            TempData["Message"] = studentViewModel.Message;
            return View();

            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
