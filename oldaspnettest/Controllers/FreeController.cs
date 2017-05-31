using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace oldaspnettest.Controllers
{
    public class FreeController : Controller
    {
        // GET: Free
        public ActionResult Index()
        {
            return View();
        }

        // GET: Free/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Free/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Free/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Free/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Free/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Free/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Free/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
