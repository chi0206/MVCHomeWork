using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCHomeWork.Models;

namespace MVCHomeWork.Controllers
{
    public class 客戶資料對照表Controller : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        // GET: 客戶資料對照表
        public ActionResult Index()
        {
            return View(db.客戶資料對照表.ToList());
        }

        // GET: 客戶資料對照表/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料對照表 客戶資料對照表 = db.客戶資料對照表.Find(id);
            if (客戶資料對照表 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料對照表);
        }
    }
}
