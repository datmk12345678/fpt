using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteFPT.Models;

namespace WebsiteFPT.Controllers
{
    public class CartController : Controller
    {
        private DongHoDbcontext db = new DongHoDbcontext();
        // GET: Cart
        public Cart getCart()
        {

            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult addToCart(int id)
        {
            ViewBag.DanhMuc = db.Categorys.ToList();
            var pro = db.Products.SingleOrDefault(s => s.ID_Product == id);
            if (pro != null)
            {
                getCart().add(pro);
            }
            return RedirectToAction("showToCart", "Cart");
        }
        public ActionResult showToCart()
        {
            ViewBag.Message = "Cart";
            ViewBag.DanhMuc = db.Categorys.ToList();
            if (Session["Cart"] == null)
            {
                return RedirectToAction("showToCart", "Cart");
            }
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public ActionResult updateDetailCart(FormCollection form)
        {
            int id_pro = int.Parse(form["id_product"]);
            int quantity = int.Parse(form["quantity"]);
            var pro = db.Products.SingleOrDefault(s => s.ID_Product == id_pro);
            if (pro != null)
            {
                getCart().update_quantity_shopping_detail(pro, quantity);
            }
            return RedirectToAction("showToCart", "Cart");
        }
        public ActionResult updateCart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(form["id_product"]);
            int quantity = int.Parse(form["quantity"]);
            cart.update_quantity_shopping(id_pro, quantity);
            return RedirectToAction("showToCart", "Cart");
        }
        public ActionResult removeCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.removeCartItem(id);
            return RedirectToAction("showToCart", "Cart");
        }
        public ActionResult Shopping_Success()
        {
            return View();
        }
        public PartialViewResult bagCart()
        {
            int total_item = 0;

            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
                total_item = cart.totalQuantityCart();
            ViewBag.QuantityCart = total_item;
            return PartialView("bagCart");
        }
        public PartialViewResult total_money()
        {
            double money = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
                money = cart.total_money();
            ViewBag.Total = money;
            return PartialView("total_money");
        }

        public ActionResult shoping_success()
        {
            ViewBag.DanhMuc = db.Categorys.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult checkOut(FormCollection form)
        {
            ViewBag.DanhMuc = db.Categorys.ToList();

            Cart cart = Session["Cart"] as Cart;
            Order _order = new Order();
            _order.Created_At = DateTime.Now;
            _order.ID_Guest = (int)Session["idKhach"];
            _order.Note = form["Note"];
            _order.Status = int.Parse(form["Status"]);
            _order.Total_Price = cart.Items.Sum(s => s._shopping_product.Prices.PromotionPrice * s._shopping_quantity);
            db.Orders.Add(_order);
            foreach (var item in cart.Items)
            {
                attr_order _order_detail = new attr_order();
                _order_detail.ID_attr_order = _order.ID_Order;
                _order_detail.ID_Product = item._shopping_product.ID_Product;
                _order_detail.Price = item._shopping_product.Prices.Prices;
                _order_detail.Price = item._shopping_product.Prices.PromotionPrice;
                _order_detail.Quantity = item._shopping_quantity;
                _order_detail.Created_At = DateTime.Now;
                db.Attr_Orders.Add(_order_detail);
            }
            db.SaveChanges();
            cart.clearCart();
            return RedirectToAction("shoping_success", "Cart");

        }
        public ActionResult ShowCheckout()
        {
            ViewBag.Message = "Checkout";
         
            if (Session["Cart"] == null)
            {
                return RedirectToAction("showToCart", "Cart");
            }
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
    }
}