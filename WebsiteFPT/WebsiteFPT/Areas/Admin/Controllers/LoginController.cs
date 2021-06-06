using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebsiteFPT.Models;
using PagedList;


namespace WebsiteFPT.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private DongHoDbcontext db = new DongHoDbcontext();

        // GET: Admin/Login
        public ActionResult Index(string Search,int? i)
        {
            List<User> user = db.Users.ToList();
            return View(db.Users.Where(x => x.FirstName.StartsWith(Search) || Search == null).ToList().ToPagedList(i ?? 1, 3));

        }

       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    var ma_hoa_du_lieu = GETMD5(password);
                    var kiem_tra_tai_khoan = db.Users.Where(s => s.Email.Equals(email) && s.PassWord.Equals(ma_hoa_du_lieu)).ToList();
                    if (kiem_tra_tai_khoan.Count() > 0)
                    {
                        Session["idAdmin"] = kiem_tra_tai_khoan.FirstOrDefault().ID_Users;
                        Session["TenUser"] = kiem_tra_tai_khoan.FirstOrDefault().Email;
                        
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.LoginError = "Đăng nhập không thành công";
                        return RedirectToAction("Login");
                    }
                }
                return View();
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(m => m.Email == user.Email);
                if (check == null)
                {
                    user.PassWord = GETMD5(user.PassWord);

                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.EmailError = "Email đã tồn tại";
                    return View();
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        public static string GETMD5(string pass)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(pass);
            byte[] targetData = md5.ComputeHash(fromData);
            string mk_da_ma_hoa = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                mk_da_ma_hoa += targetData[i].ToString("x2");

            }
            return mk_da_ma_hoa;

        }
    }
}
