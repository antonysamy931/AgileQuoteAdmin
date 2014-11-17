using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgileQuoteAdminProperty.Property;
using System.ServiceModel;
using LogWriter;
using System.IO;

namespace AgileQuoteAdmin.Controllers
{
    public class UserRegistrationController : Controller
    {
        
        AgileAdminService.IService1 Service = new AgileAdminService.Service1Client();

        [HttpGet]
        public ActionResult Registration()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "LogIn");
            }

            UserRegistration oUserRegistration = new UserRegistration();
            oUserRegistration.CompanyList = Service.CompanyNameService();
            oUserRegistration.RoleList = Service.RoleNameService();
            return View(oUserRegistration);
        }

        [HttpPost]
        public ActionResult Registration(HttpPostedFileBase image, UserRegistration oUserReg, string name)
        {
            try
            {
                if (Session["UserID"] == null)
                {
                    return RedirectToAction("LogIn", "LogIn");
                }

                byte[] data = GenerateImage(image, name);

                oUserReg.CompanyList = Service.CompanyNameService();
                oUserReg.RoleList = Service.RoleNameService();

                var oName = oUserReg.CompanyList.Where(x => x.Code ==Convert.ToInt32(oUserReg.CompanyName)).FirstOrDefault();
                if (oName != null)
                {
                    oUserReg.CompanyName = oName.Name;
                    oUserReg.CompanyCode = oName.Code;
                }

                if (ModelState.IsValid)
                {
                    var Result = Service.UserRegistrationService(oUserReg, data, name);
                    if (Result == "Success")
                    {                        
                        return RedirectToAction("PartialUser", "UserRegistration");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, Result);
                        return View(oUserReg);
                    }
                }
            }

            catch (FaultException<ExceptionClass> Ex)
            {
                LogWriter.LogWriter.Log(Ex.Detail.StackTrace + "-" + Ex.Detail.ErrorReason);

            }
            return View(oUserReg);
        }

        [HttpGet]
        public ActionResult PartialUser()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "LogIn");
            }

            UserRegistrationList oUserList = new UserRegistrationList();
            try
            {                
                oUserList.RegistrationList = Service.RegistrationListService();
            }
            catch (FaultException<ExceptionClass> Ex)
            {
                LogWriter.LogWriter.Log(Ex.Detail.StackTrace + "-" + Ex.Detail.ErrorReason);
            }
            return View(oUserList);
        }
        
        [HttpGet]
        public ActionResult EditUser(string Input)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "LogIn");
            }

            string[] value = Input.Split(' ');
            int UserId = Convert.ToInt32(value[0]);
            int CompanyCode = Convert.ToInt32(value[1]);
            try
            {

                var oEdit = Service.SingleRegistrationService(UserId, CompanyCode);
                if (oEdit != null)
                {
                    RegistrationGrid oUserReg = oEdit;
                    oUserReg.CompanyList=Service.CompanyNameService();
                    oUserReg.RoleList=Service.RoleNameService();
                    return View(oUserReg);
                }
            }
            catch (FaultException<ExceptionClass> Ex)
            {
                LogWriter.LogWriter.Log(Ex.Detail.StackTrace + "-" + Ex.Detail.ErrorReason);

            }
            return View();
        }

        [HttpPost]
        public ActionResult EditUser(HttpPostedFileBase image,RegistrationGrid oUserReg, string name)
        {
            try
            {
                if (Session["UserID"] == null)
                {
                    return RedirectToAction("LogIn", "LogIn");
                }

                byte[] data = GenerateImage(image, name);

                oUserReg.CompanyList = Service.CompanyNameService();
                oUserReg.RoleList = Service.RoleNameService();
                if (ModelState.IsValid)
                {

                    var Result = Service.UpdateRegistrationService(oUserReg, data,name);
                    if (Result == "Success")
                    {
                        return RedirectToAction("PartialUser", "UserRegistration");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, Result);
                        return View(oUserReg);
                    }

                }
                //TempData["trans"] = oUserReg;
            }
            catch (FaultException<ExceptionClass> Ex)
            {
                LogWriter.LogWriter.Log(Ex.Detail.StackTrace + "-" + Ex.Detail.ErrorReason);

            }
            return View(oUserReg);
        }

        [HttpPost]
        public JsonResult DeleteUser(int UserId)
        {
            object oUser = null;
            try
            {
               
                var Result = Service.DeleteRegistrationService(UserId);
                oUser = new 
                {
                   Result 
                };
            }
            catch (FaultException<ExceptionClass> Ex)
            {
                LogWriter.LogWriter.Log(Ex.Detail.StackTrace + "-" + Ex.Detail.ErrorReason);

            }
            return Json(oUser);
        }

        [NonAction]
        public byte[] GenerateImage(HttpPostedFileBase image, string name)
        {
            byte[] data = null;
            if (image != null)
            {
                System.Drawing.Image img = System.Drawing.Image.FromStream(image.InputStream);
                System.Drawing.Font drawFont = new System.Drawing.Font("Trebuchet MS", 9);
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(102, 102, 102));
                if (name.Length >= 30)
                {
                    name = name.Remove(27) + "...";
                }

                System.Drawing.Bitmap bitMap = new System.Drawing.Bitmap(102, 120);
                System.Drawing.Point atPoint = new System.Drawing.Point(bitMap.Width / 2, bitMap.Height - 18);
                System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage((System.Drawing.Image)bitMap);
                graphics.Clear(System.Drawing.Color.White);
                graphics.DrawImage(img, 0, 0, 100, 100);

                System.Drawing.StringFormat format = new System.Drawing.StringFormat()
                {
                    Alignment = System.Drawing.StringAlignment.Center,
                    FormatFlags = System.Drawing.StringFormatFlags.DisplayFormatControl,
                    LineAlignment = System.Drawing.StringAlignment.Near,
                    Trimming = System.Drawing.StringTrimming.None
                };

                graphics.DrawString(name, drawFont, drawBrush, atPoint, format);
                System.Drawing.Image img1 = (System.Drawing.Image)bitMap;

                MemoryStream ms = new MemoryStream();                
                img1.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                data = ms.ToArray();
                graphics.Dispose();
            }
            return data;
        }


    }
}
