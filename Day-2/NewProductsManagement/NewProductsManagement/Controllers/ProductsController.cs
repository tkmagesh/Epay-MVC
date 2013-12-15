using NewProductsManagement.Models.ViewModels;
using NewProductsManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewProductsManagement.Controllers
{
    public class ProductsController : Controller
    {
        //
        // GET: /Products/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Products/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Products/Create
        [HttpGet]
        public ActionResult Create()
        {
            var context = new ProductsManagementContext();
            var model = new CreateProductVM
            {
                Product = new Product(),
                Products = context.Products.ToList()
                
            };
            ViewBag.Categories = context.Categories.ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Product product) {
            var context = new ProductsManagementContext();
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Create");
        }

        
        //
        // GET: /Products/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Products/Edit/5

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

        //
        // GET: /Products/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Products/Delete/5

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
