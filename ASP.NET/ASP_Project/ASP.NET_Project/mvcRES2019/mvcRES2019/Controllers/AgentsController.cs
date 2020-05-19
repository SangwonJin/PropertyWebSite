using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcRES2019.Models;
using System.Web.Security;
using System.Drawing.Imaging;
using System.IO;

namespace mvcRES2019.Controllers
{
    public class AgentsController : Controller
    {
        private REContext db = new REContext();

        // GET: Agents
        public ActionResult Index()
        {
            return View(db.Agents.ToList());
        }

        [HttpPost]
        public ActionResult Register(Agent account)
        {
            if (ModelState.IsValid)
            {
                using (REContext db = new REContext())
                {
                    db.Agents.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + " successfully registered.";
            }
            return View();

        }

        public ActionResult AddImage(Agent model, HttpPostedFileBase image1)
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

            db.Agents.Add(model);
            db.SaveChanges();

            return RedirectToAction("Index");
        }



        //public ActionResult LoggedIn()
        //{
        //    if (Session["AgentID"] != null)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index");
        //    }
        //}

        // GET: Agents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agent agent = db.Agents.Find(id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        // GET: Agents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AgentID,SIN,FirstName,LastName,MiddleName,UserName,Password,Municipality,Province,Country,PostalCode,CellPhoneNumber,BirthDay,OfficePhoneNumber,HomePhoneNumber,Email")] Agent agent)
        {
            if (ModelState.IsValid)
            {
                db.Agents.Add(agent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agent);
        }

        // GET: Agents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agent agent = db.Agents.Find(id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        // POST: Agents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AgentID,SIN,FirstName,LastName,MiddleName,UserName,Password,Municipality,Province,Country,PostalCode,CellPhoneNumber,BirthDay,OfficePhoneNumber,HomePhoneNumber,Email")] Agent agent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agent);
        }

        // GET: Agents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agent agent = db.Agents.Find(id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        // POST: Agents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agent agent = db.Agents.Find(id);
            db.Agents.Remove(agent);
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
