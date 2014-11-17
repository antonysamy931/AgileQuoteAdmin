using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;
using AgileQuoteAdminProperty.Property;
using AgileQuoteAdmin.Models;
using LogWriter;

namespace AgileQuoteAdmin.Controllers
{
    public class RentalSparsController : Controller
    {
        //
        // GET: /RentalSpars/
        AgileAdminService.IService1 Service = new AgileAdminService.Service1Client();
        [HttpGet]
        public ActionResult RentalSpars()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RentalSpars(RentalSparsProperty oRentalSpars, HttpPostedFileBase image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string Controller = "RentalSpars";
                    int RentalSparsID = Service.InsertRentalSparsService(oRentalSpars);                   
                    List<ImageProperty> oList = new List<ImageProperty>();
                    var Object = Service.GetImageService();
                    oList = Object;
                    ImageResizeMaterial oImageResize = new ImageResizeMaterial();
                    if (RentalSparsID!=0)
                    {
                        oImageResize.ImageResizefunction(Convert.ToString(RentalSparsID), oList, Controller);
                        return RedirectToAction("PartialRentalSpars", "RentalSpars");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, Convert.ToString(RentalSparsID));
                        return View(oRentalSpars);
                    }
                }
            }
            catch (FaultException<ExceptionClass> Ex)
            {
                LogWriter.LogWriter.Log(Ex.Detail.StackTrace + "-" + Ex.Detail.ErrorReason);
            }
            return View();
        }

        public ActionResult PartialRentalSpars()
        {
            RentalSparsListProperty oRentalList = new RentalSparsListProperty();
            try
            {
                
                var oList = Service.RentalSparsListService();
                oRentalList.RentalSparsList = oList;
            }
            catch (FaultException<ExceptionClass> Ex)
            {
                LogWriter.LogWriter.Log(Ex.Detail.StackTrace + "-" + Ex.Detail.ErrorReason);

            }
            return PartialView(oRentalList);
            
        }

        public JsonResult GetRentalSparsList(RentalDataTable oRentalTable)
        {
            RentalSparsListProperty oRentalSparsList = new RentalSparsListProperty();
            oRentalSparsList.RentalSparsList = Service.RentalSparsListService();

            IList<RentalSparsProperty> rAllList = new List<RentalSparsProperty>();
            rAllList = oRentalSparsList.RentalSparsList;

            IEnumerable<RentalSparsProperty> rFillter = null;
            rFillter = rAllList;

            var isRentalSparsIdSortable = Convert.ToBoolean(Request["bSortable_1"]);
            var isRentalSparsNameSortable = Convert.ToBoolean(Request["bSortable_2"]);
            var isDescriptionSortable = Convert.ToBoolean(Request["bSortable_3"]);
            var isWarrentySortable = Convert.ToBoolean(Request["bSortable_4"]);
            var isUnitPriceSortable = Convert.ToBoolean(Request["bSortable_5"]);
            var isDiscountSortable = Convert.ToBoolean(Request["bSortable_6"]);
            var isNetPriceSortable = Convert.ToBoolean(Request["bSortable_7"]);         

            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<RentalSparsProperty, string> orderingFunction = (c => sortColumnIndex == 1 && isRentalSparsIdSortable ? c.RentalSparsId.ToString() :
                sortColumnIndex == 2 && isRentalSparsNameSortable ? c.RentalSparsName :
                sortColumnIndex == 3 && isDescriptionSortable ? c.Description :
                sortColumnIndex == 4 && isWarrentySortable ? c.Warrenty.ToString() :
                sortColumnIndex == 5 && isUnitPriceSortable ? c.UnitPrice.ToString() :
                sortColumnIndex == 6 && isDiscountSortable ? c.Discount.ToString() :
                sortColumnIndex == 7 && isNetPriceSortable ? c.NetPrice.ToString() :
               
                "");

            var sortDirection = Request["sSortDir_0"]; // asc or desc

            if (sortDirection == "asc")
            {
                rFillter = rFillter.OrderBy(orderingFunction);
            }
            else
            {
                rFillter = rFillter.OrderByDescending(orderingFunction);
            }

            var displayMaterial = rFillter.Skip(oRentalTable.iDisplayStart).Take(oRentalTable.iDisplayLength);

            var result = from m in displayMaterial
                         select new[] { Convert.ToString(m.RentalSparsId),m.RentalSparsName,m.Description,
                                        Convert.ToString(m.Warrenty),Convert.ToString(m.UnitPrice),Convert.ToString(m.Discount),Convert.ToString(m.NetPrice)};

            return Json(new
            {
                sEcho = oRentalTable.sEcho,
                iTotalRecords = rAllList.Count(),
                iTotalDisplayRecords = rFillter.Count(),
                aaData = result
            }, JsonRequestBehavior.AllowGet);


        }

        [HttpGet]
        public ActionResult EditRentalSpars(int RentalSparsId)
        {
            try
            {
                var oEditRental = Service.SingleRentalSparsService(RentalSparsId);
                if (oEditRental != null)
                {
                    RentalSparsProperty oRentalSpars = oEditRental;
                    return View(oRentalSpars);
                }
            }
            catch (FaultException<ExceptionClass> Ex)
            {
                LogWriter.LogWriter.Log(Ex.Detail.StackTrace + "-" + Ex.Detail.ErrorReason);

            }
            return View();
        }

        [HttpPost]
        public ActionResult EditRentalSpars(RentalSparsProperty oRentalSpars, HttpPostedFileBase image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string Controller = "RentalSpars";
                    int RentalSparsID = Service.UpdateRentalSparsService(oRentalSpars);
                    List<ImageProperty> oList = new List<ImageProperty>();
                    var Object = Service.GetImageService();
                    oList = Object;
                    ImageResizeMaterial oImageResize = new ImageResizeMaterial();
                    if (RentalSparsID != 0)
                    {
                        oImageResize.ImageResizefunction(Convert.ToString(RentalSparsID), oList, Controller);
                        return RedirectToAction("PartialRentalSpars", "RentalSpars");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, Convert.ToString(RentalSparsID));
                        return View(oRentalSpars);
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
        public JsonResult DeleteRentalSpars(int RentalSparsId)
        {
            object RentalSpars = null;
            try
            {
                var Result = Service.DeleteRentalSparsService(RentalSparsId);
                RentalSpars = new
                {
                    Result
                };
            }
            catch (FaultException<ExceptionClass> Ex)
            {
                LogWriter.LogWriter.Log(Ex.Detail.StackTrace + "-" + Ex.Detail.ErrorReason);

            }
            return Json(RentalSpars);
        }

    }
}
