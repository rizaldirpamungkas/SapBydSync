using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SapBydSync;
using SapBydSync.Miscs;

namespace SapBydSync.Controllers
{
    public class genLedgerController : Controller
    {
        private ByD_BackDbEntities db = new ByD_BackDbEntities();

        // GET: genLedger
        public ActionResult Index()
        {
            var gen_ledger = db.gen_ledger.Include(g => g.journal);
            return View(gen_ledger.ToList());
        }

        // GET: genLedger/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gen_ledger gen_ledger = db.gen_ledger.Find(id);
            if (gen_ledger == null)
            {
                return HttpNotFound();
            }
            return View(gen_ledger);
        }

        // GET: genLedger/Create
        public ActionResult Create()
        {
            ViewBag.jour_id = new SelectList(db.journals, "jour_id", "C_uid");
            return View();
        }

        public ActionResult Synchronize()
        {
            using (var client = new HttpClient())
            {
                Parameter param = new Parameter();

                var byteArray = Encoding.ASCII.GetBytes(param.securityAPI["Username"]+":"+ param.securityAPI["Password"]);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                //HTTP GET
                var responseTask = client.GetAsync(param.uriAPI["GeneralLedger"]);
                responseTask.Wait();

                var result = responseTask.Result;

                var message = result.Content.ReadAsStringAsync();
                message.Wait();

                ViewBag.JSON = message.Result;

                /*if (result.IsSuccessStatusCode)
                {
                    ViewBag.JSON = "{}";
                }
                else //web api sent error response 
                {
                    //log response status here..
                    ViewBag.JSON = "404";

                }*/
            }

            return View();
        }

        // POST: genLedger/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "created_date,changed_date,jour_id,jour_item_id,jour_type,bus_part_addr,chart_of_act,cus_code1,cus_code2,cus_code3,debit_credit,employee_id,fiscal_year,gl_acct,gl_acct_type,post_date,prod_id,comp_cur_amt,item_cur_amt,tran_cur_amt,val_qty_unt,C_uid")] gen_ledger gen_ledger)
        {
            if (ModelState.IsValid)
            {
                db.gen_ledger.Add(gen_ledger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.jour_id = new SelectList(db.journals, "jour_id", "C_uid", gen_ledger.jour_id);
            return View(gen_ledger);
        }

        // GET: genLedger/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gen_ledger gen_ledger = db.gen_ledger.Find(id);
            if (gen_ledger == null)
            {
                return HttpNotFound();
            }
            ViewBag.jour_id = new SelectList(db.journals, "jour_id", "C_uid", gen_ledger.jour_id);
            return View(gen_ledger);
        }

        // POST: genLedger/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "created_date,changed_date,jour_id,jour_item_id,jour_type,bus_part_addr,chart_of_act,cus_code1,cus_code2,cus_code3,debit_credit,employee_id,fiscal_year,gl_acct,gl_acct_type,post_date,prod_id,comp_cur_amt,item_cur_amt,tran_cur_amt,val_qty_unt,C_uid")] gen_ledger gen_ledger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gen_ledger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.jour_id = new SelectList(db.journals, "jour_id", "C_uid", gen_ledger.jour_id);
            return View(gen_ledger);
        }

        // GET: genLedger/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gen_ledger gen_ledger = db.gen_ledger.Find(id);
            if (gen_ledger == null)
            {
                return HttpNotFound();
            }
            return View(gen_ledger);
        }

        // POST: genLedger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            gen_ledger gen_ledger = db.gen_ledger.Find(id);
            db.gen_ledger.Remove(gen_ledger);
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
