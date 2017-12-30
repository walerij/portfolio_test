using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using portfolio.Models;
using System.Net;
using System.IO;

namespace portfolio.Controllers
{
	
	//[MyRoleFliter]
	public class AdminWorksController : Controller
    {
        AdoContext db = new AdoContext();
        // GET: AdminWorks
        public ActionResult Index()
        {
            return View(db.Works.ToList());
        }

        public ActionResult Create()
        {
            List<SelectListItem> items = LoadItems();
            ViewBag.Topics = items;
            return View();
        }

        private List<SelectListItem> LoadItems()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (Topics top in db.Topics.ToList())
                items.Add(new SelectListItem { Text = top.title, Value = top.id.ToString() });
            return items;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Title, Info, Link, Topics_Id")] Works works)
        {
            if (ModelState.IsValid)
            {
                db.Works.Add(works);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<SelectListItem> items = LoadItems();
            ViewBag.Topics = items;
            return View();
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Works work = db.Works.Find(id);
            
            if (work == null)
                return HttpNotFound();
            return View(work);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "id,title,info,link,topics_id")] Works work)
        {
            if (ModelState.IsValid)
            {
                db.Entry(work).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","AdminWorks");
            }
            return View(work);
        }

        [HttpPost]
        public ActionResult AddPhoto(FormCollection formData,  int id)
        {
            
            HttpPostedFileBase file = null;
            try
            { 
                file = Request.Files[0];
            }
            catch { }
            Photos ph = new Photos() {
                work_id=id, link="", info=""
            };
            db.Photos.Add(ph);
            db.SaveChanges();
            //грузим фотку
            string fileName = System.IO.Path.GetFileName(file.FileName);//1
            string ex = System.IO.Path.GetExtension(file.FileName); //расширение

            string link_photos = "~/Images/" + ph.id + ex;


             file.SaveAs(Server.MapPath(link_photos));
            ph.link = Url.Content(link_photos);
            db.Entry(ph).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            //конец
            var allphotos = db.Photos.Where(p =>p.work_id==id).ToList();
            

           if (allphotos.Count <= 0)
            {
                return HttpNotFound();
            } 
            return PartialView(allphotos);

        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload, int id,  string submitButton)
        {
            Works work;
            work = db.Works.Find(id);
            if (submitButton != null)
            {
                string[] subArray = submitButton.Split('_');
                switch (subArray[0])
                {
                    case "MainPhoto":
                        MainPhoto(work, subArray);
                        break;
                    case "DeletePhoto":
                        DeletePhoto(subArray);

                        break;
                }
                
            }
            else if (upload != null) //если нажали Загрузить
            {
                AddNewPhoto(upload, id);//добавляем новое фото

            }
            
            return View("Details",work);
        }

        private void MainPhoto(Works work, string[] subArray)
        {
            Photos photo = db.Photos.Find(Int32.Parse(subArray[1])); // создаем экз фото
            work.link = photo.link; //передаем ссылку выбранного фото в работу
            db.Entry(work).State = System.Data.Entity.EntityState.Modified; //изменяем запись в БД с учетом изм модели
            db.SaveChanges(); //сохраняем изменения
        }

        private void AddNewPhoto(HttpPostedFileBase upload, int id)
        {
            //создаем экз нового фото
            Photos ph = new Photos()
            {
                work_id = id,
                link = "",
                info = ""
            };

            //добавляем экз в БД
            db.Photos.Add(ph);
            db.SaveChanges();

            //грузим фотку на сервер
            string fileName = System.IO.Path.GetFileName(upload.FileName);// путь к файлу на компе
            string ex = System.IO.Path.GetExtension(upload.FileName); //расширение

            string link_photos = "~/Images/" + ph.id + ex; //путь к файлу на сервере (по id)


            upload.SaveAs(Server.MapPath(link_photos)); //сохраняем фотку на сервере
            ph.link = Url.Content(link_photos); //записываем url фотки в модель
            db.Entry(ph).State = System.Data.Entity.EntityState.Modified; //изменяем запись в БД с учетом изм модели
            db.SaveChanges(); //снова сохраняем запись
            //конец
        }

        private void DeletePhoto(string[] subArray)
        {
            Photos photo = db.Photos.Find(Int32.Parse(subArray[1])); // создаем экз фото
            System.IO.File.Delete(Server.MapPath(photo.link)); //удаляем фотку по абс пути на сервере
            db.Photos.Remove(photo); //удаляем фотку из бд
            db.SaveChanges(); //сохраняем изменения
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Works work = db.Works.Find(id);

            if (work == null)
                return HttpNotFound();
            return View(work);
       
        }

      
        public ActionResult ViewPhoto(int id)
        {
            var allphotos = db.Photos.Where(p => p.work_id == id).ToList();
            
            return PartialView("AddPhoto",allphotos);

        }
    }
}