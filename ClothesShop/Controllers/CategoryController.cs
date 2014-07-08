using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothesShop.Models;
using ClothesShop.Services.Interface;
using ClothesShop.ViewModel;

namespace ClothesShop.Controllers
{ 
    public class CategoryController : Controller
    {
        /// <summary>
        /// category service
        /// </summary>
        private ICategoryService service;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="service">
        /// will be populated by ninject
        /// </param>
        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }

        //
        // GET: /Category/

        public ActionResult Index()
        {
            var categories = this.service.getDeletingCategory();
            //return View(category.ToList());

            if (Request.IsAjaxRequest())
            {
                return PartialView(categories);
            }
            else
            {
                return View(categories);
            }
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            ViewBag.ParentID = new SelectList(this.service.getCategory(), "CatID", "CatName");
            return View();
        } 

        //
        // POST: /Category/Create

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                this.service.save(category);
                return RedirectToAction("Index");  
            }

            ViewBag.SelectList = new SelectList(this.service.getCategory(), "CatID", "CatName", category.ParentID);
            return View(category);
        }
        
        //
        // GET: /Category/Edit/5
 
        public ActionResult Edit(int id)
        {
            Category category = this.service.getCategory(id);
            ViewBag.SelectList = new SelectList(this.service.getCategory(), "CatID", "CatName", category.ParentID);
            return View(category);
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                this.service.update(category);
                return RedirectToAction("Index");
            }
            ViewBag.SelectList = new SelectList(this.service.getCategory(), "CatID", "CatName", category.ParentID);
            return View(category);
        }

        //
        // POST: /Category/Delete/5

        [HttpPost]
        public ActionResult Delete(IEnumerable<DeletingCategory> categories)
        {
            IEnumerable<DeletingCategory> deleted = categories.Where(x => x.IsDelete);
            this.service.delete(deleted);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //db.Dispose();
            base.Dispose(disposing);
        }
    }
}