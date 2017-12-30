using portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace portfolio.Controllers
{
    public class HomeController : Controller
    {
        private AdoContext db = new AdoContext();
        // GET: Home
        public ActionResult Index()
        {
           IEnumerable<Works> works = db.Works.OrderByDescending(w=>w.id).Take(8).ToList();
            
            return View(works);
        }

		
		public ActionResult Works(int? id)
        {
            IEnumerable<Topics> topics = db.Topics.ToList();
            if (id == null)
                ViewBag.TopId = 1;
            else
                ViewBag.TopId = id;
            return View(topics);
        }

		public ActionResult LogOn()
		{
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		public ActionResult LogOn(string returnUrl)
		{

			return View();
		}

		public ActionResult Price()
        {
            return View();
        }




        public ActionResult Contacts()
        {
            return View(db.Contacts.ToList());
        }


        public ActionResult ViewWork(int? id)
        {
            Works work;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            work = db.Works.Find(id);
            if (work == null)
                return HttpNotFound();
            return View(work);



        }


		
		public ActionResult ReturnPictureForPart(int id)
		{
			Photos ph = db.Photos.FirstOrDefault(photo => photo.id==id);
			if (ph!=null )
     			return PartialView("ViewPicturePart",ph);
			return HttpNotFound();
		}

		
		public ActionResult MyAdmin()
		{			
			return PartialView("_AdminMenuRight");		
		}

		/// <summary>
		/// df
		/// </summary>
		/// <returns></returns>
		public ActionResult Loginos()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Loginos(Users users)
		{
			if (ModelState.IsValid)
			{
				if (db.Users.Any(u => u.login == users.login && u.passw == users.passw))
				{
					ViewBag.login = "Вы зареганы как " + users.login;
				}
				else
					ViewBag.login = "Неверный логин или пароль";
				/*Users dbusers = db.Users.FirstOrDefault(u => u.login == users.login);
				if (dbusers != null && dbusers.passw == users.passw)
					ViewBag.login = "Вы зареганы как " + users.login;
				else
					ViewBag.login = "Неверный логин или пароль";

				 тоже рабочий запрос
				 */
				return View();
			}
			else
				return View(users);
		}

		[ChildActionOnly]
        public ActionResult ReturnPartial(int? id)
        {
            IEnumerable<Works> works;
            if (id == null)
            {
                works=db.Works.Where(top => top.topics_id == 1);
            }
            else
                works = db.Works.Where(top=>top.topics_id==id);
            return PartialView("ReturnPartial", works);
        }


    }
}