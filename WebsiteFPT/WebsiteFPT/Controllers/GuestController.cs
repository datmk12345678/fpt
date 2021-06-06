using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebsiteFPT.Models;

namespace WebsiteFPT.Controllers
{
    public class GuestController : Controller
    {
        private DongHoDbcontext db = new DongHoDbcontext();
        // GET: Guest
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
                var ma_hoa_du_lieu = GETMD5(password);
                var kiem_tra_tai_khoan = db.Guests.Where(s => s.Email.Equals(email) && s.PassWord.Equals(ma_hoa_du_lieu)).ToList();
                if (kiem_tra_tai_khoan.Count() > 0)
                {
                    Session["idKhach"] = kiem_tra_tai_khoan.FirstOrDefault().ID_Guest;
                    Session["client"] = kiem_tra_tai_khoan.FirstOrDefault().Email;
                    Session["firstName"] = kiem_tra_tai_khoan.FirstOrDefault().FirstName;
                    Session["lastName"] = kiem_tra_tai_khoan.FirstOrDefault().LastName;
                    Session["Username"] = kiem_tra_tai_khoan.FirstOrDefault().UserName;
                    Session["Phone"] = kiem_tra_tai_khoan.FirstOrDefault().Phone;
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
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Guest guest)
        {
            if (ModelState.IsValid)
            {
                var check = db.Guests.FirstOrDefault(m => m.Email == guest.Email);
                if (check == null)
                {
                    guest.PassWord = GETMD5(guest.PassWord);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Guests.Add(guest);
                    db.SaveChanges();
                    return RedirectToAction("Login");
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