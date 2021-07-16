using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCHomeWork.Models;
using MVCHomeWork.ViewModels.客戶聯絡人;
using Omu.ValueInjecter;


namespace MVCHomeWork.Controllers
{
    public class 客戶聯絡人Controller : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        // GET: 客戶聯絡人
        public ActionResult Index(string searchString,string sortOrder)
        {
            ViewBag.searchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.職稱Sort = string.IsNullOrEmpty(sortOrder) ? "job_desc" : "";
            ViewBag.姓名Sort = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.手機Sort = string.IsNullOrEmpty(sortOrder) ? "mobile_desc" : "";
            ViewBag.電話Sort = string.IsNullOrEmpty(sortOrder) ? "phone_desc" : "";
            ViewBag.EmailSort = string.IsNullOrEmpty(sortOrder) ? "email_desc" : "";
            ViewBag.客戶名稱Sort = string.IsNullOrEmpty(sortOrder) ? "custName_desc" : "";
            

            var 客戶聯絡人 = db.客戶聯絡人.Include(客 => 客.客戶資料);
            if (!String.IsNullOrEmpty(searchString))
            {
                客戶聯絡人 = 客戶聯絡人.Where(p => p.姓名.Contains(searchString)
                            || p.職稱.Contains(searchString) || p.電話.Contains(searchString)
                            || p.手機.Contains(searchString) || p.Email.Contains(searchString)
                            || p.客戶資料.客戶名稱.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "job_desc":
                    客戶聯絡人 = 客戶聯絡人.OrderByDescending(客 => 客.職稱);
                    break;
                case "name_desc":
                    客戶聯絡人 = 客戶聯絡人.OrderByDescending(客 => 客.姓名);
                    break;
                case "mobile_desc":
                    客戶聯絡人 = 客戶聯絡人.OrderByDescending(客 => 客.手機);
                    break;
                case "phone_desc":
                    客戶聯絡人 = 客戶聯絡人.OrderByDescending(客 => 客.電話);
                    break;               
                case "email_desc":
                    客戶聯絡人 = 客戶聯絡人.OrderByDescending(客 => 客.Email);
                    break;
                case "custName_desc":
                    客戶聯絡人 = 客戶聯絡人.OrderByDescending(客 => 客.客戶資料.客戶名稱);
                    break;
                default:
                    客戶聯絡人 = 客戶聯絡人.OrderBy(客 => 客.姓名);
                    break;
            }

            return View(客戶聯絡人.ToList());
        }

        // GET: 客戶聯絡人/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱");
            return View();
        }

        // POST: 客戶聯絡人/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人CreateViewModel 客戶聯絡人Input)
        {
            客戶聯絡人 客戶聯絡人 = new 客戶聯絡人();

            if (ModelState.IsValid)
            {
                客戶聯絡人.InjectFrom(客戶聯絡人Input);
                客戶聯絡人.是否已刪除 = false;
                db.客戶聯絡人.Add(客戶聯絡人);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);

            return View(客戶聯絡人Input);
        }

        // GET: 客戶聯絡人/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            客戶聯絡人EditViewModel 客戶聯絡人ViewData = new 客戶聯絡人EditViewModel();
            客戶聯絡人ViewData.InjectFrom(客戶聯絡人);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人ViewData);
        }

        // POST: 客戶聯絡人/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人EditViewModel 客戶聯絡人Input)
        {
            客戶聯絡人 客戶聯絡人 = new 客戶聯絡人();

            if (ModelState.IsValid)
            {
                客戶聯絡人.InjectFrom(客戶聯絡人Input);
                客戶聯絡人.是否已刪除 = false;
                db.Entry(客戶聯絡人).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人Input);
        }

        // GET: 客戶聯絡人/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            客戶聯絡人.是否已刪除 = true;
            db.Entry(客戶聯絡人).State = EntityState.Modified;
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
