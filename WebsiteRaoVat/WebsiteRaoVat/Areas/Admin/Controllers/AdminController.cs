using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRaoVat.Models;

namespace WebsiteRaoVat.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        RaoVatDB db = new RaoVatDB();
        public ActionResult BieuDO()
        {
            int nam = 2021;

            //ViewBag.Soluongtruycap = HttpContext.Application["Soluongtruycap"].ToString();
            ViewBag.tongbaiviet = sobaiviet();
            ViewBag.tongsl = Songuoithamgia();

            ViewBag.T1 = tongbaiviet(nam);
            ViewBag.T2 = tongbaiviet2(nam);
            ViewBag.T3 = tongbaiviet3(nam);
            ViewBag.T4 = tongbaiviet4(nam);
            ViewBag.T5 = tongbaiviet5(nam);
            ViewBag.T6 = tongbaiviet6(nam);
            ViewBag.T7 = tongbaiviet7(nam);
            ViewBag.T8 = tongbaiviet8(nam);
            ViewBag.T9 = tongbaiviet9(nam);
            ViewBag.T10 = tongbaiviet10(nam); 
            ViewBag.T11 = tongbaiviet11(nam); 
            ViewBag.T12= tongbaiviet12(nam);

            ViewBag.thang1 = tongnguoithamgia(nam);
            ViewBag.thang2 = tongnguoithamgia2(nam);
            ViewBag.thang3 = tongnguoithamgia3(nam);
            ViewBag.thang4 = tongnguoithamgia4(nam);
            ViewBag.thang5= tongnguoithamgia5(nam);
            ViewBag.thang6 = tongnguoithamgia6(nam);
            ViewBag.thang7 = tongnguoithamgia7(nam);
            ViewBag.thang8 = tongnguoithamgia8(nam);
            ViewBag.thang9 = tongnguoithamgia9(nam);
            ViewBag.thang10 = tongnguoithamgia10(nam);
            ViewBag.thang11 = tongnguoithamgia11(nam);
            ViewBag.thang12= tongnguoithamgia12(nam);
            return View();
        }

            public ActionResult Index() {
            int nam = 2021;
            ViewBag.T1 = tongbaiviet(nam);
            ViewBag.T2 = tongbaiviet2(nam);
            ViewBag.T3 = tongbaiviet3(nam);
            ViewBag.T4 = tongbaiviet4(nam);
            ViewBag.T5 = tongbaiviet5(nam);
            ViewBag.T6 = tongbaiviet6(nam);
            ViewBag.T7 = tongbaiviet7(nam);
            ViewBag.T8 = tongbaiviet8(nam);
            ViewBag.T9 = tongbaiviet9(nam);
            ViewBag.T10 = tongbaiviet10(nam);
            ViewBag.T11 = tongbaiviet11(nam);
            ViewBag.T12 = tongbaiviet12(nam);

            ViewBag.thang1 = tongnguoithamgia(nam);
            ViewBag.thang2 = tongnguoithamgia2(nam);
            ViewBag.thang3 = tongnguoithamgia3(nam);
            ViewBag.thang4 = tongnguoithamgia4(nam);
            ViewBag.thang5 = tongnguoithamgia5(nam);
            ViewBag.thang6 = tongnguoithamgia6(nam);
            ViewBag.thang7 = tongnguoithamgia7(nam);
            ViewBag.thang8 = tongnguoithamgia8(nam);
            ViewBag.thang9 = tongnguoithamgia9(nam);
            ViewBag.thang10 = tongnguoithamgia10(nam);
            ViewBag.thang11 = tongnguoithamgia11(nam);
            ViewBag.thang12 = tongnguoithamgia12(nam);
            ViewBag.Soluongtruycap = HttpContext.Application["Soluongtruycap"].ToString();
            ViewBag.tongbaiviet = sobaiviet();
            ViewBag.tongsl = Songuoithamgia();
            return View();
        }
        public ActionResult DanhMuc()
        {
            ViewBag.Soluongtruycap = HttpContext.Application["Soluongtruycap"].ToString();
            ViewBag.tongbaiviet = sobaiviet();
            ViewBag.tongsl = Songuoithamgia();
            return View(db.DanhMucs);
        }
        [HttpGet]
        public ActionResult ThemDanhMuc()
        {
            ViewBag.Soluongtruycap = HttpContext.Application["Soluongtruycap"].ToString();
            ViewBag.tongbaiviet = sobaiviet();
            ViewBag.tongsl = Songuoithamgia();
            return View();

        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult AddDanhMuc(string TieuDe, string Hinh)
        {
            try
            {
                DanhMuc danhMuc = new DanhMuc();
                danhMuc.TenDanhMuc = TieuDe;
                if (Hinh != "NULL")
                {
                    danhMuc.Hinh = Hinh;
                }
                db.DanhMucs.Add(danhMuc);
                db.SaveChanges();
                return Json(new { code = 200, msg = "Đăng thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        
        [ValidateInput(false)]
        [HttpGet]
        public ActionResult SuaDanhMuc(int? id)
        {
            ViewBag.Soluongtruycap = HttpContext.Application["Soluongtruycap"].ToString();
            ViewBag.tongbaiviet = sobaiviet();
            ViewBag.tongsl = Songuoithamgia();
            if (id == null)
            {
                Response.StatusCode = 404;
                return View();
            }
            DanhMuc dm = db.DanhMucs.SingleOrDefault(c => c.MaDanhMuc == id);
            if (dm == null)
            {
                return HttpNotFound();
            }
           

            return View(dm);
        }

        [HttpPost]
        public JsonResult SuaDM(int madanhmuc, string Ten, string Hinh )
        {
            
            try
            {
                var danhmuc = (from c in db.DanhMucs where c.MaDanhMuc == madanhmuc select c).FirstOrDefault();

                danhmuc.TenDanhMuc = Ten;
                if (Hinh != "NULL")
                {
                    danhmuc.Hinh = Hinh;
                }
                db.DanhMucs.Add(danhmuc);
                db.Entry(danhmuc).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Không thành công" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        //public ActionResult SuaDanhMuc(DanhMuc dm)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(dm).State = System.Data.Entity.EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("DanhMuc");
        //    }
        //    return View(dm);
        //}


        [HttpGet]
        public ActionResult XoaDanhMuc(int madanhmuc)
        {
            
            ViewBag.tongbaiviet = sobaiviet();
            ViewBag.tongsl = Songuoithamgia();
            DanhMuc dm = db.DanhMucs.SingleOrDefault(c => c.MaDanhMuc == madanhmuc);
            if (dm == null)
            {
                return HttpNotFound();
            }
            

            return View(dm);
        }
        
        [HttpPost]
        public JsonResult XoaDanhMucSanPham(int madanhmuc)
        {
            try
            {
                var dm = (from c in db.DanhMucs where c.MaDanhMuc == madanhmuc select c).FirstOrDefault();
                db.DanhMucs.Remove(dm);
                db.SaveChanges();
                
                return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Không thành công" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //public ActionResult XoaDanhMuc(int id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);


        //    }
        //    DanhMuc dm = db.DanhMucs.SingleOrDefault(c => c.MaDanhMuc == id);
        //    if (dm == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    db.DanhMucs.Remove(dm);
        //    db.SaveChanges();
        //    return RedirectToAction("DanhMuc");

        //}



        public ActionResult LoaiSP()
        {
            ViewBag.Soluongtruycap = HttpContext.Application["Soluongtruycap"].ToString();
            ViewBag.tongbaiviet = sobaiviet();
            ViewBag.tongsl = Songuoithamgia();
            return View(db.LoaiSanPhams);
        }
        [HttpGet]
        public ActionResult ThemLoaiSP()
        {
            ViewBag.Soluongtruycap = HttpContext.Application["Soluongtruycap"].ToString();
            ViewBag.tongbaiviet = sobaiviet();
            ViewBag.tongsl = Songuoithamgia();
            ViewBag.MaDanhMuc = new SelectList(db.DanhMucs.OrderBy(c => c.TenDanhMuc),"MaDanhMuc", "TenDanhMuc");
            return View();

        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult AddLoaiSP(int MaDanhMuc, string TieuDe, string Hinh)
        {
            try
            {
                LoaiSanPham loaiSanPham = new LoaiSanPham();
                loaiSanPham.TenLoaiSP = TieuDe;
                loaiSanPham.MaDanhMuc = MaDanhMuc;
               
                if (Hinh != "NULL")
                {
                    loaiSanPham.Hinh = Hinh;
                }
                db.LoaiSanPhams.Add(loaiSanPham);
                db.SaveChanges();
                return Json(new { code = 200, msg = "Đăng thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [ValidateInput(false)]
        [HttpGet]
        public ActionResult SuaLoaiSP(int? id)
        {
            ViewBag.Soluongtruycap = HttpContext.Application["Soluongtruycap"].ToString();
            ViewBag.tongbaiviet = sobaiviet();
            ViewBag.tongsl = Songuoithamgia();
            
            if (id == null)
            {
                Response.StatusCode = 404;
                return View();
            }
            LoaiSanPham loaiSP = db.LoaiSanPhams.SingleOrDefault(c => c.MaLoaiSP == id);
            if (loaiSP == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDanhMuc = new SelectList(db.DanhMucs.OrderBy(c => c.TenDanhMuc), "MaDanhMuc", "TenDanhMuc", loaiSP.MaDanhMuc);

            return View(loaiSP);
        }

        [HttpPost]
        public JsonResult UpdateLoaiSP(int maloai, int MaDanhMuc, string Hinh, string Ten)
        {
            try
            {
                var loaiSanPham = (from c in db.LoaiSanPhams where c.MaLoaiSP == maloai select c).FirstOrDefault();
                loaiSanPham.MaDanhMuc = MaDanhMuc;
                loaiSanPham.TenLoaiSP = Ten;
                if(Hinh != null)
                {
                    loaiSanPham.Hinh = Hinh;
                }
                db.LoaiSanPhams.Add(loaiSanPham);
                db.Entry(loaiSanPham).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Không thành công" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        
        [HttpGet]
        public ActionResult XoaLoaiSP(int? id)
        {
            ViewBag.Soluongtruycap = HttpContext.Application["Soluongtruycap"].ToString();
            ViewBag.tongbaiviet = sobaiviet();
            ViewBag.tongsl = Songuoithamgia();
            ViewBag.MaDanhMuc = new SelectList(db.DanhMucs.OrderBy(c => c.TenDanhMuc), "MaDanhMuc", "TenDanhMuc");

            if (id == null)
            {
                Response.StatusCode = 404;
                return View();
            }
            LoaiSanPham loaiSP = db.LoaiSanPhams.SingleOrDefault(c => c.MaLoaiSP == id);
            if (loaiSP == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDanhMuc = new SelectList(db.DanhMucs.OrderBy(c => c.TenDanhMuc), "MaDanhMuc", "TenDanhMuc", loaiSP.MaDanhMuc);

            return View(loaiSP);
        }
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult DeleteLoaiSP(int maloaiSP)
        {
            try
            {
                var loaiSP = (from c in db.LoaiSanPhams where c.MaLoaiSP == maloaiSP select c).FirstOrDefault();
                db.LoaiSanPhams.Remove(loaiSP);
                db.SaveChanges();
                return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Không thành công" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        
        public ActionResult DSBaiViet()
        {
            //ViewBag.Soluongtruycap = HttpContext.Application["Soluongtruycap"].ToString();
            //ViewBag.tongbaiviet = sobaiviet();
            //ViewBag.tongsl = Songuoithamgia();
            var listBV = db.BaiDangs.Where(x => x.TrangThai == 2).ToList();
            return View(listBV);
        }
        [HttpGet]
        public ActionResult DuyetBaiViet(int id)
        {
            //ViewBag.Soluongtruycap = HttpContext.Application["Soluongtruycap"].ToString();
            ViewBag.tongbaiviet = sobaiviet();
            ViewBag.tongsl = Songuoithamgia();
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            //}
          BaiDang baiDang = db.BaiDangs.SingleOrDefault(c => c.MaBaiDang == id);
            if (baiDang == null)
            {
                return HttpNotFound();
            }
            var listBaiViet = db.BaiDangs.Where(c => c.MaBaiDang == id);
            ViewBag.ListBaiViet = listBaiViet;

            return View(baiDang);

        }
        [HttpPost]
        public JsonResult UpdateTrangThai(int trangthai, int mabaidang)
        {
            try
            {
                var baidang = (from c in db.BaiDangs where c.MaBaiDang == mabaidang select c).FirstOrDefault();
                baidang.TrangThai = trangthai;
                db.SaveChanges();
                return Json(new { code = 200}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Không thành công" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        //[HttpPost]
        //public ActionResult DuyetBaiViet(BaiDang baidang)
        //{
        //    var bai= db.BaiDangs.SingleOrDefault(c => c.MaBaiDang == baidang.MaBaiDang);
        //    bai.TrangThai = baidang.TrangThai;
            
        //    db.SaveChanges();

        //    var listBaiViet = db.BaiDangs.Where(c => c.MaBaiDang == baidang.MaBaiDang);
        //    ViewBag.ListBaiViet = listBaiViet;

        //    return RedirectToAction("DSBaiViet", "Admin");
        //}
        public int Songuoithamgia()
        {
            int tongnguoi = db.TaiKhoans.Count();
            ViewBag.tongsl = tongnguoi;
            return tongnguoi;
        }
        public int sobaiviet()
        {
            int tongbaiviet = db.BaiDangs.Count();
            ViewBag.tongbaiviet = tongbaiviet;
            return tongbaiviet;
        }


        public int tongbaiviet( int nam)
        {
           
            int t1 = db.BaiDangs.Where(c => c.NgayDang.Value.Month == 1 && c.NgayDang.Value.Year == nam).Count();
        
            return t1;
        }
        public int tongbaiviet2(int nam)
        {

            int t2 = db.BaiDangs.Where(c => c.NgayDang.Value.Month == 2 && c.NgayDang.Value.Year == nam).Count();
          
            return t2;
        }
        public int tongbaiviet3(int nam)
        {

            int t3 = db.BaiDangs.Where(c => c.NgayDang.Value.Month == 3 && c.NgayDang.Value.Year == nam).Count();
         
            return t3;
        }
        public int tongbaiviet4(int nam)
        {

            int t4 = db.BaiDangs.Where(c => c.NgayDang.Value.Month ==4 && c.NgayDang.Value.Year == nam).Count();
          
            return t4;
        }
      
        public int tongbaiviet5(int nam)
        {

            int t5 = db.BaiDangs.Where(c => c.NgayDang.Value.Month == 5 && c.NgayDang.Value.Year == nam).Count();
        
            return t5;
        }
        public int tongbaiviet6(int nam)
        {

            int t6 = db.BaiDangs.Where(c => c.NgayDang.Value.Month == 6 && c.NgayDang.Value.Year == nam).Count();
   
            return t6;
        }
        public int tongbaiviet7(int nam)
        {

            int t7 = db.BaiDangs.Where(c => c.NgayDang.Value.Month == 7 && c.NgayDang.Value.Year == nam).Count();
       
            return t7;
        }
        public int tongbaiviet8(int nam)
        {

            int t8 = db.BaiDangs.Where(c => c.NgayDang.Value.Month == 8 && c.NgayDang.Value.Year == nam).Count();
         
            return t8;
        }
        public int tongbaiviet9(int nam)
        {

            int t9 = db.BaiDangs.Where(c => c.NgayDang.Value.Month == 9 && c.NgayDang.Value.Year == nam).Count();
       
            return t9;
        }
        public int tongbaiviet10(int nam)
        {

            int t10 = db.BaiDangs.Where(c => c.NgayDang.Value.Month == 10 && c.NgayDang.Value.Year == nam).Count();
          
            return t10;
        }
        public int tongbaiviet11(int nam)
        {

            int t11 = db.BaiDangs.Where(c => c.NgayDang.Value.Month == 11 && c.NgayDang.Value.Year == nam).Count();
     
            return t11;
        }
        public int tongbaiviet12(int nam)
        {

            int t12 = db.BaiDangs.Where(c => c.NgayDang.Value.Month == 12 && c.NgayDang.Value.Year == nam).Count();
       
            return t12;
        }

       
       
        public int tongnguoithamgia(int nam)
        {

            int Thang1 = db.TaiKhoans.Where(n => n.NgayThamGia.Value.Month == 1 && n.NgayThamGia.Value.Year == nam).Count();
   
            return Thang1;
        }
        public int tongnguoithamgia2(int nam)
        {
            int Thang2 = db.TaiKhoans.Where(n => n.NgayThamGia.Value.Month == 2 && n.NgayThamGia.Value.Year == nam).Count();
                return Thang2;
        }
        public int tongnguoithamgia3(int nam)
        {
            int Thang3 = db.TaiKhoans.Where(n => n.NgayThamGia.Value.Month == 3 && n.NgayThamGia.Value.Year == nam).Count();
     
            return Thang3;
        }
        public int tongnguoithamgia4(int nam)
        {
            int Thang4 = db.TaiKhoans.Where(n => n.NgayThamGia.Value.Month == 4 && n.NgayThamGia.Value.Year == nam).Count();
        
            return Thang4;
        }
        public int tongnguoithamgia5(int nam)
        {
            int Thang5 = db.TaiKhoans.Where(n => n.NgayThamGia.Value.Month == 5 && n.NgayThamGia.Value.Year == nam).Count();
  
            return Thang5;
        }
        public int tongnguoithamgia6(int nam)
        {
            int Thang6 = db.TaiKhoans.Where(n => n.NgayThamGia.Value.Month == 6 && n.NgayThamGia.Value.Year == nam).Count();
  
            return Thang6;
        }
        public int tongnguoithamgia7(int nam)
        {
            int Thang7 = db.TaiKhoans.Where(n => n.NgayThamGia.Value.Month == 7 && n.NgayThamGia.Value.Year == nam).Count();

            return Thang7;
        }

        public int tongnguoithamgia8(int nam)
        {
            int Thang8 = db.TaiKhoans.Where(n => n.NgayThamGia.Value.Month == 8 && n.NgayThamGia.Value.Year == nam).Count();
            return Thang8;
        }
        public int tongnguoithamgia9(int nam)
        {
            int Thang9 = db.TaiKhoans.Where(n => n.NgayThamGia.Value.Month == 9&& n.NgayThamGia.Value.Year == nam).Count();
            return Thang9;
        }
        public int tongnguoithamgia10(int nam)
        {
            int Thang10 = db.TaiKhoans.Where(n => n.NgayThamGia.Value.Month == 10 && n.NgayThamGia.Value.Year == nam).Count();
           

            return Thang10;
        }
            public int tongnguoithamgia11(int nam)
            {
                int Thang11 = db.TaiKhoans.Where(n => n.NgayThamGia.Value.Month == 11 && n.NgayThamGia.Value.Year == nam).Count();
         
                return Thang11;
            }

        public int tongnguoithamgia12(int nam)
        {
            int Thang12 = db.TaiKhoans.Where(n => n.NgayThamGia.Value.Month == 2 && n.NgayThamGia.Value.Year == nam).Count();
     
            return Thang12;
        }

        
    }
}
