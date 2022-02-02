﻿using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public class ThreadController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: Thread
        public ActionResult Index(int ID)
        {
            List<Thread> threads = db.Thread.Where(t => t.ForumID == ID).ToList();
            
            if(threads.Count > 0)
            {
                ViewBag.threadID = threads.First().ThreadID;
            }

            return View(threads);
        }

        // GET: Thread/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Thread/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Thread/Create
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

        // GET: Thread/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Thread/Edit/5
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

        // GET: Thread/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Thread/Delete/5
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
