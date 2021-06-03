using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TakenplannerData.Services;
using TakenplannerData.Models;
using TakenplannerWeb.Models;
using TakenplannerWeb.Logic;
using System.IO;
using System.Configuration;

namespace TakenplannerWeb.Controllers
{
    public class ChoresController : Controller
    {
        private readonly IChoreData db;

        //TODO Implement Dependency Injection
        public ChoresController()
        {
            db = InMemoryChoreData.GetInstance();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new IndexViewModel();
            model.allChores = db.GetAll();
            choresLogic.CheckExpiredChores(model.allChores);
            choresLogic.CheckAlmostExpiredChores(model.allChores);
            model.expiredChores = model.allChores.Where(c => c.Expired == true).ToList();
            model.almostExpiredChores = model.allChores.Where(c => c.AlmostExpired == true).ToList();
            model.backlogChores = model.allChores.Where(c => c.Status == Status.Backlog);
            model.todoChores = model.allChores.Where(c => c.Status == Status.ToDo);
            model.doingChores = model.allChores.Where(c => c.Status == Status.Doing);
            model.doneChores = model.allChores.Where(c => c.Status == Status.Done);

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new Chore();
            model.StartDate = DateTime.Now;
            model.EndDate = DateTime.Now;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Chore chore)
        {
            if (ModelState.IsValid)
            {
                db.Add(chore);
                return RedirectToAction("Details", new { id = chore.Id });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Chore chore)
        {
            if (ModelState.IsValid)
            {
                db.Update(chore);
                TempData["Message"] = "You have saved the chore!";
                return RedirectToAction("Details", new { id = chore.Id });
            }
            return View(chore);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult NoteUpload(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NoteUpload(Chore chore)
        {
            if (ModelState.IsValid)
            {
                if (chore.UploadedFile != null)
                {
                    string FileName = Path.GetFileNameWithoutExtension(chore.UploadedFile.FileName);

                    string FileExtension = Path.GetExtension(chore.UploadedFile.FileName);

                    FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;

                    string UploadPath = ConfigurationManager.AppSettings["UserFilePath"].ToString();

                    chore.FilePath = UploadPath + FileName;

                    chore.UploadedFile.SaveAs(Server.MapPath(chore.FilePath)); 
                }

                db.UpdateNote(chore);
                return RedirectToAction("Details", new { id = chore.Id });
            }
            return View(chore);
        }
    }
}