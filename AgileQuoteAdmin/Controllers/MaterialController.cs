using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgileQuoteAdminProperty.Property;
using AgileQuoteAdmin.Models;
using LogWriter;
using System.ServiceModel;
using AgileQuoteAdminProperty.Common;

namespace AgileQuoteAdmin.Controllers
{
    public class MaterialController : Controller
    {
        AgileAdminService.IService1 Service = new AgileAdminService.Service1Client();

        [HttpGet]
        public ActionResult Material()
        {
            MaterialProperty oMaterialProperty = new MaterialProperty();

            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "LogIn");
            }
            oMaterialProperty.CategoryList = Service.CategoryList();
            return View(oMaterialProperty);
        }

        [HttpPost]
        public ActionResult Material(MaterialProperty oMaterialProperty, HttpPostedFileBase image)
        {
            try
            {
                if (Session["UserID"] == null)
                {
                    return RedirectToAction("LogIn", "LogIn");
                }

                oMaterialProperty.CategoryList = Service.CategoryList();
                oMaterialProperty.HiddenWarrenty = oMaterialProperty.Warrenty.ToString();

                if (ModelState.IsValid)
                {
                    int MaterialId = Service.InsertMaterial(oMaterialProperty);
                    string Type = "Material";
                    List<ImageProperty> oList = Service.GetImageService();
                    ImageResizeMaterial oImageResize = new ImageResizeMaterial();
                    if (MaterialId != 0)
                    {
                        oImageResize.ImageResizefunction(Convert.ToString(MaterialId), oList, Type);
                        return RedirectToAction("MaterialGrid", "Material");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Material name or Code already exist.");
                        return View(oMaterialProperty);
                    }
                }
            }
            catch (FaultException<ExceptionClass> ex)
            {
                LogWriter.LogWriter.Log(ex.Detail.StackTrace + "-" + ex.Detail.ErrorReason);
            }

            return View(oMaterialProperty);
        }


        public ActionResult MaterialGrid()
        {
            MaterialListProperty oMaterialListProperty = new MaterialListProperty();

            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "LogIn");
            }

            try
            {
                oMaterialListProperty.MaterialList = Service.GetMaterialListService(); ;
            }
            catch (FaultException<ExceptionClass> ex)
            {
                LogWriter.LogWriter.Log(ex.Detail.StackTrace + "-" + ex.Detail.ErrorReason);
            }

            return PartialView(oMaterialListProperty);
        }


        [HttpGet]
        public ActionResult EditMaterial(int MaterialID)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "LogIn");
            }

            try
            {
                MaterialProperty oMaterialProperty = Service.GetMaterialListByID(MaterialID);

                oMaterialProperty.CategoryList = Service.CategoryList();
                oMaterialProperty.HiddenWarrenty = oMaterialProperty.Warrenty.ToString();

                if (oMaterialProperty != null)
                {
                    return View(oMaterialProperty);
                }
            }
            catch (FaultException<ExceptionClass> ex)
            {
                LogWriter.LogWriter.Log(ex.Detail.StackTrace + "-" + ex.Detail.ErrorReason);
            }

            return View();
        }

        [HttpPost]
        public ActionResult EditMaterial(MaterialProperty oMaterialProperty, HttpPostedFileBase image)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "LogIn");
            }

            try
            {
                oMaterialProperty.HiddenWarrenty = oMaterialProperty.Warrenty.ToString();
                oMaterialProperty.CategoryList = Service.CategoryList();
                if (ModelState.IsValid)
                {
                    int MaterialId = Service.UpdateMaterial(oMaterialProperty);
                    string Type = "Material";
                    List<ImageProperty> oList = Service.GetImageService();
                    ImageResizeMaterial oImageResize = new ImageResizeMaterial();
                    if (MaterialId != 0)
                    {
                        oImageResize.ImageResizefunction(Convert.ToString(MaterialId), oList, Type);
                        return RedirectToAction("MaterialGrid", "Material");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Material name or Code already exist.");
                        return View(oMaterialProperty);
                    }
                }
            }
            catch (FaultException<ExceptionClass> ex)
            {
                LogWriter.LogWriter.Log(ex.Detail.StackTrace + "-" + ex.Detail.ErrorReason);
            }
            return View(oMaterialProperty);
        }

        [HttpPost]
        public JsonResult DeleteMaterial(int MaterialID)
        {
            object msg = null;
            try
            {
                var obj = Service.DeleteMaterial(MaterialID);
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

        [HttpGet]
        public ActionResult SugectionMaterial()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "LogIn");
            }

            return View();
        }

        public JsonResult GetMaterialList(string Category, int? MaterialID, jQueryDataTableParamModel param)
        {
            MaterialListProperty oMaterialPropertyList = new MaterialListProperty();
            oMaterialPropertyList.MaterialList = Service.GetMaterialListBasedOnCategory(Category);
            IList<MaterialProperty> qAllList = new List<MaterialProperty>();
            if (MaterialID != null)
            {
                oMaterialPropertyList.MaterialList = Service.GetMaterialListService();
                qAllList = oMaterialPropertyList.MaterialList.Where(x => x.MaterialID != MaterialID.Value).ToList();
            }
            else
            {
                qAllList = oMaterialPropertyList.MaterialList;
            }
            IEnumerable<MaterialProperty> qFillterMaterial = null;

            if (!string.IsNullOrEmpty(param.sSearch))
            {
                //Used if particulare columns are filtered 
                var CodeFilter = Convert.ToString(Request["sSearch_2"]);
                var NameFilter = Convert.ToString(Request["sSearch_3"]);
                var DiscountFilter = Convert.ToString(Request["sSearch_4"]);
                var NetPriceFilter = Convert.ToString(Request["sSearch_5"]);

                //Optionally check whether the columns are searchable at all 
                var isCodeSearchable = Convert.ToBoolean(Request["bSearchable_2"]);
                var isNameSearchable = Convert.ToBoolean(Request["bSearchable_3"]);
                var isDiscountSearchable = Convert.ToBoolean(Request["bSearchable_4"]);
                var isNetPriceSearchable = Convert.ToBoolean(Request["bSearchable_5"]);

                qFillterMaterial = qAllList.Where(c => isCodeSearchable && Convert.ToString(c.MaterialCode).ToLower().Contains(param.sSearch.ToLower())
                    || isNameSearchable && c.MaterialName.ToLower().Contains(param.sSearch.ToLower())
                    || isDiscountSearchable && c.MaterialDiscount.ToString().ToLower().Contains(param.sSearch.ToLower())
                    || isNetPriceSearchable && c.MaterialAmount.ToString().ToLower().Contains(param.sSearch.ToLower())
                    );

            }
            else
            {
                qFillterMaterial = qAllList;
            }

            var isCodeSortable = Convert.ToBoolean(Request["bSortable_2"]);
            var isNameSortable = Convert.ToBoolean(Request["bSortable_3"]);
            var isDiscountSortable = Convert.ToBoolean(Request["bSortable_4"]);
            var isNetPriceSortable = Convert.ToBoolean(Request["bSortable_5"]);

            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);


            Func<MaterialProperty, string> orderingFunction = (c => sortColumnIndex == 2 && isCodeSortable ? c.MaterialCode.ToString() :
                sortColumnIndex == 3 && isNameSortable ? c.MaterialName :
                sortColumnIndex == 8 && isDiscountSortable ? c.MaterialDiscount.ToString() :
                sortColumnIndex == 9 && isNetPriceSortable ? c.MaterialAmount.ToString() :
                "");

            var sortDirection = Request["sSortDir_0"]; // asc or desc

            if (sortDirection == "asc")
            {
                qFillterMaterial = qFillterMaterial.OrderBy(orderingFunction);
            }
            else
            {
                qFillterMaterial = qFillterMaterial.OrderByDescending(orderingFunction);
            }

            var displayMaterial = qFillterMaterial.Skip(param.iDisplayStart).Take(param.iDisplayLength);

            var result = from m in displayMaterial
                         select new[] { 
                             Convert.ToString(m.MaterialID), 
                             Convert.ToString(m.MaterialID), 
                             Convert.ToString(m.MaterialCode), 
                             m.MaterialName, 
                             Convert.ToString(m.MaterialDiscount) + "%", 
                             Convert.ToString(m.Quantity),
                             Convert.ToString( Extension.MathRound(m.MaterialAmount)),
                             Category
                             };

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = qAllList.Count(),
                iTotalDisplayRecords = qFillterMaterial.Count(),
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMaterialListBasedOnId(int? MaterialID, jQueryDataTableParamModel param)
        {
            MaterialListProperty oMaterialPropertyList = new MaterialListProperty();
            oMaterialPropertyList.MaterialList = Service.GetMaterialListService();

            IList<MaterialProperty> qAllList = new List<MaterialProperty>();
            qAllList = oMaterialPropertyList.MaterialList.Where(x => x.MaterialID != MaterialID.Value).ToList();

            IEnumerable<MaterialProperty> qFillterMaterial = null;

            if (!string.IsNullOrEmpty(param.sSearch))
            {
                //Used if particulare columns are filtered 
                var CodeFilter = Convert.ToString(Request["sSearch_1"]);
                var NameFilter = Convert.ToString(Request["sSearch_2"]);
                var DiscountFilter = Convert.ToString(Request["sSearch_3"]);
                var NetPriceFilter = Convert.ToString(Request["sSearch_4"]);

                //Optionally check whether the columns are searchable at all 
                var isCodeSearchable = Convert.ToBoolean(Request["bSearchable_1"]);
                var isNameSearchable = Convert.ToBoolean(Request["bSearchable_2"]);
                var isDiscountSearchable = Convert.ToBoolean(Request["bSearchable_3"]);
                var isNetPriceSearchable = Convert.ToBoolean(Request["bSearchable_4"]);

                qFillterMaterial = qAllList.Where(c => isCodeSearchable && Convert.ToString(c.MaterialCode).ToLower().Contains(param.sSearch.ToLower())
                    || isNameSearchable && c.MaterialName.ToLower().Contains(param.sSearch.ToLower())
                    || isDiscountSearchable && c.MaterialDiscount.ToString().ToLower().Contains(param.sSearch.ToLower())
                    || isNetPriceSearchable && c.MaterialAmount.ToString().ToLower().Contains(param.sSearch.ToLower())
                    );

            }
            else
            {
                qFillterMaterial = qAllList;
            }

            var isCodeSortable = Convert.ToBoolean(Request["bSortable_1"]);
            var isNameSortable = Convert.ToBoolean(Request["bSortable_2"]);
            var isDiscountSortable = Convert.ToBoolean(Request["bSortable_3"]);
            var isNetPriceSortable = Convert.ToBoolean(Request["bSortable_4"]);

            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);


            Func<MaterialProperty, string> orderingFunction = (c => sortColumnIndex == 1 && isCodeSortable ? c.MaterialCode.ToString() :
                sortColumnIndex == 2 && isNameSortable ? c.MaterialName :
                sortColumnIndex == 8 && isDiscountSortable ? c.MaterialDiscount.ToString() :
                sortColumnIndex == 9 && isNetPriceSortable ? c.MaterialAmount.ToString() :
                "");

            var sortDirection = Request["sSortDir_0"]; // asc or desc

            if (sortDirection == "asc")
            {
                qFillterMaterial = qFillterMaterial.OrderBy(orderingFunction);
            }
            else
            {
                qFillterMaterial = qFillterMaterial.OrderByDescending(orderingFunction);
            }

            var displayMaterial = qFillterMaterial.Skip(param.iDisplayStart).Take(param.iDisplayLength);

            var result = from m in displayMaterial
                         select new[] { 
                             Convert.ToString(m.MaterialID), Convert.ToString(m.MaterialCode), 
                             m.MaterialName, Convert.ToString(m.MaterialDiscount) + "%", 
                             Convert.ToString(m.Quantity==0?1:m.Quantity),Convert.ToString( Extension.MathRound(m.MaterialAmount))
                             };

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = qAllList.Count(),
                iTotalDisplayRecords = qFillterMaterial.Count(),
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult InsertSugestionMaterial(string materialList, int MaterialId)
        {
            string redirectAction = string.Empty;
            bool redirect = false;
            string Result = string.Empty;
            List<int> oMaterialList = new List<int>();

            if (Session["UserID"] != null)
            {
                var Record = materialList.Split(',');
                foreach (var item in Record)
                {
                    oMaterialList.Add(Convert.ToInt32(item));
                }
                Result = Service.SugectionMaterialMapping(oMaterialList, MaterialId);
            }
            else
            {
                redirectAction = Url.Action("LogIn", "LogIn");
                redirect = true;
            }

            return Json(new
            {
                Result,
                redirect,
                redirectAction
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SugectionMappingMaterial(int MaterialId)
        {
            string redirectAction = string.Empty;
            bool redirect = false;
            var Result = new List<MaterialProperty>();

            if (Session["UserID"] != null)
            {
                Result = Service.GetMaterialMappingSugectionMaterial(MaterialId);
            }
            else
            {
                redirectAction = Url.Action("LogIn", "LogIn");
                redirect = true;
            }

            return Json(new
            {
                Result,
                redirect,
                redirectAction
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteMappingMaterial(int MaterialID, int MappingMaterial)
        {
            string redirectAction = string.Empty;
            bool redirect = false;
            string Result = string.Empty;

            if (Session["UserID"] != null)
            {
                Result = Service.DeleteSugectionMaterial(MaterialID, MappingMaterial);
            }
            else
            {
                redirectAction = Url.Action("LogIn", "LogIn");
                redirect = true;
            }

            return Json(new
            {
                Result,
                redirect,
                redirectAction
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult OfferedMaterials()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "LogIn");
            }

            return View();
        }

        public JsonResult InsertOfferedMaterial(string materialList, int MaterialId)
        {
            string redirectAction = string.Empty;
            bool redirect = false;
            string Result = string.Empty;
            List<int> oMaterialList = new List<int>();

            if (Session["UserID"] != null)
            {
                var Record = materialList.Split(',');
                foreach (var item in Record)
                {
                    oMaterialList.Add(Convert.ToInt32(item));
                }
                Result = Service.OfferedMaterialMapping(oMaterialList, MaterialId);
            }
            else
            {
                redirectAction = Url.Action("LogIn", "LogIn");
                redirect = true;
            }

            return Json(new
            {
                Result,
                redirect,
                redirectAction
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult OfferedMappingMaterial(int MaterialId)
        {
            string redirectAction = string.Empty;
            bool redirect = false;
            var Result = new List<MaterialProperty>();

            if (Session["UserID"] != null)
            {
                Result = Service.GetMaterialMappingOfferedMaterial(MaterialId);
            }
            else
            {
                redirectAction = Url.Action("LogIn", "LogIn");
                redirect = true;
            }

            return Json(new
            {
                Result,
                redirect,
                redirectAction
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteOfferedMappingMaterial(int MaterialID, int MappingMaterial)
        {
            string redirectAction = string.Empty;
            bool redirect = false;
            string Result = string.Empty;

            if (Session["UserID"] != null)
            {
                Result = Service.DeleteOfferedMaterial(MaterialID, MappingMaterial);
            }
            else
            {
                redirectAction = Url.Action("LogIn", "LogIn");
                redirect = true;
            }

            return Json(new
            {
                Result,
                redirect,
                redirectAction
            }, JsonRequestBehavior.AllowGet);
        }

    }
}
