using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcRES2019.Models;

namespace mvcRES2019.Controllers
{
    public class ContractsController : Controller
    {
        private REContext db = new REContext();

        // GET: Contracts
        public ActionResult Index(string currentFilter,string firstName = "", string lastName = "")
        {
            var contracts = db.Contracts.Include(c => c.Agents).Include(c => c.Customers).Include(c => c.Images);
            if (!String.IsNullOrEmpty(firstName) && !String.IsNullOrEmpty(lastName))
            {
                contracts = contracts.Where(p => p.Customers.FirstName.ToLower().Contains(firstName.ToLower()));
                contracts = contracts.Where(p => p.Customers.LastName.ToLower().Contains(lastName.ToLower()));
            }
            ViewBag.CurrentFilter = firstName;
            ViewBag.CurrentFilter = lastName;
            return View(contracts.ToList());
        }

        public ActionResult Populate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract  = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // GET: Contracts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // GET: Contracts/Create
        public ActionResult Create()
        {
            ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "FirstName");
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName");
            ViewBag.ImageID = new SelectList(db.Images, "ImageID", "Title");
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AgentID,CustomerID,StartDate,EndDate,Country,Province,Municipality,Area,PostalCode,NumBeds,NumBaths,SquareFootage,TypeOfHeating,Price,Summary,ImageID,Signed")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Contracts.Add(contract);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "SIN", contract.AgentID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", contract.CustomerID);
            ViewBag.ImageID = new SelectList(db.Images, "ImageID", "Title", contract.ImageID);
            return View(contract);
        }

        // GET: Contracts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "SIN", contract.AgentID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", contract.CustomerID);
            ViewBag.ImageID = new SelectList(db.Images, "ImageID", "Title", contract.ImageID);
            return View(contract);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AgentID,CustomerID,StartDate,EndDate,Country,Province,Municipality,Area,PostalCode,NumBeds,NumBaths,SquareFootage,TypeOfHeating,Price,Summary,ImageID,Signed")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "SIN", contract.AgentID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", contract.CustomerID);
            ViewBag.ImageID = new SelectList(db.Images, "ImageID", "Title", contract.ImageID);
            return View(contract);
        }

        // GET: Contracts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contract contract = db.Contracts.Find(id);
            db.Contracts.Remove(contract);
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
