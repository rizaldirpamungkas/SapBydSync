using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SapBydSync;

namespace SapBydSync.Controllers
{
    public class journalsController : Controller
    {
        private ByD_BackDbEntities db = new ByD_BackDbEntities();

        // GET: journals
        public ActionResult Index()
        {
            return View(db.journals.ToList());
        }

        // GET: journals/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            journal journal = db.journals.Find(id);
            if (journal == null)
            {
                return HttpNotFound();
            }
            return View(journal);
        }

        // GET: journals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: journals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "C_uid,jour_id,created_date,changed_date,debit_credit,fiscal_year,gl_acct,gl_acct_type,created_by,changed_by,comp_cur_amt,item_cur_amt,tran_cur_amt")] journal journal)
        {
            if (ModelState.IsValid)
            {
                db.journals.Add(journal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(journal);
        }

        // GET: journals/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            journal journal = db.journals.Find(id);
            if (journal == null)
            {
                return HttpNotFound();
            }
            return View(journal);
        }

        // POST: journals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "C_uid,jour_id,created_date,changed_date,debit_credit,fiscal_year,gl_acct,gl_acct_type,created_by,changed_by,comp_cur_amt,item_cur_amt,tran_cur_amt")] journal journal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(journal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(journal);
        }

        // GET: journals/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            journal journal = db.journals.Find(id);
            if (journal == null)
            {
                return HttpNotFound();
            }
            return View(journal);
        }

        // POST: journals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            journal journal = db.journals.Find(id);
            db.journals.Remove(journal);
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
