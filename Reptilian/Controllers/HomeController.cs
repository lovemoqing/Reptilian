using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reptilian.Models;
using Reptilian.Tool;

namespace Reptilian.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetKeys(string path)
        {
            string html = HttpHelper.GetHtml(path);
            List<string> list = new List<string>();
            if (!string.IsNullOrWhiteSpace(html))
            {
                Regex rg = new Regex("<span>.*</span>");
                MatchCollection mc = rg.Matches(html);
                foreach (var item in mc)
                {
                    Console.WriteLine(item.ToString());
                    list.Add(item.ToString().Replace("<span>", "").Replace("</span>", ""));
                }
            }
            return Json(html)
        }
    }
}
