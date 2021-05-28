using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TakenplannerData.Services;
using TakenplannerData.Models;
using TakenplannerWeb.Models;

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
            model.backlogChores = db.GetAll().Where(c => c.Status == Status.Backlog);
            model.todoChores = db.GetAll().Where(c => c.Status == Status.ToDo);
            model.doingChores = db.GetAll().Where(c => c.Status == Status.Doing);
            model.doneChores = db.GetAll().Where(c => c.Status == Status.Done);
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
            var chore = new Chore();
            return View(chore);
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
    }
}