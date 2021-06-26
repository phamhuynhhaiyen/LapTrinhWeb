using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using WebsiteRaoVat.Models;
using Facebook;
using System.Configuration;
using System.Web.Security;
using System.IO;
using System.Net;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace WebsiteRaoVat.Controllers
{
    public class LoginController : Controller
    {
        RaoVatDB db = new RaoVatDB();
        // GET: Login
        public ActionResult login()
        {
            return PartialView();
        }
        [HttpPost]
        // đăng nhập thường
        public ActionResult login(TaiKhoan tk)
        {

            var a = GetMD5(tk.Password).ToString();

            var tv = (from c in db.TaiKhoans where c.Username == tk.Username && c.Password == tk.Password select c).FirstOrDefault();
            if (tv != null)
            {
                Session["TaiKhoan"] = tv;
                return RedirectToAction("Index", "Home");
            }
            return View();
            
        }
        public JsonResult KTDangNhap(string username, string password)
        {
            try
            {
                var taikhoan = (from t in db.TaiKhoans where t.Username == username && t.Password == password select t).FirstOrDefault();
                int thanhcong = 1;
                if(taikhoan != null)
                {
                    Session["TaiKhoan"] = taikhoan;
                }
                else
                {
                    thanhcong = 0;
                }
                return Json(new { code = 200, thanhcong = thanhcong}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        //Đăng nhập bằng facebook
        public Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }

        public ActionResult loginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbAppID"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                respone_type = "code",
                scope = "email",
            });

            return Redirect(loginUrl.AbsoluteUri);
        }

        public string InsertLoginFacebook(TaiKhoan enty)
        {
            var user = db.TaiKhoans.SingleOrDefault(n => n.Username == enty.Username);
            if (user == null)
            {
                db.TaiKhoans.Add(enty);
                db.SaveChanges();
                return enty.Username;
            }

            return user.Username;

        }

        //save ảnh
        public void SaveImage(string imageUrl, string filename, ImageFormat format)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(imageUrl);
            Bitmap bitmap; bitmap = new Bitmap(stream);

            if (bitmap != null)
            {
                bitmap.Save(filename, format);
            }

            try
            {
                SaveImage(imageUrl, "~/Content/Images/", ImageFormat.Png);
}
            catch (ExternalException)
            {
                // Something is wrong with Format -- Maybe required Format is not 
                // applicable here
            }
            catch (ArgumentNullException)
            {
                // Something wrong with Stream
            }
            stream.Flush();
            stream.Close();
            client.Dispose();
        }

        //lấy ra url hình ảnh
        public static string GetPictureUrl(string faceBookId)
        {
            WebResponse response = null;
            string pictureUrl = string.Empty;
            try
            {
                WebRequest request = WebRequest.Create(string.Format("https://graph.facebook.com/{0}/picture", faceBookId));
                response = request.GetResponse();
                pictureUrl = response.ResponseUri.ToString();
            }
            catch (Exception ex)
            {
                //? handle
            }
            finally
            {
                if (response != null) response.Close();
            }
            return pictureUrl;
        }

        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppID"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;
            if (!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,picture,id,email");
                string id = me.id;
                string email = me.email;
                string firstname = me.first_name;
                string lastname = me.last_name;
                string middlename = me.middle_name;
                var hinh = me.picture;

                var user = new TaiKhoan();
                user.Username = email;
                var a = GetMD5(email).ToString();
                user.Password = email;
                user.NgayThamGia = DateTime.Now;
                user.Quyen = 3;
                var anh = GetPictureUrl(id);
                //SaveImage(anh, email, ImageFormat.Png);

                //using (WebClient webClient = new WebClient())
                //{
                //    byte[] data = webClient.DownloadData(anh);

                //    using (MemoryStream mem = new MemoryStream(data))
                //    {
                //        using (var yourImage = Image.FromStream(mem))
                //        {
                //            // If you want it as Png
                //            yourImage.Save(@"~/Content/Images/"+middlename+".png", ImageFormat.Png);

                //            // If you want it as Jpeg
                //            yourImage.Save("~/Content/Images/", ImageFormat.Jpeg);
                //        }
                //    }

                //}

                var resultInsert = (InsertLoginFacebook(user).ToString());
                if (resultInsert != null)
                {
                    var tv = (from c in db.TaiKhoans where c.Username == user.Username && c.Password== user.Password select c).FirstOrDefault();
                    if (tv != null)
                    {
                        Session["userName"] = tv;
                        return RedirectToAction("thu", "Login");
                    }
                }
            }
            return View();
        }

        //mã hóa md5
        public string GetMD5(string chuoi)
        {
            string str_md5 = "";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(chuoi);

            MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
            mang = my_md5.ComputeHash(mang);

            foreach (byte b in mang)
            {
                str_md5 += b.ToString("X2");
            }

            return str_md5;
        }

        //Đăng xuất
        public ActionResult DangXuat()
        {
            Session["userName"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("login", "Login");
        }

        public ActionResult thu()
        {
            var user = db.TaiKhoans;
            return View(user);
        }
    }

}