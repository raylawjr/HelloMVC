using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloMVC.Controllers
{
    public class HelloController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            string html = "<form method ='post'>" +
                "<input type = 'text' name='name' />" +
                "<select id = 'langselect' name = 'langselect'>" +
                "<option value='english'> English </option>" +
                "<option value='french'> French </option>" +
                "<option value = 'spanish'>Spanish</option>"+
                "<option value='german'>German</option>"+
                "<option value='klingon'> Klingon </option>" +
                "</select>" +
                "<input type='submit' value='Greet me!' />" +
                "/<form>";

            //return Redirect("/Hello/Goodbye");
            return Content(html, "text/html");
        }
        [Route("/Hello")]
        [HttpPost]
        public IActionResult Display(string name = "World")
        {
            //           return Content(string.Format("<h1>Hello {0}", name), "text/html");
            string langselect = Request.Form["langselect"];
            return Content(string.Format(CreateMessage(name, langselect)), "text/html");
        }

        public static string CreateMessage(string thename, string thelang)
        {
            if (thelang.Equals("french")){
                return "<h1>Bonjour " + thename;
            }
            
            else
            {
                if (thelang.Equals("spanish"))
                {
                    return "<h1>Hola " + thename;
                }
                else
                {
                    if (thelang.Equals("german"))
                    {
                        return "<h1>Hallo " + thename;
                    }
                    else
                    {
                        if (thelang.Equals("klingon"))
                        {
                            return "<h1>nuqneH " + thename;
                        }
                        else
                        {
                            return "<h1>Hello " + thename;
                        }
                    }
                }
                
            }
        }
        // Handle requests to /Hello/NAME (URL segment)
        [Route("/Hello/{name}")]
        public IActionResult Index2(string name)
        {
            return Content(string.Format("<h1>Hello {0}</h1>", name), "text/html");
        }
        
        public IActionResult Goodbye()
        {
            return Content("Goodbye");
        }
    }
}
