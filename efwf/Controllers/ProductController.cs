using DBMS_CW_last.Repo;
using DBSD_CW2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DBMS_CW_last.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepo  _productsRepo;


        public ProductController(IProductsRepo prodRepo)
        {
            _productsRepo = prodRepo;
        }


        // GET: ProductController
        public ActionResult Index(string name, string description, decimal price, bool onSale, DateTime expirationDate, byte imageData, int? page )
        {
            var list = _productsRepo.GetAll();

            return View(list);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public async Task<IActionResult> Create(Product prod)
        {
            try
            {
                IFormFile photoFile = null;
                if (prod.ImageData != null)
                {
                    using (var memory = new MemoryStream())
                    {
                        await prod.ImageData.CopyToAsync(memory);
                        photoFile = new FormFile(memory, 0, memory.Length, null, prod.ImageData.FileName);
                    }
                }


                var product = new Product()
                {
                    Name = prod.Name,
                    Description = prod.Description,
                    Price = prod.Price,
                    OnSale = prod.OnSale,
                    ExpirationDate = prod.ExpirationDate,
                    ImageData = photoFile
                };


                _productsRepo.Insert(product);
                return View();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
