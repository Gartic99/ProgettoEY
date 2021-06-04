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
            return View();
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
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
