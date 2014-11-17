using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgileQuoteAdminProperty.Property;
using System.ServiceModel;
using System.Configuration;
using Recaptcha;
using LogWriter;

namespace AgileQuoteAdmin.Controllers
{
    public class LogInController : Controller
    {

        AgileAdminService.IService1 Service = new AgileAdminService.Service1Client();

        [HttpGet]
        public ActionResult LogIn()
        {
            //int random;
            //Random r = new Random();
            LoginProperty oLogIn = new LoginProperty();
            try
            {
                //random = r.Next(10000, 99999);
                //ViewBag.RandomNumber = random;
                //Session["Random"] = random;
                oLogIn.CompanyNameList = Service.CompanyNameService();
            }
            catch (Exception ex)
            {
                LogWriter.LogWriter.Log(ex.StackTrace);
            }
            return View(oLogIn);
        }

        [HttpPost]
        public ActionResult LogIn(LoginProperty oLogIn)
        {
            try
            {
                //RecaptchaValidator recaptchaValidator = new RecaptchaValidator();
                //recaptchaValidator.Challenge = HttpContext.Request.Form["recaptcha_challenge_field"];
                //recaptchaValidator.Response = HttpContext.Request.Form["recaptcha_response_field"];
                //recaptchaValidator.PrivateKey = ConfigurationManager.AppSettings["ReCaptchaPrivateKey"].ToString();
                //recaptchaValidator.RemoteIP = HttpContext.Request.UserHostAddress;
                //RecaptchaResponse recaptchaResponse = !string.IsNullOrEmpty(recaptchaValidator.Challenge) ? (!string.IsNullOrEmpty(recaptchaValidator.Response) ? recaptchaValidator.Validate() : RecaptchaResponse.InvalidResponse) : RecaptchaResponse.InvalidChallenge;

                oLogIn.CompanyNameList = Service.CompanyNameService();

                var oCompanyName = oLogIn.CompanyNameList.Where(x => x.Name == oLogIn.CompanyName).FirstOrDefault();
                if (oCompanyName != null)
                {
                    oLogIn.CompanyName = oCompanyName.Name;
                }
                if (ModelState.IsValid)
                {
                    if (Service.CheckAuthentication(oLogIn))
                    {
                        var user = Service.GetUserName(oLogIn);
                        foreach (var item in user)
                        {
                            Session["UserID"] = item.Key;
                            Session["UserName"] = item.Value;
                        }
                        return RedirectToAction("PartialUser", "UserRegistration");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Authentication Failed");
                    }
                }
                //int random;
                //Random r = new Random();
                //random = r.Next(10000, 99999);
                //ViewBag.RandomNumber = random;
                //Session["Random"] = random;

            }

            catch (FaultException<ExceptionClass> Ex)
            {
                LogWriter.LogWriter.Log(Ex.Detail.StackTrace + "-" + Ex.Detail.ErrorReason);

            }
            return View(oLogIn);

        }

        public ActionResult GetImage(int id)
        {
            byte[] image = null;

            try
            {
                image = Service.GetUserImage(id);
                if (image == null)
                {
                    return new EmptyResult();
                }
            }
            catch (FaultException<ExceptionClass> Ex)
            {
                LogWriter.LogWriter.Log(Ex.Detail.StackTrace + "-" + Ex.Detail.ErrorReason);

            }
            return File(image, "image/jpeg");
        }

        public ActionResult LogOut()
        {
            Session["UserID"] = null;
            Session["UserName"] = null;
            return RedirectToAction("LogIn", "LogIn");
        }

    }
}
