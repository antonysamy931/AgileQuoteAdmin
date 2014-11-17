using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;
using LogWriter;
using AgileQuoteAdminProperty.Property;

namespace AgileQuoteAdmin.Controllers
{
    public class CompanyController : Controller
    {
        //
        // GET: /Company/

        AgileAdminService.IService1 Service = new AgileAdminService.Service1Client();

        [HttpGet]
        public ActionResult Company()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "LogIn");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Company(CompanyProperty oCompanyProperty)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "LogIn");
            }

            try
            {
                if (ModelState.IsValid)
                {
                    var Result = Service.InsertCompanyNameService(oCompanyProperty);
                    if (Result == "Success")
                    {
                        return RedirectToAction("PartialCompany", "Company");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, Result);
                        return View(oCompanyProperty);
                    }
                }
            }
            catch (FaultException<ExceptionClass> Ex)
            {
                LogWriter.LogWriter.Log(Ex.Detail.StackTrace + "-" + Ex.Detail.ErrorReason);
            }
            return View();

        }

        [HttpPost]
        public JsonResult CreateCompany(string CompanyName)
        {
            string redirectAction = string.Empty;
            bool redirect = false;
            string Result = string.Empty;
            CompanyProperty oProperty = new CompanyProperty { CompanyCode = 0, CompanyName = CompanyName, IsActive = true, IsDelete = false };

            if (Session["UserID"] != null)
            {
                Result = Service.InsertCompanyNameService(oProperty);
            }
            else
            {
                redirectAction = Url.Action("LogIn", "LogIn");
                redirect = true;
            }

            return Json(new
            {
                redirect,
                redirectAction,
                Result
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PartialCompany()
        {
            CompanyNameList oCompanyNameList = new CompanyNameList();
            try
            {
                if (Session["UserID"] == null)
                {
                    return RedirectToAction("LogIn", "LogIn");
                }

                var oCompanyName = Service.GetCompanyNameService();
                oCompanyNameList.CompanyName = oCompanyName;
            }
            catch (FaultException<ExceptionClass> Ex)
            {
                LogWriter.LogWriter.Log(Ex.Detail.StackTrace + "-" + Ex.Detail.ErrorReason);

            }
            return PartialView(oCompanyNameList);
        }        

        [HttpPost]
        public JsonResult EditCompany(int CompanyCode)
        {
            object oCompany = null;
            try
            {
                CompanyProperty oCompanyProperty = new CompanyProperty();
                oCompanyProperty = Service.GetSingleCompanyName(CompanyCode);
                oCompany = new
                {
                    oCompanyProperty
                };
            }
            catch (FaultException<ExceptionClass> Ex)
            {
                LogWriter.LogWriter.Log(Ex.Detail.StackTrace + "-" + Ex.Detail.ErrorReason);

            }
            return Json(oCompany);
        }

        [HttpPost]
        public JsonResult UpdateCompany(int CompanyCode, string CompanyName, bool IsActive, bool IsDelete)
        {
            object oUpdateCompany = null;
            CompanyProperty oCompanyProperty = new CompanyProperty();
            oCompanyProperty.CompanyCode = CompanyCode;
            oCompanyProperty.CompanyName = CompanyName;
            oCompanyProperty.IsActive = IsActive;
            oCompanyProperty.IsDelete = IsDelete;
            try
            {
                var Result = Service.UpdateCompanyNameService(oCompanyProperty);
                oUpdateCompany = new
                {
                    Result
                };
            }
            catch (FaultException<ExceptionClass> Ex)
            {
                LogWriter.LogWriter.Log(Ex.Detail.StackTrace + "-" + Ex.Detail.ErrorReason);

            }
            return Json(oUpdateCompany);
        }

        [HttpPost]
        public JsonResult DeleteCompany(int CompanyCode)
        {
            object oDeleteCompany = null;
            try
            {
                var Result = Service.DeleteCompanyNameService(CompanyCode);
                oDeleteCompany = new
                {
                    Result
                };
            }
            catch (FaultException<ExceptionClass> Ex)
            {
                LogWriter.LogWriter.Log(Ex.Detail.StackTrace + "-" + Ex.Detail.ErrorReason);

            }
            return Json(oDeleteCompany);
        }

    }
}
