using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgileQuoteAdminProperty.Property;
using System.ServiceModel;
using LogWriter;

namespace AgileQuoteAdmin.Controllers
{
    public class CurrencyController : Controller
    {
        AgileAdminService.IService1 Service = new AgileAdminService.Service1Client();

        [HttpGet]
        public ActionResult Currency()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "LogIn");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Currency(CurrencyProperty oCurrency)
        {
            try
            {
                if (Session["UserID"] == null)
                {
                    return RedirectToAction("LogIn", "LogIn");
                }

                if (ModelState.IsValid)
                {
                    var Result = Service.InsertCurrencyRecordService(oCurrency);
                    if (Result == "Success")
                    {
                        return RedirectToAction("PartialCurrency", "Currency");

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, Result);
                        return View(oCurrency);
                    }
                }
            }
            catch (FaultException<ExceptionClass> Ex)
            {
                LogWriter.LogWriter.Log(Ex.Detail.StackTrace + "-" + Ex.Detail.ErrorReason);
            }
            return View(oCurrency);
        }

        public ActionResult PartialCurrency()
        {
            CurrencyListProperty cList = new CurrencyListProperty();

            try
            {
                if (Session["UserID"] == null)
                {
                    return RedirectToAction("LogIn", "LogIn");
                }

                cList.CurrencyList = Service.GetCurrencyListService();

            }
            catch (FaultException<ExceptionClass> Ex)
            {
                LogWriter.LogWriter.Log(Ex.Detail.StackTrace + "-" + Ex.Detail.ErrorReason);

            }
            return PartialView(cList);
        }

        public JsonResult CreateCurrency(string CurrencyCode, string CurrencyName, decimal Amount)
        {
            string redirectAction = string.Empty;
            bool redirect = false;
            string Result = string.Empty;
            CurrencyProperty oProperty = new CurrencyProperty { CurrencyCode = CurrencyCode, CurrencyName = CurrencyName, Amount = Amount, IsActive = true, IsDelete = false };

            if (Session["UserID"] != null)
            {
                Result = Service.InsertCurrencyRecordService(oProperty);
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

        [HttpGet]
        public ActionResult EditCurrency(int CurrencyId)
        {
            try
            {
                if (Session["UserID"] == null)
                {
                    return RedirectToAction("LogIn", "LogIn");
                }

                CurrencyProperty cProperty = Service.GetSingleCurrencyRecordService(CurrencyId);
                if (cProperty != null)
                {
                    return View(cProperty);
                }
            }
            catch (FaultException<ExceptionClass> Ex)
            {
                LogWriter.LogWriter.Log(Ex.Detail.StackTrace + "-" + Ex.Detail.ErrorReason);

            }
            return View();
        }

        [HttpPost]
        public ActionResult EditCurrency(CurrencyProperty oCurrency)
        {
            try
            {
                if (Session["UserID"] == null)
                {
                    return RedirectToAction("LogIn", "LogIn");
                }

                if (ModelState.IsValid)
                {
                    var Result = Service.UpdateCurrencyService(oCurrency);
                    if (Result == "Success")
                    {
                        return RedirectToAction("PartialCurrency", "Currency");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, Result);
                        return View(oCurrency);
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
        public JsonResult EditCurrencyRecord(int CurrencyId)
        {
            CurrencyProperty oCurrencyProperty = new CurrencyProperty();
            oCurrencyProperty = Service.GetSingleCurrencyRecordService(CurrencyId);
            return Json(new
            {
                oCurrencyProperty
            });


        }


        [HttpPost]
        public JsonResult UpdateCurrencyRecord(int CurrencyId, string CurrencyCode, string CurrencyName, decimal Amount, bool IsActive, bool IsDelete)
        {
            object oUpdate = null;
            CurrencyProperty oCurrencyProperty = new CurrencyProperty();
            oCurrencyProperty.CurrencyId = CurrencyId;
            oCurrencyProperty.CurrencyCode = CurrencyCode;
            oCurrencyProperty.CurrencyName = CurrencyName;
            oCurrencyProperty.Amount = Amount;
            oCurrencyProperty.IsActive = IsActive;
            oCurrencyProperty.IsDelete = IsDelete;
            try
            {
                var Result = Service.UpdateCurrencyService(oCurrencyProperty);
                oUpdate = new
                {
                    Result
                };
            }
            catch (FaultException<ExceptionClass> Ex)
            {
                LogWriter.LogWriter.Log(Ex.Detail.StackTrace + "-" + Ex.Detail.ErrorReason);

            }
            return Json(oUpdate);
        }



        [HttpPost]
        public JsonResult DeleteCurrency(int CurrencyId)
        {
            object currency = null;
            try
            {

                var Result = Service.DeleteCurrrencyService(CurrencyId);
                currency = new
                {
                    Result
                };
            }
            catch (FaultException<ExceptionClass> Ex)
            {
                LogWriter.LogWriter.Log(Ex.Detail.StackTrace + "-" + Ex.Detail.ErrorReason);

            }
            return Json(currency);
        }
    }
}
