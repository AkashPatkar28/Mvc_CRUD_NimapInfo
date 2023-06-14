using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_CRUD_Nimap.Models;
using System.Data.Entity;

namespace Mvc_CRUD_Nimap.Controllers
{
    public class Class1Controller : Controller
    {
        ServicesContext db = new ServicesContext();
        // GET: Class1
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadData(int draw, int start, int length)
        {
            // Get the total count of records
            int totalRecords = db.Category.Count();

            // Filter and sort the data
            var data = db.Category.OrderBy(c => c.Id).Skip(start).Take(length).ToList();

            // Create the response object
            var response = new
            {
                draw = draw,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
                data = data.Select(c => new { Id = c.CategoryId, Name = c.CategoryName })
            };

            return Json(response, JsonRequestBehavior.AllowGet);
        }




        //Create
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(Product e)
        {
            if (ModelState.IsValid)
            {
                db.product.Add(e);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.CreateMessage = "<script>alert('Data Saved')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CreateMessage = "<script>alert('Data Not Saved')</script>";
                }
            }
            return View();
        }


        //EDIT
        public ActionResult Edit(int id)
        {
            var row = db.Category.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Class1 e)
        {
            db.Entry(e).State = EntityState.Modified;
            int a = db.SaveChanges();
            if (a > 0)
            {
                ViewBag.UpdateMessage = ("<script>alert('Data Saved')</script>");
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.UpdateMessage = ("<script>alert('Data Not modified')</script>");
            }
            return View();
        }


        //DELETE
        public ActionResult Delete(int id)
        {
            var row = db.Category.Where(model => model.Id== id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Delete(Class1 e)
        {
            db.Entry(e).State = EntityState.Deleted;
            int a = db.SaveChanges();
            if (a > 0)
            {
                ViewBag.DeleteMessage = ("<script>alert('Data Delted')</script>");
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.DeleteMessage = ("<script>alert('Data Not Deleted')</script>");
            }
            return View();

        }

    }
}