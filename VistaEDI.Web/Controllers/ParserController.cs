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
        public ActionResult Upload(HttpPostedFileBase file, char status = '1')
        {
            if (status != '0')
            {
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    BinaryReader b = new BinaryReader(file.InputStream);
                    byte[] binData = b.ReadBytes(file.ContentLength);
                    string result = System.Text.Encoding.UTF8.GetString(binData);

                    string message = new VistaParser().ParseJson(result, status);

                    if ((message != null) && (message != ""))
                    {
                        message = "Deviations: " + message;
                        ViewBag.Message = message;                     
                        ViewBag.Status = "Choose Status and file to Accept/Reject with deviation ";
                    }
                    else
                        ViewBag.Message = "File successfully uploaded";
                }
                else
                {
                    ViewBag.Message = "File not selected";
                }
            }
           else
                ViewBag.Message = "Upload Rejected";
            return View("Index");
        }
    }
}