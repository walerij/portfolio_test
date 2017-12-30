using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace portfolio.Controllers
{
    public class UploadFileController : Controller
    {
        // GET: UploadFile
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                string fileName = System.IO.Path.GetFileName(upload.FileName);//1
                string ex = System.IO.Path.GetExtension(upload.FileName); //расширение


                upload.SaveAs(Server.MapPath("~/ImagTest/11" + fileName));

                ViewBag.FilePath = Url.Content("~/ImagTest/11" + fileName.ToString());
                //ссылка на наш ресурс
                //имя файла Photo_Id.<ext>
             


            }
            return View("Index");
        }
    }
}