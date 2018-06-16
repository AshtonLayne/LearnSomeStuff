﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnStuff.Core.Models;
using LearnStuff.DataAccess.InMemory;
using LearnStuff.Core.ViewModels;

namespace LearnStuff.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        ProductCache context;
        CategoryCache productCategories;

        public ProductManagerController()
        {
            context = new ProductCache();
            productCategories = new CategoryCache();
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            ProductManagerViewModel viewModel = new ProductManagerViewModel();
            viewModel.Product = new Product();
            viewModel.ProductCategories = productCategories.Collection();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create (Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                context.Insert(product);
                context.CommitToMemory();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit (string ID)
        {
            Product productToEdit = context.Find(ID);

            if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductManagerViewModel viewModel = new ProductManagerViewModel();
                viewModel.Product = productToEdit;
                viewModel.ProductCategories = productCategories.Collection();
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit (Product product, string ID)
        {
            Product productToEdit = context.Find(ID);

            if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }

                productToEdit.Category = product.Category;
                productToEdit.ProductDesc = product.ProductDesc;
                productToEdit.Image = product.Image;
                productToEdit.ProductName = product.ProductName;
                productToEdit.Price = product.Price;

                context.CommitToMemory();

                return RedirectToAction("Index");


            }
        }

        public ActionResult Delete(string ID)
        {
            Product productToDelete = context.Find(ID);

            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productToDelete);
            }
        }



        [HttpPost]
        [ActionName ("Delete")]
        public ActionResult ConfirmDelete (Product product, string ID)
        {
            Product productToDelete = context.Find(ID);

            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(ID);
                context.CommitToMemory();
                return RedirectToAction("Index");
            }
        }
 
    }
}