using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gruppo1_DAL;
using Gruppo1_Model;
using Gruppo1_Interfaces;

namespace Gruppo1
{
    public class ProductController : Controller
    {
        readonly IAdventureRepository _repository;
        public ProductController(IAdventureRepository repository)
        {
            _repository = repository;
        }
        // GET: AdventureController
        public ActionResult Index()
        {
            var model = _repository.GetListProducts();
            Console.WriteLine(model);
            return View(model);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var item = _repository.GetProductById(id);
            var category = _repository.GetCategoryById(item.ProductCategoryId);
            var model = _repository.GetModelById(item.ProductModelId);
            ViewBag.category = category.Name;
            ViewBag.model = model.Name;
            return View(item);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var categories = _repository.GetListCategories();
            var models = _repository.GetListModels();
            ViewBag.categories = categories;
            ViewBag.models = models;
            return View();
        }
        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product data)
        {
            if (ModelState.IsValid)
            {
                _repository.InsertProduct(data);
                return RedirectToAction(nameof(Index));
            }
            else
                return View();
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var categories = _repository.GetListCategories();
            var models = _repository.GetListModels();
            ViewBag.categories = categories;
            ViewBag.models = models;
            var item = _repository.GetProductById(id);
            Console.WriteLine("un item", item);
            return View(item);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product data)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateProduct(data);
                var categories = _repository.GetListCategories();
                var models = _repository.GetListModels();
                ViewBag.categories = categories;
                ViewBag.models = models;
                var item = _repository.GetProductById(id);
                return View(item);
            }
            else
            {
                Console.WriteLine("else");
                var categories = _repository.GetListCategories();
                var models = _repository.GetListModels();
                ViewBag.categories = categories;
                ViewBag.models = models;
                var item = _repository.GetProductById(id);
                return View(item);
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var item = _repository.GetProductById(id);
            var category = _repository.GetCategoryById(item.ProductCategoryId);
            var model = _repository.GetModelById(item.ProductModelId);
            ViewBag.category = category.Name;
            ViewBag.model = model.Name;
            return View(item);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _repository.DeleteProduct(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
