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
    public class RoleController : Controller
    {
        AgileAdminService.IService1 Service = new AgileAdminService.Service1Client();

        [HttpGet]
        public ActionResult RoleList()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "LogIn");
            }

            return View();
        }

        [HttpPost]
        public ActionResult RoleList(RoleProperty oRollProperty)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var result = Service.InsertRoleRecordService(oRollProperty);

                    if (result == "Success")
                    {
                        return RedirectToAction("RoleListPartial", "Role");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result);
                        return View(oRollProperty);
                    }
                }
            }
            catch (FaultException<ExceptionClass> rException)
            {
                LogWriter.LogWriter.Log(rException.Detail.ErrorReason + "-" + rException.Detail.StackTrace);
            }
            return View();
        }

        [HttpPost]
        public JsonResult CreateRole(string RoleName, int Priority)
        {
            string redirectAction = string.Empty;
            bool redirect = false;
            string Result = string.Empty;
            RoleProperty oProperty = new RoleProperty { RoleName = RoleName, Priority = Priority, IsVisible = true, IsDelete = false };

            if (Session["UserID"] != null)
            {
                Result = Service.InsertRoleRecordService(oProperty);
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

        public ActionResult RoleListPartial()
        {
            RoleListProperty Olistproperty = new RoleListProperty();
            try
            {
                if (Session["UserID"] == null)
                {
                    return RedirectToAction("LogIn", "LogIn");
                }

                Olistproperty.RoleList = Service.GetRoleListService();

            }
            catch (FaultException<ExceptionClass> rException)
            {
                LogWriter.LogWriter.Log(rException.Detail.ErrorReason + "-" + rException.Detail.StackTrace);
            }
            return View(Olistproperty);
        }

        [HttpPost]
        public JsonResult RoleEdit(int RoleId)
        {
            RoleProperty rProperty = new RoleProperty();
            rProperty = Service.GetSingleRoleRecordService(RoleId);
            return Json(new
            {
                rProperty
            });
        }

        [HttpPost]
        public JsonResult RoleUpdate(int RoleId, string RoleName, int Priority, bool IsActive, bool IsDelete)
        {
            RoleProperty rProperty = new RoleProperty();
            rProperty.RoleId = RoleId;
            rProperty.RoleName = RoleName;
            rProperty.Priority = Priority;
            rProperty.IsVisible = IsActive;
            rProperty.IsDelete = IsDelete;
            object result = null;
            try
            {
                var Eresult = Service.UpdateRoleService(rProperty);
                result = new
                {
                    Eresult
                };
            }

            catch (FaultException<ExceptionClass> rException)
            {
                LogWriter.LogWriter.Log(rException.Detail.ErrorReason + "-" + rException.Detail.StackTrace);
            }
            return Json(result);
        }
        [HttpPost]
        public JsonResult RoleDelete(int RoleID)
        {
            object result = null;
            try
            {
                var dObject = Service.DeleteRoleService(RoleID);
                result = new
                {
                    dObject
                };
            }
            catch (FaultException<ExceptionClass> rException)
            {
                LogWriter.LogWriter.Log(rException.Detail.ErrorReason + "-" + rException.Detail.StackTrace);
            }
            return Json(result);

        }


    }
}
