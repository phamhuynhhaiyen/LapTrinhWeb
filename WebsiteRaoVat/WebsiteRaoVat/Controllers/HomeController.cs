using MoMo;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
                baidang.HinhAnh = Hinh;
                baidang.HinhAnh1 = Hinh1;
                baidang.HinhAnh2 = Hinh2;
                baidang.HinhAnh3 = Hinh3;
                baidang.HinhAnh4 = Hinh4;
                baidang.Username = taikhoan.Username;
                baidang.TrangThai = 0;
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
        public ActionResult Menu()
        {
            TaiKhoan taikhoan = (TaiKhoan) Session["TaiKhoan"];
            
            return PartialView();
        }
        public ActionResult QuanLyTin()
        {
            TaiKhoan taikhoan = (TaiKhoan)Session["TaiKhoan"];
            ViewBag.TenNguoiDung = taikhoan.TenNguoiDung;
            return View();
        }
        public JsonResult getBaiDang(int TrangThai)
        {
            try
            {
                TaiKhoan taikhoan = (TaiKhoan)Session["TaiKhoan"];
                var lstbaidang = (from b in db.BaiDangs where b.TrangThai == TrangThai &&b.Username == taikhoan.Username select new { MaBaiDang = b.MaBaiDang, TieuDe = b.TieuDe, Gia = b.Gia, HinhAnh = b.HinhAnh }).ToList();
                return Json(new { code = 200, lstBaiDang = lstbaidang }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        //Để tạm thời để thiết kế layout
        public JsonResult getDanhSachSP()
        {
            try
            {
                var lstbaidang = (from b in db.BaiDangs where b.TrangThai == 0 select new { MaBaiDang = b.MaBaiDang, TieuDe = b.TieuDe, Gia = b.Gia, HinhAnh = b.HinhAnh }).ToList();
                return Json(new { code = 200, lstBaiDang = lstbaidang }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult BaiDang(int id)
        {
            BaiDang baidang = db.BaiDangs.Where(x => x.MaBaiDang == id).FirstOrDefault();
            return View(baidang);
        }
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void ThanhToanMomo(int tongtien)
        {
            //request params need to request to MoMo system
            string endpoint = "https://payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMODDI520210624";
            string accessKey = "xryFOk958utQJR3T";
            string serectkey = "art4TPJhFphYnpVLIDX9pIWKcXybGJw3";
            string orderInfo = "Mua quảng cáo";
            string returnUrl = "https://localhost:44349/Home/QuanLyTin";
            string notifyurl = "https://momo.vn/notify";

            string amount = ""+ tongtien;
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
            log.Debug("Json request to MoMo: " + message.ToString());
            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);
            log.Debug("Return from MoMo: " + jmessage.ToString());

            //yes...
            System.Diagnostics.Process.Start(jmessage.GetValue("payUrl").ToString());
        }
    }
   
}