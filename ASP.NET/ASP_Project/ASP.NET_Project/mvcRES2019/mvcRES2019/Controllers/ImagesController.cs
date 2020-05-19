using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcRES2019.Models;

namespace mvcRES2019.Controllers
{
    public class ImagesController : Controller
    {
        private REContext db = new REContext();

        // GET: Images
        public ActionResult Index()
        {
            return View(db.Images.ToList());
        }

        public ActionResult AddImage()
        {
            Image i1 = new Image();
            return View(i1);
        }
        [HttpPost]
        public ActionResult AddImage(Image model, HttpPostedFileBase image1)
        {
            var db = new REContext();
            if (image1 != null)
            {
                model.ImagePath = new byte[image1.ContentLength];
                image1.InputStream.Read(model.ImagePath, 0, image1.ContentLength);


                string fileName = Path.GetFileName(image1.FileName);
                string filePath = Path.Combine(Server.MapPath("~/tempImages"), fileName);
                image1.SaveAs(filePath);
                model.ImagePath = System.IO.File.ReadAllBytes(filePath);
                    System.Drawing.Image img = System.Drawing.Image.FromStream(image1.InputStream);

                    if (ImageFormat.Jpeg.Equals(img.RawFormat))
                    {
                        ViewBag.type = "That was a jpeg file.";
                    }
                    else if (ImageFormat.Gif.Equals(img.RawFormat))
                    {
                        ViewBag.type = "That was a gif file.";

                    }
                    else if (ImageFormat.Bmp.Equals(img.RawFormat))
                    {
                        ViewBag.type = "That was a bmp file.";
                    }
                    else if (ImageFormat.Png.Equals(img.RawFormat))
                    {
                        ViewBag.type = "png file";
                    }
                    else if (ImageFormat.Tiff.Equals(img.RawFormat))
                    {
                        ViewBag.type = "Tiff file";
                    }
                    else
                    {
                        ViewBag.Msg = "Not a valid image type";
                    }
                    image1.SaveAs(filePath);
                    ViewBag.Msg = "Uploaded File Save Successfully";
                
            }
           
            db.Images.Add(model);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Images/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // GET: Images/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Images/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImageID,ImagePath,Title")] Image image)
        {
            if (ModelState.IsValid)
            {
                db.Images.Add(image);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(image);
        }

        // GET: Images/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // POST: Images/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImageID,ImagePath,Title")] Image image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(image).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(image);
        }

        // GET: Images/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Image image = db.Images.Find(id);
            db.Images.Remove(image);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
