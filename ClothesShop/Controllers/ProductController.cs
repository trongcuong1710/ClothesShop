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
    public class ProductController : Controller
    {
        /// <summary>
        /// product service
        /// </summary>
        private IProductService productService;

        /// <summary>
        /// category service
        /// </summary>
        private ICategoryService categoryService;

        /// <summary>
        /// promotion service
        /// </summary>
        private IPromotionService promotionService;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="productService">
        /// will be populated by ninject
        /// </param>
        /// <param name="categoryService">
        /// will be populated by ninject
        /// </param>
        /// <param name="promotionService">
        /// will be populated by ninject
        /// </param>
        public ProductController(IProductService productService, ICategoryService categoryService, 
            IPromotionService promotionService) : base()
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.promotionService = promotionService;
        }

        //
        // GET: /Product/

        public ViewResult Index()
        {
            var product = this.productService.getProductViewModel();
            ViewBag.ProID = new SelectList(this.promotionService.getPromotion(), "ProID", "DisCount");
            return View(product.ToList());
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            ViewBag.CatID = new SelectList(this.categoryService.getChildCategory(), "CatID", "CatName");
            ViewBag.ProID = new SelectList(this.promotionService.getPromotion(), "ProID", "DisCount");
            return View();
        } 

        //
        // POST: /Product/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                this.productService.save(product);
                return RedirectToAction("Index");  
            }

            ViewBag.CatID = new SelectList(this.categoryService.getChildCategory(), "CatID", "CatName", product.CatID);
            ViewBag.ProID = new SelectList(this.promotionService.getPromotion(), "ProID", "DisCount", product.ProID);
            return View(product);
        }
        
        //
        // GET: /Product/Edit/5
 
        public ActionResult Edit(int id)
        {
            Product product = this.productService.getProduct(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.CatID = new SelectList(this.categoryService.getChildCategory(), "CatID", "CatName", product.CatID);
            ViewBag.ProID = new SelectList(this.promotionService.getPromotion(), "ProID", "DisCount", product.ProID);
            return View(product);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                this.productService.update(product);
                return RedirectToAction("Index");
            }
            ViewBag.CatID = new SelectList(this.categoryService.getChildCategory(), "CatID", "CatName", product.CatID);
            ViewBag.ProID = new SelectList(this.promotionService.getPromotion(), "ProID", "DisCount", product.ProID);
            return View(product);
        }

        //
        // POST: /Product/Edit

        [HttpPost]
        public ActionResult Edit(IEnumerable<ProductViewModel> products)
        {
            this.productService.update(products);
            return RedirectToAction("Index");
        }

        //
        // POST: /Product/Delete/5

        [HttpPost]
        public ActionResult Delete(IEnumerable<ProductViewModel> products)
        {            
            this.productService.delete(products.Where(product => product.IsDelete));

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //db.Dispose();
            base.Dispose(disposing);
        }
    }
}