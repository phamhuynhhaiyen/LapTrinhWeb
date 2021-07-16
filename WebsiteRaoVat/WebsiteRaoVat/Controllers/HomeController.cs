using MoMo;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteRaoVat.Models;

namespace WebsiteRaoVat.Controllers
{
    public class HomeController : Controller
    {
        private RaoVatDB db = new RaoVatDB();
        public ActionResult Index()
        {
            var listDM = (from d in db.DanhMucs select d).ToList();
            return View(listDM);
        }
        public ActionResult DangTin()
        {
            List<DanhMuc> lstDanhMuc = db.DanhMucs.ToList();
            return View(lstDanhMuc);
        }
        public JsonResult getLoaiSP(int MaDanhMuc)
        {
            try
            {
                var lstLoaiSP = from l in db.LoaiSanPhams where l.MaDanhMuc == MaDanhMuc select new { MaLoaiSP = l.MaLoaiSP, TenLoaiSP = l.TenLoaiSP};
                return Json(new { code = 200, lstLoaiSP = lstLoaiSP }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult AddBaiDang(int MaLoaiSP, string TieuDe, long Gia, bool TinhTrang, string MoTa, string Hinh, string Hinh1, string Hinh2, string Hinh3, string Hinh4)
        {
            try
            {
                TaiKhoan taikhoan = (TaiKhoan)Session["TaiKhoan"];
                BaiDang baidang = new BaiDang();
                baidang.MaLoaiSP = MaLoaiSP;
                baidang.TieuDe = TieuDe;
                baidang.Gia = Gia;
                baidang.TinhTrang = TinhTrang;
                baidang.MoTa = MoTa;
                if (Hinh != "NULL")
                {
                    baidang.HinhAnh = Hinh;
                }               
                if(Hinh1 != "NULL")
                {
                    baidang.HinhAnh1 = Hinh1;
                }
                if (Hinh2 != "NULL")
                {
                    baidang.HinhAnh2 = Hinh2;
                }
                if (Hinh3 != "NULL")
                {
                    baidang.HinhAnh3 = Hinh3;
                }
                if (Hinh4 != "NULL")
                {
                    baidang.HinhAnh4 = Hinh4;
                }              
                baidang.Username = taikhoan.Username;
                baidang.TrangThai = 2;
                baidang.NgayDang = DateTime.Now;
                db.BaiDangs.Add(baidang);
                db.SaveChanges();
                return Json(new { code = 200, msg = "Đăng thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public string XuLyFile(HttpPostedFileBase file)
        {
            string path = Server.MapPath("~/Images/" + file.FileName);
            try
            {
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                file.SaveAs(path);
            }
            catch { }

            return "/Images/" + file.FileName;

        }
        public string XuLyFileHinh(HttpPostedFileBase file)
        {
            TaiKhoan taikhoan = (TaiKhoan)Session["TaiKhoan"];

            string path = Server.MapPath("~/Images/" + file.FileName);
            try
            {
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                file.SaveAs(path);
            }
            catch { }
            var tk = (from t in db.TaiKhoans where t.Username == taikhoan.Username select t).FirstOrDefault();
            tk.Hinh = "/Images/" + file.FileName;
            db.SaveChanges();
            return "/Images/" + file.FileName;

        }
        public ActionResult Menu()
        {
            TaiKhoan taikhoan = (TaiKhoan) Session["TaiKhoan"];
            if(taikhoan != null)
            {
                ViewBag.Username = taikhoan.Username;
            }
            return PartialView();
        }
        public ActionResult QuanLyTin()
        {
            TaiKhoan taikhoan = (TaiKhoan)Session["TaiKhoan"];
            ViewBag.TenNguoiDung = taikhoan.TenNguoiDung;
            if(taikhoan.Hinh == null)
            {
                ViewBag.Hinh = "/Images/img_avatar.png";
            }
            else
            {
                ViewBag.Hinh = taikhoan.Hinh;
            }
            return View();
        }
        public JsonResult getBaiDang(int TrangThai)
        {
            try
            {
                TaiKhoan taikhoan = (TaiKhoan)Session["TaiKhoan"];
                //Lấy bài đăng theo trạng thái
                var lstbaidang = (from b in db.BaiDangs where b.TrangThai == TrangThai &&b.Username == taikhoan.Username select new { MaBaiDang = b.MaBaiDang, TieuDe = b.TieuDe, Gia = b.Gia, HinhAnh = b.HinhAnh, TrangThai = b.TrangThai }).ToList();
                //Lấy bài đăng còn hạn quảng cáo
                var listqc = (from tin in db.QuangCaos
                              where DateTime.Compare(DateTime.Now, (DateTime)tin.NgayHetHan) == -1
                              select tin).ToList();
                //var query = from person in people
                //            join pet in pets on person equals pet.Owner into gj
                //            from subpet in gj.DefaultIfEmpty()
                //            select new { person.FirstName, PetName = subpet?.Name ?? String.Empty };
                var lstGop = (from baidang in lstbaidang
                              join quangcao in listqc on baidang.MaBaiDang equals quangcao.MaBaiDang into gr
                              from gop in gr.DefaultIfEmpty()
                              select new {
                                  MaBaiDang = baidang.MaBaiDang,
                                  TieuDe = baidang.TieuDe,
                                  Gia = baidang.Gia,
                                  HinhAnh = baidang.HinhAnh,
                                  TrangThai = baidang.TrangThai,
                                  NgayHetHan = gop?.NgayHetHan ?? null
                              }).ToList();
                var lst1 = (from baidang in lstGop
                              select new
                              {
                                  MaBaiDang = baidang.MaBaiDang,
                                  TieuDe = baidang.TieuDe,
                                  Gia = baidang.Gia.GetValueOrDefault(0).ToString("N0"),
                                  HinhAnh = baidang.HinhAnh,
                                  TrangThai = baidang.TrangThai,
                                  NgayHetHan = baidang.NgayHetHan.ToString()
                              }).ToList();
                //Console.WriteLine(lstGop);
                return Json(new { code = 200, lstBaiDang = lst1 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult getDanhSachSP(int trang)
        {
            try
            {
                var lstbaidang = (from b in db.BaiDangs.Where(x => x.TrangThai == 0).OrderByDescending(x => x.NgayDang).ToList()
                                  select new
                                  {
                                      MaBaiDang = b.MaBaiDang,
                                      TieuDe = b.TieuDe,
                                      Gia = b.Gia.GetValueOrDefault(0).ToString("N0"),
                                      HinhAnh = b.HinhAnh,
                                      NgayDang = b.NgayDang.ToString()
                                  }).ToList();
                //Lấy tin ưu tiên

                var trangSP = lstbaidang.Count() % 30 == 0 ? lstbaidang.Count() / 30 : lstbaidang.Count() / 30 + 1;
                var kqpt = lstbaidang.Skip((trang - 1) * 30).Take(30).ToList();
                return Json(new { code = 200, trangSP = trangSP, lstBaiDang = kqpt }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult UpdateTrangThai(int trangthai, int mabaidang)
        {
            try
            {
                var baidang = (from c in db.BaiDangs where c.MaBaiDang == mabaidang select c).FirstOrDefault();
                baidang.TrangThai = trangthai;
                db.SaveChanges();
                return Json(new { code = 200 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Không thành công" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult BaiDang(int id)
        {
            TaiKhoan tk = (TaiKhoan)Session["TaiKhoan"];
            BaiDang baidang = db.BaiDangs.Where(x => x.MaBaiDang == id).FirstOrDefault();       
            if(tk != null)
            {
                ViewBag.Session = tk.Username;
            }
            return View(baidang);
        }
        public JsonResult getTinLienQuan(int madanhmuc, int mabaidang)
        {
            try
            {
                List<BaiDang> lst = (from b in db.BaiDangs
                              where b.LoaiSanPham.MaDanhMuc == madanhmuc && b.TrangThai == 0
                              select b).ToList();
                List<BaiDang> baidang = (from b in db.BaiDangs
                                        where b.MaBaiDang == mabaidang
                                        select b).ToList();
                List<BaiDang> lsttin = (lst.Except(baidang)).ToList();
                List<BaiDang> listBaiBang = new List<BaiDang>();
                if(lsttin.Count > 6)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        listBaiBang.Add(lsttin[i]);
                    }
                }
                else
                {
                    listBaiBang = lsttin;
                }
                var tin = (from b in listBaiBang
                           select new
                           {
                               MaBaiDang = b.MaBaiDang,
                               TieuDe = b.TieuDe,
                               Gia = b.Gia.GetValueOrDefault(0).ToString("N0"),
                               HinhAnh = b.HinhAnh,
                               NgayDang = b.NgayDang.ToString()
                           }).ToList();
                return Json(new { code = 200, listTin = tin }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Không thành công" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static string serectkey;
        public static string amount;
        public void ThanhToanMomo(int tongtien, int mabaidang)
        {
            //request params need to request to MoMo system
            string endpoint = "https://payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMODDI520210624";
            string accessKey = "xryFOk958utQJR3T";
            //string serectkey = "art4TPJhFphYnpVLIDX9pIWKcXybGJw3";
            serectkey = "art4TPJhFphYnpVLIDX9pIWKcXybGJw3";
            string orderInfo = "Mua quảng cáo";
            string returnUrl = "https://localhost:44349/Home/returnUrl/"+mabaidang;
            string notifyurl = "https://localhost:44349/Home/notifyurl";

            amount = ""+ tongtien;
            string orderid = Guid.NewGuid().ToString();
            string requestId = Guid.NewGuid().ToString();
            string extraData = "";

            //Before sign HMAC SHA256 signature
            string rawHash = "partnerCode=" +
                partnerCode + "&accessKey=" +
                accessKey + "&requestId=" +
                requestId + "&amount=" +
                amount + "&orderId=" +
                orderid + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            log.Debug("rawHash = " + rawHash);

            MoMoSecurity crypto = new MoMoSecurity();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);
            log.Debug("Signature = " + signature);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }

            };
            //log.Debug("Json request to MoMo: " + message.ToString());
            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);
            //log.Debug("Return from MoMo: " + jmessage.ToString());

            //yes...
            System.Diagnostics.Process.Start(jmessage.GetValue("payUrl").ToString());
        }
        public ActionResult returnUrl(int id)
        {
            string param = Request.QueryString.ToString().Substring(0, Request.QueryString.ToString().IndexOf("signature") - 1);
            //log.Debug(param);
            param = Server.UrlDecode(param);
            MoMoSecurity crypto = new MoMoSecurity();
            //string serectkey = ConfigurationManager.AppSettings["serectkey"].ToString();
            string serectKey = serectkey.ToString();
            string signature = crypto.signSHA256(param, serectKey);
            if (signature != Request["signature"].ToString())
            {
                ViewBag.Message = "Thông tin không hợp lệ!";
                return View();
            }
            if (!Request.QueryString["errorCode"].Equals("0"))
            {
                ViewBag.Message = "Thanh toán thất bại!";
                return View();
            }
            else
            {
                DateTime now = DateTime.Now;
                DateTime ngayhethan = new DateTime();
                if (amount == "1000")
                {
                    ngayhethan = now.AddDays(1);
                }
                else if (amount == "3000")
                {
                    ngayhethan = now.AddDays(3);
                }
                else if (amount == "5000")
                {
                    ngayhethan = now.AddDays(5);
                }
                QuangCao qc = new QuangCao();
                qc.NgayMua = now;
                qc.SoTien = int.Parse(amount);
                qc.MaBaiDang = id;
                qc.NgayHetHan = ngayhethan;
                db.QuangCaos.Add(qc);
                db.SaveChanges();
                ViewBag.Message = "Thanh toán thành công!";
            }
            return View();
        }
        public JsonResult notifyurl(int id)
        {
            //string param = "";
            //param = "partnerCode=" + Request["partnerCcode"] +"&accessKey=" + Request["accessKey"]+               
            //  "&amount=" + Request["amount"] +
            //  "&orderId=" + Request["orderId"] +
            //  "&orderInfo=" + Request["orderInfo"]+
            //  "&orderType=" + Request["orderType"] +
            //  "&transId=" + Request["transId"] +
            //  "&message="+ Request["message"]+
            //  "&responseTime=" + Request["responseTime"]
            //  + "&errorCode" + Request["errorCode"];
            //param = Server.UrlDecode(param);
            //MoMoSecurity crypto = new MoMoSecurity();
            //string serectKey = serectkey.ToString();
            //string signature = crypto.signSHA256(param, serectKey);
            //if (signature != Request["signature"].ToString())
            //{

            //}
            //string errorCode = Request["errorCode"].ToString();
            //if(errorCode != "0")
            //{
            //    //That bai
            //}
            //else
            //{
            //    //Thanh cong
            //    DateTime now = DateTime.Now;
            //    DateTime ngayhethan = new DateTime();
            //    if(amount == "1000")
            //    {
            //        ngayhethan = now.AddDays(1);
            //    }else if(amount == "3000")
            //    {
            //        ngayhethan = now.AddDays(3);
            //    }
            //    else if (amount == "5000")
            //    {
            //        ngayhethan = now.AddDays(5);
            //    }
            //    QuangCao qc = new QuangCao();
            //    qc.MaBaiDang = id;
            //    qc.NgayHetHan = ngayhethan;
            //    db.QuangCaos.Add(qc);
            //    db.SaveChanges();
            //}
            //Thanh cong
            DateTime now = DateTime.Now;
            DateTime ngayhethan = new DateTime();
            if (amount == "1000")
            {
                ngayhethan = now.AddDays(1);
            }
            else if (amount == "3000")
            {
                ngayhethan = now.AddDays(3);
            }
            else if (amount == "5000")
            {
                ngayhethan = now.AddDays(5);
            }
            QuangCao qc = new QuangCao();
            qc.MaBaiDang = id;
            qc.NgayHetHan = ngayhethan;
            db.QuangCaos.Add(qc);
            db.SaveChanges();
            return Json(new { code = 200}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult NotAuthorize()
        {
            return View();
        }
    }

    
}