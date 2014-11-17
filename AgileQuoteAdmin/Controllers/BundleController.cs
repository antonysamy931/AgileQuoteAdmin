using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgileQuoteAdminProperty.Common;
using AgileQuoteAdminProperty.Property;

namespace AgileQuoteAdmin.Controllers
{
    public class BundleController : Controller
    {


        AgileAdminService.IService1 Service = new AgileAdminService.Service1Client();

        [HttpGet]
        public ActionResult Bundle()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "LogIn");
            }

            return View();
        }

        public JsonResult GetMaterialList(string Category, jQueryDataTableParamModel param)
        {
            MaterialListProperty oMaterialPropertyList = new MaterialListProperty();
            oMaterialPropertyList.MaterialList = Service.GetMaterialListBasedOnCategory(Category);
            IList<MaterialProperty> qAllList = new List<MaterialProperty>();
            qAllList = oMaterialPropertyList.MaterialList;
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
                             Convert.ToString(m.Quantity),Convert.ToString( Extension.MathRound(m.MaterialAmount))
                             };

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = qAllList.Count(),
                iTotalDisplayRecords = qFillterMaterial.Count(),
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBundleList(string Category, jQueryDataTableParamModel param)
        {
            BundleListProperty oBundlePropertyList = new BundleListProperty();
            oBundlePropertyList.BundleList = Service.GetBundleListBasedOnCategory(Category);

            IList<BundleProperty> qAllList = new List<BundleProperty>();
            qAllList = oBundlePropertyList.BundleList;
            IEnumerable<BundleProperty> qFillterBundle = null;

            if (!string.IsNullOrEmpty(param.sSearch))
            {
                //Used if particulare columns are filtered 
                var CodeFilter = Convert.ToString(Request["sSearch_1"]);
                var NameFilter = Convert.ToString(Request["sSearch_2"]);
                var DescriptionFilter = Convert.ToString(Request["sSearch_3"]);
                var UnitPriceFilter = Convert.ToString(Request["sSearch_4"]);
                var DiscountFilter = Convert.ToString(Request["sSearch_5"]);
                var QuantityFilter = Convert.ToString(Request["sSearch_6"]);
                var NetPriceFilter = Convert.ToString(Request["sSearch_7"]);

                //Optionally check whether the columns are searchable at all 
                var isCodeSearchable = Convert.ToBoolean(Request["bSearchable_1"]);
                var isNameSearchable = Convert.ToBoolean(Request["bSearchable_2"]);
                var isDescriptionSearchable = Convert.ToBoolean(Request["bSearchable_3"]);
                var isUnitPriceSearchable = Convert.ToBoolean(Request["bSearchable_4"]);
                var isDiscountSearchable = Convert.ToBoolean(Request["bSearchable_5"]);
                var isQuantitySearchable = Convert.ToBoolean(Request["bSearchable_6"]);
                var isNetPriceSearchable = Convert.ToBoolean(Request["bSearchable_7"]);

                qFillterBundle = qAllList.Where(c => isCodeSearchable && Convert.ToString(c.BundleId).ToLower().Contains(param.sSearch.ToLower())
                    || isNameSearchable && c.BundleName.ToLower().Contains(param.sSearch.ToLower())
                    || isDescriptionSearchable && c.BundleDescription.ToLower().Contains(param.sSearch.ToLower())
                    || isUnitPriceSearchable && c.BundleUnitPrice.ToString().ToLower().Contains(param.sSearch.ToLower())
                    || isDiscountSearchable && c.BundleDiscount.ToString().ToLower().Contains(param.sSearch.ToLower())
                    || isQuantitySearchable && c.Quantity.ToString().ToLower().Contains(param.sSearch.ToLower())
                    || isNetPriceSearchable && c.BundleNetPrice.ToString().ToLower().Contains(param.sSearch.ToLower())
                    );
            }
            else
            {
                qFillterBundle = qAllList;
            }

            var isCodeSortable = Convert.ToBoolean(Request["bSortable_1"]);
            var isNameSortable = Convert.ToBoolean(Request["bSortable_2"]);
            var isDescriptionSortable = Convert.ToBoolean(Request["bSortable_3"]);
            var isUnitPriceSortable = Convert.ToBoolean(Request["bSortable_4"]);
            var isDiscountSortable = Convert.ToBoolean(Request["bSortable_5"]);
            var isQuantitySortable = Convert.ToBoolean(Request["bSortable_6"]);
            var isNetPriceSortable = Convert.ToBoolean(Request["bSortable_7"]);

            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);


            Func<BundleProperty, string> orderingFunction = (c => sortColumnIndex == 1 && isCodeSortable ? c.BundleId.ToString() :
                sortColumnIndex == 2 && isNameSortable ? c.BundleName :
                sortColumnIndex == 3 && isDescriptionSortable ? c.BundleDescription :
                sortColumnIndex == 4 && isUnitPriceSortable ? c.BundleUnitPrice.ToString() :
                sortColumnIndex == 5 && isDiscountSortable ? c.BundleDiscount.ToString() :
                sortColumnIndex == 6 && isQuantitySortable ? c.Quantity.ToString() :
                sortColumnIndex == 7 && isNetPriceSortable ? c.BundleNetPrice.ToString() :
                "");

            var sortDirection = Request["sSortDir_0"]; // asc or desc

            if (sortDirection == "asc")
            {
                qFillterBundle = qFillterBundle.OrderBy(orderingFunction);
            }
            else
            {
                qFillterBundle = qFillterBundle.OrderByDescending(orderingFunction);
            }

            var displayMaterial = qFillterBundle.Skip(param.iDisplayStart).Take(param.iDisplayLength);

            var result = from m in displayMaterial
                         select new[] { Convert.ToString(m.BundleId), Convert.ToString(m.BundleId), m.BundleName,m.BundleDescription,
                             Convert.ToString(m.BundleUnitPrice),
                             Convert.ToString(m.BundleDiscount) + "%", 
                             Convert.ToString(m.Quantity),
                             Convert.ToString(m.BundleNetPrice) 
                         };

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = qAllList.Count(),
                iTotalDisplayRecords = qFillterBundle.Count(),
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetCategoryNameList()
        {
            List<string> CategoryName = new List<string>();
            CategoryName = Service.GetCategoryNameList();
            return Json(CategoryName);
        }

        [HttpPost]
        public JsonResult GetMaterialDetail(int MaterialID)
        {
            string redirectAction = string.Empty;
            bool redirect = false;


            if (Session["UserID"] != null)
            {
                MaterialProperty Result = Service.GetMaterialListByID(MaterialID);
                return Json(new
                {
                    redirect,
                    redirectAction,
                    Result
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                redirectAction = Url.Action("LogIn", "LogIn");
                redirect = true;
                return Json(new
                {
                    redirect,
                    redirectAction
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetBundleDetail(int BundleID)
        {
            string redirectAction = string.Empty;
            bool redirect = false;


            if (Session["UserID"] != null)
            {
                BundleProperty Result = Service.GetBundleSingleRecord(BundleID);
                return Json(new
                {
                    redirect,
                    redirectAction,
                    Result
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                redirectAction = Url.Action("LogIn", "LogIn");
                redirect = true;
                return Json(new
                {
                    redirect,
                    redirectAction
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetBundleMappingMaterial(int BundleID)
        {
            string redirectAction = string.Empty;
            bool redirect = false;


            if (Session["UserID"] != null)
            {
                var Result = Service.GetBundleMappingMaterial(BundleID);
                return Json(new
                {
                    redirect,
                    redirectAction,
                    Result
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                redirectAction = Url.Action("LogIn", "LogIn");
                redirect = true;
                return Json(new
                {
                    redirect,
                    redirectAction
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult InsertBundleRecord(string BundleName, string BundleDescription, int? Warrenty, string MaterialQuantity)
        {
            string redirectAction = string.Empty;
            bool redirect = false;
            string Result = string.Empty;

            Dictionary<int, int> MaterialIDQuantityList = new Dictionary<int, int>();
            if (!string.IsNullOrEmpty(MaterialQuantity))
            {
                var materialQuantity = MaterialQuantity.Split(',');
                foreach (var item in materialQuantity)
                {
                    var mObject = item.Split('_');
                    MaterialIDQuantityList.Add(Convert.ToInt32(mObject[0]), Convert.ToInt32(mObject[1]));
                }
            }

            if (Session["UserID"] != null)
            {
                Result = Service.InsertMaterialMappingToBundle(MaterialIDQuantityList, BundleName, (int)Session["UserID"], BundleDescription, Warrenty == null ? 0 : Warrenty.Value);
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

        [HttpPost]
        public JsonResult DeleteBundleRecord(int BundleID)
        {
            string redirectAction = string.Empty;
            bool redirect = false;
            string Result = string.Empty;

            if (Session["UserID"] != null)
            {
                Result = Service.DeleteBundleMaterialRecord(BundleID);
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

        [HttpPost]
        public JsonResult UpdateMaterialToBundle(string BundleName, string BundleDescription, int Discount, string MaterialQuantity, int BundleID, int Warrenty)
        {
            string redirectAction = string.Empty;
            bool redirect = false;
            string Result = string.Empty;

            Dictionary<int, int> MaterialIDQuantityList = new Dictionary<int, int>();
            if (!string.IsNullOrEmpty(MaterialQuantity))
            {
                var materialQuantity = MaterialQuantity.Split(',');
                foreach (var item in materialQuantity)
                {
                    var mObject = item.Split('_');
                    if (MaterialIDQuantityList.Count > 0)
                    {
                        if (!MaterialIDQuantityList.Any(x => x.Key == Convert.ToInt32(mObject[0])))
                        {
                            MaterialIDQuantityList.Add(Convert.ToInt32(mObject[0]), Convert.ToInt32(mObject[1]));
                        }
                    }
                    else
                    {
                        MaterialIDQuantityList.Add(Convert.ToInt32(mObject[0]), Convert.ToInt32(mObject[1]));
                    }
                }
            }

            if (Session["UserID"] != null)
            {
                Result = Service.UpdateBundle(MaterialIDQuantityList, BundleName, BundleDescription, Warrenty, BundleID);
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

    }
}
