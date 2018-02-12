using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace quoting_dojo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes(){
            List<Dictionary<string, object>> AllQuotes = DbConnector.Query("Select * From quotes;");
            ViewBag.quotes=AllQuotes;
            return View("Quotes");
        }

        [HttpPost]
        [Route("process")]
        public IActionResult Method(string Name,string Quote){
            DateTime date=DateTime.Now;
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$"+date);
            DbConnector.Query($"INSERT INTO quotes (name,quote,created_at) VALUES ('{Name}','{Quote}','{date}');");
            return RedirectToAction("Quotes");
        }

        
    }
}
