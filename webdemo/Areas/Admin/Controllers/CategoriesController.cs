using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webdemo.Areas.Admin.Models;

namespace webdemo.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Admin/Categories
        AdminC db = new AdminC();
        public ActionResult Index(string _name)
        {   
            if (_name == null)
                return View(db.Categories.ToList());
            return View(db.Categories.Where(s=> s.NameCate.Contains(_name)).ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category cate)
        {
            try
            {
                db.Categories.Add(cate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }catch
            {
                return Content("Error Create New");
            }    
        }

        public ActionResult Details(int id) { 
            return View(db.Categories.Where(s=>s.Id == id).FirstOrDefault());
        }

        public ActionResult Edit(int id)
        {
            return View(db.Categories.Where(s => s.Id == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, Category cate)
        {
            db.Entry(cate).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(db.Categories.Where(s => s.Id == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, Category cate)
        {
            try
            {
                cate = db.Categories.Where(s => s.Id == id).FirstOrDefault();
                db.Categories.Remove(cate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("This data is using in other table, Eror Delete!");
            }
        }
    }
}