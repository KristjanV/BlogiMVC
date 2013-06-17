using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication18.Models;

namespace MvcApplication18.Controllers
{ 
    public class AdminController : Controller
    {
        private BlogDBContext db = new BlogDBContext();

        //
        // GET: /Admin/

        public ViewResult Index()
        {
            return View(db.Blogs.ToList());
        }

        //
        // GET: /Admin/Details/5

        public ViewResult Details(int id)
        {
            Blog blog = db.Blogs.Find(id);
            return View(blog);
        }

        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Admin/Create

        [HttpPost]
        public ActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(blog);
        }
        
        //
        // GET: /Admin/Edit/5
 
        public ActionResult Edit(int id)
        {
            Blog blog = db.Blogs.Find(id);
            return View(blog);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        //
        // GET: /Admin/Delete/5
 
        public ActionResult Delete(int id)
        {
            Blog blog = db.Blogs.Find(id);
            return View(blog);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}