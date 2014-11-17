using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgileQuoteAdminProperty.Property;
using LogWriter;
using ImageResizer;
using AgileQuoteAdmin.Models;
using System.ServiceModel;


namespace AgileQuoteAdmin.Controllers
{
    public class RentalProductsController : Controller
    {
        AgileAdminService.IService1 Service = new AgileAdminService.Service1Client();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RentalProducts()
        {

            return View();
        }
        public ActionResult RentalProductDataTable()
        {
            RentalProductsListProperty oRentalProduct = new RentalProductsListProperty();
            try
            {
                
                var oRentalProductList = Service.GetRentalProductsListService();
                oRentalProduct.RentalProductsList = oRentalProductList;
            }
            catch (FaultException<ExceptionClass> ex)
            {
                LogWriter.LogWriter.Log(ex.Detail.StackTrace + "-" + ex.Detail.ErrorReason);
            }
            return View(oRentalProduct);
            
        }
        [HttpPost]
        public ActionResult RentalProducts(RentalProductsProperty omp, HttpPostedFileBase image)
        {
            try
            {
                string Controller = "RentalProducts";
                int RentalID = Service.InsertRentalProducts(omp);
                List<ImageProperty> oList = new List<ImageProperty>();
                var Object = Service.GetImageService();
                oList = Object;
                ImageResizeMaterial oImageResize = new ImageResizeMaterial();       
                               
                    if (RentalID!=0)
                    {
                        oImageResize.ImageResizefunction(Convert.ToString(RentalID), oList, Controller);
                        return RedirectToAction("RentalProductsGrid", "RentalProducts");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty,Convert.ToString(RentalID));
                        return View(omp);
                    }
               
            }
            catch (FaultException<ExceptionClass> ex)
            {
                LogWriter.LogWriter.Log(ex.Detail.StackTrace + "-" + ex.Detail.ErrorReason);
            }
            return View();
        }
        

        public ActionResult Temp()
        {
            return View();
        }
 

        public JsonResult RentalProductsGrid(jQueryDataTableParamModel param, string s)
        {
            RentalProductsListProperty oRentalProductsListProperty = new RentalProductsListProperty();
            var obj = Service.GetRentalProductsListService();
            oRentalProductsListProperty.RentalProductsList = obj;

            IList<RentalProductsProperty> qAllList = new List<RentalProductsProperty>();
            qAllList = oRentalProductsListProperty.RentalProductsList;
            IEnumerable<RentalProductsProperty> qFillterRentalProducts = null;
            
                qFillterRentalProducts = qAllList;
                var isIDSortable = Convert.ToBoolean(Request["bSortable_1"]);
                var isNameSortable = Convert.ToBoolean(Request["bSortable_2"]);
                var isDescriptionSortable = Convert.ToBoolean(Request["bSortable_3"]);
                var isWarrentySortable = Convert.ToBoolean(Request["bSortable_4"]);
                var isUnitPriceSortable = Convert.ToBoolean(Request["bSortable_5"]);
                var isDiscountSortable = Convert.ToBoolean(Request["bSortable_6"]);
                var isNetPriceSortable = Convert.ToBoolean(Request["bSortable_7"]); 
             
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);


                Func<RentalProductsProperty, string> orderingFunction = (c => sortColumnIndex == 1 && isIDSortable ? c.RentalProductsID.ToString() :
                    sortColumnIndex == 2 && isNameSortable ? c.RentalProductsName :
                    sortColumnIndex == 3 && isDescriptionSortable ? c.Description :
                    sortColumnIndex == 4 && isWarrentySortable ? c.Warrenty.ToString() :               
                    sortColumnIndex == 5 && isUnitPriceSortable ? c.UnitPrice.ToString() :
                    sortColumnIndex == 6 && isDiscountSortable ? c.Discount.ToString() :
                    sortColumnIndex == 7 && isNetPriceSortable ? c.NetPrice.ToString() : 
                    "");

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
            {
                qFillterRentalProducts = qFillterRentalProducts.OrderBy(orderingFunction);
            }
            else
            {
                qFillterRentalProducts = qFillterRentalProducts.OrderByDescending(orderingFunction);
            }

            var displayMaterial = qFillterRentalProducts.Skip(param.iDisplayStart).Take(param.iDisplayLength);
          
            //var result = from m in displayMaterial
            //             select new[] { Convert.ToString(m.RentalProductsID), Convert.ToString(m.RentalProductsName),m.Description,m.Warrenty,Convert.ToString(m.UnitPrice),Convert.ToString(m.Discount),
            //                            Convert.ToString(m.NetPrice),Convert.ToString(m.UnitPrice),Convert.ToString(m.Discount),Convert.ToString(m.NetPrice)};

            
            var result = from m in displayMaterial
                         select new[] { Convert.ToString(m.RentalProductsID),  m.RentalProductsName,m.Description,Convert.ToString(m.Warrenty),
                                        Convert.ToString(m.UnitPrice),Convert.ToString(m.Discount),Convert.ToString(m.NetPrice)};


            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = qAllList.Count(),
                iTotalDisplayRecords = qFillterRentalProducts.Count(),
                aaData = result
            }, JsonRequestBehavior.AllowGet);         

        }


        [HttpGet]
        public ActionResult EditRentalProducts(int RentalProductsID)
        {
            RentalProductsProperty oRentalProductsProperty = Service.GetRentalProductsListByID(RentalProductsID);
            try
            {
                if (oRentalProductsProperty != null)
                {
                    return View(oRentalProductsProperty);
                }
            }
            catch (FaultException<ExceptionClass> ex)
            {
                LogWriter.LogWriter.Log(ex.Detail.StackTrace + "-" + ex.Detail.ErrorReason);
            }

            return View();
        }

        [HttpPost]
        public ActionResult EditRentalProducts(RentalProductsProperty oRentalProductsProperty, HttpPostedFileBase image)
        {
            try
            {
                string Controller = "RentalProducts";
                int RentalID = Service.UpdateRentalProducts(oRentalProductsProperty);
                List<ImageProperty> oList = new List<ImageProperty>();
                //var obj = Service.UpdateRentalProducts(oRentalProductsProperty);
                var Object = Service.GetImageService();
                oList = Object;
                ImageResizeMaterial oImageResize = new ImageResizeMaterial();
                if (RentalID != 0)
                {
                    oImageResize.ImageResizefunction(Convert.ToString(RentalID), oList, Controller);
                    return RedirectToAction("RentalProducts", "RentalProducts");
                    
                }
               
                
         
                else
                {
                    ModelState.AddModelError(string.Empty,Convert.ToString(RentalID));
                    return View(oRentalProductsProperty);
                }
            }

            catch (FaultException<ExceptionClass> ex)
            {
                LogWriter.LogWriter.Log(ex.Detail.StackTrace + "-" + ex.Detail.ErrorReason);
            }
            return View();
        }
        [HttpPost]
        public JsonResult DeleteRentalProducts(int RentalProductsID)
        {
            object msg = null;
            try
            {
                var obj = Service.DeleteRentalProducts(RentalProductsID);
                msg = new
                {
                    obj
                };

            }
            catch (FaultException<ExceptionClass> ex)
            {
                LogWriter.LogWriter.Log(ex.Detail.StackTrace + "-" + ex.Detail.ErrorReason);
            }
            return Json(msg);
        }
    }
}
