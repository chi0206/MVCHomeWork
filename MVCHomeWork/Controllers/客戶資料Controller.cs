using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCHomeWork.Models;
using MVCHomeWork.ViewModels.客戶資料;
using Omu.ValueInjecter;

namespace MVCHomeWork.Controllers
{
    public class 客戶資料Controller : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        // GET: 客戶資料　
        public ActionResult Index(string searchString , string sortOrder)
        {
            ViewBag.searchString = string.IsNullOrEmpty(searchString) ? "" : searchString;
            ViewBag.客戶名稱Sort = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.統一編號Sort = string.IsNullOrEmpty(sortOrder) ? "uniNum_desc" : "";
            ViewBag.電話Sort = string.IsNullOrEmpty(sortOrder) ? "phone_desc" : "";
            ViewBag.傳真Sort = string.IsNullOrEmpty(sortOrder) ? "fax_desc" : "";
            ViewBag.地址Sort = string.IsNullOrEmpty(sortOrder) ? "address_desc" : "";
            ViewBag.EmailSort = string.IsNullOrEmpty(sortOrder) ? "email_desc" : "";

            var 客戶資料 = from m in db.客戶資料
                           where m.是否已刪除 == false
                           select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                客戶資料 = 客戶資料.Where(p => p.客戶名稱.Contains(searchString)
                            || p.統一編號.Contains(searchString) || p.電話.Contains(searchString)
                            || p.傳真.Contains(searchString) || p.地址.Contains(searchString)
                            || p.Email.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    客戶資料 = 客戶資料.OrderByDescending(客 => 客.客戶名稱);
                    break;
                case "uniNum_desc":
                    客戶資料 = 客戶資料.OrderByDescending(客 => 客.統一編號);
                    break;
                case "phone_desc":
                    客戶資料 = 客戶資料.OrderByDescending(客 => 客.電話);
                    break;
                case "fax_desc":
                    客戶資料 = 客戶資料.OrderByDescending(客 => 客.傳真);
                    break;
                case "address_desc":
                    客戶資料 = 客戶資料.OrderByDescending(客 => 客.地址);
                    break;
                case "email_desc":
                    客戶資料 = 客戶資料.OrderByDescending(客 => 客.Email);
                    break;
                default:
                    客戶資料 = 客戶資料.OrderBy(客 => 客.客戶名稱);
                    break;
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 客戶資料/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料CreateViewModel 客戶資料Input)
        {
            if (ModelState.IsValid)
            {
                客戶資料 客戶資料 = new 客戶資料();
                客戶資料.InjectFrom(客戶資料Input);
                客戶資料.是否已刪除 = false;

                db.客戶資料.Add(客戶資料);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(客戶資料Input);
        }

        // GET: 客戶資料/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            客戶資料EditViewModel 客戶資料ViewData = new 客戶資料EditViewModel();
            客戶資料ViewData.InjectFrom(客戶資料);

            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料ViewData);
        }

        // POST: 客戶資料/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料EditViewModel 客戶資料Input)
        {
            if (ModelState.IsValid)
            {
                客戶資料 客戶資料 = new 客戶資料();
                客戶資料.InjectFrom(客戶資料Input);
                客戶資料.是否已刪除 = false;
                db.Entry(客戶資料).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(客戶資料Input);
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            客戶資料.是否已刪除 = true;
            db.Entry(客戶資料).State = EntityState.Modified;
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
