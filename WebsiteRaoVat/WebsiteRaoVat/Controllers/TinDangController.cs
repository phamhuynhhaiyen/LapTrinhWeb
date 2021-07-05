using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRaoVat.Models;

namespace WebsiteRaoVat.Controllers
{
    public class TinDangController : Controller
    {
        // GET: TinDang
        private RaoVatDB db = new RaoVatDB();
        public ActionResult DSTinDang(int id)
        {
            DateTime now = DateTime.Now;
            var dsTin = (from tin in db.QuangCaos where tin.BaiDang.LoaiSanPham.MaDanhMuc == id && DateTime.Compare(now, (DateTime)tin.NgayHetHan) == -1 select tin).ToList();
            ViewBag.MaDanhMuc = id;
            return View(dsTin);
        }
        public JsonResult getBaiDang(int id)
        {
            try
            {
                var listBaiDang = (from l in db.BaiDangs
                                   where l.LoaiSanPham.MaDanhMuc == id && l.TrangThai == 0
                                   orderby l.NgayDang descending
                                   select new
                                   {
                                       MaBaiDang = l.MaBaiDang,
                                       Username = l.Username,
                                       TieuDe = l.TieuDe,
                                       Gia = l.Gia,
                                       HinhAnh = l.HinhAnh,
                                       NgayDang = l.NgayDang
                                   }).ToList();
                return Json(new { code = 200, lstBaiDang = listBaiDang }, JsonRequestBehavior.AllowGet);
            }catch(Exception ex)
            {
                return Json(new { code = 500, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult TrangCaNhan(string id)
        {
            var tk = db.TaiKhoans.Where(x => x.Username == id).FirstOrDefault();
            return View(tk);
        }
        public JsonResult getTongSP(string username)
        {
            try
            {
                var spdangban = (from c in db.BaiDangs where c.TaiKhoan.Username == username && c.TrangThai == 0 select c).Count();
                var spdaban = (from c in db.BaiDangs where c.TaiKhoan.Username == username && c.TrangThai == 3 select c).Count();
                return Json(new { code = 200, spdangban = spdangban, spdaban = spdaban }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult getBaiDangUser(string username)
        {
            try
            {

                var listBaiDang = (from c in db.BaiDangs where c.TaiKhoan.Username == username && c.TrangThai == 0 select new { MaBaiDang = c.MaBaiDang, HinhAnh = c.HinhAnh, TieuDe = c.TieuDe, Gia = c.Gia }).ToList();
                return Json(new { code = 200, lstBaiDang = listBaiDang }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}