using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgileQuoteAdminProperty.Property;
using LogWriter;
using System.ServiceModel;
namespace AgileQuoteAdmin.Controllers
{
    public class SalesOrganizationController : Controller
    {
        //
        // GET: /SalesOrganization/
        AgileAdminService.IService1 Service = new AgileAdminService.Service1Client();
        [HttpGet]
        public ActionResult SalesOrganization()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SalesOrganization(SalesOrganizationProperty oSales)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var result = Service.InsertRecordService(oSales);
                    if (result == "Success")
                    {
                        return RedirectToAction("SalesOrganizationPartial", "SalesOrganization");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result);
                        return View(oSales);
                    }
                }
                catch (FaultException<ExceptionClass> ex)
                {
                    LogWriter.LogWriter.Log(ex.Detail.StackTrace + "-" + ex.Detail.ErrorReason);
                }
            }
            return View();
        }

        [HttpPost]
        public JsonResult CreateSalesOrganization(string SalesName, string ReferenceCode)
        {
            string redirectAction = string.Empty;
            bool redirect = false;
            string Result = string.Empty;
            SalesOrganizationProperty oProperty = new SalesOrganizationProperty { SalesOrgName = SalesName, ReferenceCustomerCode = ReferenceCode, IsActive = true, IsDelete = false };

            if (Session["UserID"] != null)
            {
                Result = Service.InsertRecordService(oProperty);
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

        public ActionResult SalesOrganizationPartial()
        {
            SalesOrgranizationPropertyList SalesList = new SalesOrgranizationPropertyList();
            try
            {
                var Obj = Service.GetSalesOrganizationListService();
                SalesList.SalesOrganizationList = Obj;
            }
            catch (FaultException<ExceptionClass> ex)
            {
                LogWriter.LogWriter.Log(ex.Detail.ErrorReason + "-" + ex.Detail.StackTrace);

            }
            return PartialView(SalesList);
        }

        [HttpPost]
        public JsonResult EditSalesRecord(int SalesOrgCode)
        {
            SalesOrganizationProperty oSalesProperty = new SalesOrganizationProperty();
            oSalesProperty = Service.GetSalesOrganizationRecord(SalesOrgCode);
            return Json(new
            {
                oSalesProperty
            });
        }

        [HttpPost]
        public JsonResult UpdateSalesRecord(string SalesOrgCode, string SalesOrgName, string ReferenceCustomerCode, bool IsActive, bool IsDelete)
        {
            object oUpdateSales = null;
            SalesOrganizationProperty oSalesOrganization = new SalesOrganizationProperty();
            oSalesOrganization.SalesOrgCode = Convert.ToInt32(SalesOrgCode);
            oSalesOrganization.SalesOrgName = SalesOrgName;
            oSalesOrganization.ReferenceCustomerCode = ReferenceCustomerCode;
            oSalesOrganization.IsActive = IsActive;
            oSalesOrganization.IsDelete = IsDelete;
            try
            {
                var Result = Service.UpdateRecordService(oSalesOrganization);
                oUpdateSales = new
                {
                    Result
                };
            }
            catch (FaultException<ExceptionClass> ex)
            {
                LogWriter.LogWriter.Log(ex.Detail.ErrorReason + "-" + ex.Detail.StackTrace);

            }
            return Json(oUpdateSales);
        }

        [HttpPost]
        public JsonResult DeleteRecord(int SalesOrgCode)
        {
            object msg = null;
            try
            {
                var result = Service.DeleteRecordService(SalesOrgCode);

                msg = new
                {
                    result
                };
            }
            catch (FaultException<ExceptionClass> ex)
            {
                LogWriter.LogWriter.Log(ex.Detail.ErrorReason + "-" + ex.Detail.StackTrace);
            }
            return Json(msg);
        }
    }
}

