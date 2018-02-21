using VistaEDI.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JsonParser.Web.Controllers
{
    public class ParserController : Controller
    {
        // GET: Parser
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                BinaryReader b = new BinaryReader(file.InputStream);
                byte[] binData = b.ReadBytes(file.ContentLength);
                string result = System.Text.Encoding.UTF8.GetString(binData);
                              
               string message =  new VistaParser().ParseJson(result);

                if (message != null)
                {
                    message = "Deviations: " + message;
                    ViewBag.Message = message;
                }                   
                else
                    ViewBag.Message = "File parsed successfully";
            }
            else
            {
                ViewBag.Message = "File not selected";
            }
            
            return View("Index");
        }
    }
}