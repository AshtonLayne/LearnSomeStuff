using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnStuff.Core.Models;
using LearnStuff.Core.Contracts;
using LearnStuff.DataAccess.InMemory;

namespace LearnStuff.WebUI.Controllers
{
    public class CategoryManagerController : Controller
    {
        IRepository<ProductCategory> context;

        public CategoryManagerController(IRepository<ProductCategory> context)
        {
            this.context = context;
        }
        // GET: CategoryManager
        public ActionResult Index()
        {
            List<ProductCategory> categories = context.Collection().ToList();
            return View(categories);
        }

        public ActionResult Create()
        {
            ProductCategory pc = new ProductCategory();
            return View(pc);
        }

        [HttpPost]
        public ActionResult Create(ProductCategory pc)
        {
            if (!ModelState.IsValid)
            {
                return View(pc);
            }
            else
            {
                context.Insert(pc);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string ID)
        {
            ProductCategory categoryToEdit = context.Find(ID);

            if (categoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(categoryToEdit);
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory pc, string ID)
        {
            ProductCategory categoryToEdit = context.Find(ID);

            if (categoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(pc);
                }

                categoryToEdit.CategoryDescription = pc.CategoryDescription;
                
                context.Commit();

                return RedirectToAction("Index");
                
            }
        }

        public ActionResult Delete(string ID)
        {
            ProductCategory categoryToDelete = context.Find(ID);

            if (categoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(categoryToDelete);
            }
        }



        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string ID)
        {
            ProductCategory categoryToDelete = context.Find(ID);

            if (categoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(ID);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}