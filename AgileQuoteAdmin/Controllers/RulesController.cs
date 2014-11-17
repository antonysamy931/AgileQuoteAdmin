using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgileQuoteAdminProperty.Property;

namespace AgileQuoteAdmin.Controllers
{
    public class RulesController : Controller
    {
        AgileAdminService.IService1 Service = new AgileAdminService.Service1Client();

        [HttpGet]
        public ActionResult Rule()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("LogIn", "LogIn");
            }

            RulesProperty oRule = new RulesProperty();
            oRule.Roles = Service.GetRoleListService();
            return View(oRule);
        }


        public JsonResult GetRuleList(jQueryDataTableParamModel param)
        {
            RulesProperty oRuleProperty = new RulesProperty();
            IList<RulesProperty> oAllRuleList = new List<RulesProperty>();
            oAllRuleList = Service.GetRulesList();

            IEnumerable<RulesProperty> oFilterRuleList = null;

            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var RuleIdFilter = Convert.ToString(Request["sSearch_1"]);
                var MaximumAmountFilter = Convert.ToString(Request["sSearch_2"]);
                var MinimumAmountFilter = Convert.ToString(Request["sSearch_3"]);
                var MaximumDiscountFilter = Convert.ToString(Request["sSearch_4"]);
                var MinimumDiscountFilter = Convert.ToString(Request["sSearch_5"]);
                var RoleNameFilter = Convert.ToString(Request["sSearch_6"]);

                var isRoleIdSearchable = true;
                var isMaximumAmountSearchable = true;
                var isMinimumAmountSearchable = true;
                var isMaximumDiscountSearchable = true;
                var isMinimumDiscountSearchable = true;
                var isRoleNameSearchable = true;

                oFilterRuleList = oAllRuleList.Where(c => Convert.ToString(c.RuleId).ToLower().Contains(param.sSearch.ToLower())
                    || Convert.ToString(c.MaximumAmount).ToLower().Contains(param.sSearch.ToLower())
                    || Convert.ToString(c.MinimumAmount).ToLower().Contains(param.sSearch.ToLower())
                    || Convert.ToString(c.MaximumDiscount).ToLower().Contains(param.sSearch.ToLower())
                    || Convert.ToString(c.MinimumDiscount).ToLower().Contains(param.sSearch.ToLower())
                    || c.RolesName.ToLower().Contains(param.sSearch.ToLower())
                    );
            }
            else
            {
                oFilterRuleList = oAllRuleList;
            }

            var isRuleIdSortable = Convert.ToBoolean(Request["bSortable_1"]);
            var isMaximumAmountSortable = Convert.ToBoolean(Request["bSortable_2"]);
            var isMinimumAmountSortable = Convert.ToBoolean(Request["bSortable_3"]);
            var isMaximumDiscountSortable = Convert.ToBoolean(Request["bSortable_4"]);
            var isMinimumDiscountSortable = Convert.ToBoolean(Request["bSortable_5"]);

            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);

            Func<RulesProperty, string> ordering = (c => sortColumnIndex == 1 && isRuleIdSortable ? c.RuleId.ToString() :
                sortColumnIndex == 2 && isMaximumAmountSortable ? c.MaximumAmount.ToString() :
                sortColumnIndex == 3 && isMinimumAmountSortable ? c.MinimumAmount.ToString() :
                sortColumnIndex == 4 && isMaximumDiscountSortable ? c.MaximumDiscount.ToString() :
                sortColumnIndex == 5 && isMinimumDiscountSortable ? c.MinimumDiscount.ToString() :
                "");

            var sortDirection = Request["sSortDir_0"]; // asc or desc

            if (sortDirection == "asc")
            {
                oFilterRuleList = oFilterRuleList.OrderBy(ordering);
            }
            else
            {
                oFilterRuleList = oFilterRuleList.OrderByDescending(ordering);
            }

            var oDisplayRuleList = oFilterRuleList.Skip(param.iDisplayStart).Take(param.iDisplayLength);

            var Result = from rule in oDisplayRuleList
                         select new[]
                       {
                           Convert.ToString(rule.RuleId),
                           Convert.ToString(rule.MaximumAmount),
                           Convert.ToString(rule.MinimumAmount),
                           Convert.ToString(rule.MaximumDiscount),
                           Convert.ToString(rule.MinimumDiscount),
                           rule.RolesName
                       };

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = oAllRuleList.Count(),
                iTotalDisplayRecords = oFilterRuleList.Count(),
                aaData = Result
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult InsertRule(int minAmount, int maxAmount, int minDiscount, int maxDiscount, string Roles)
        {
            string redirectAction = string.Empty;
            bool redirect = false;
            string Result = string.Empty;

            if (Session["UserID"] != null)
            {
                RulesProperty oRule = new RulesProperty();
                oRule.MinimumAmount = minAmount;
                oRule.MaximumAmount = maxAmount;
                oRule.MinimumDiscount = minDiscount;
                oRule.MaximumDiscount = maxDiscount;
                oRule.RolesName = Roles;
                oRule.IsActive = true;
                oRule.IsDelete = false;
                Result = Service.InsertRule(oRule);
            }
            else
            {
                redirectAction = Url.Action("Login", "Account");
                redirect = true;
            }


            return Json(new
            {
                redirect,
                redirectAction,
                Result
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteRule(int RuleId)
        {
            string redirectAction = string.Empty;
            bool redirect = false;
            string Result = string.Empty;

            if (Session["UserID"] != null)
            {
                Result = Service.DeleteRule(RuleId);
            }
            else
            {
                redirectAction = Url.Action("Login", "Account");
                redirect = true;
            }


            return Json(new
            {
                redirect,
                redirectAction,
                Result
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSingleRule(int RuleId)
        {
            string redirectAction = string.Empty;
            bool redirect = false;
            RulesProperty Result = new RulesProperty();

            if (Session["UserID"] != null)
            {
                Result = Service.GetSingleRule(RuleId);
            }
            else
            {
                redirectAction = Url.Action("Login", "Account");
                redirect = true;
            }


            return Json(new
            {
                redirect,
                redirectAction,
                Result
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateRule(int RuleId, int minAmount, int maxAmount, int minDiscount, int maxDiscount, string Roles, bool IsActive, bool IsDelete)
        {
            string redirectAction = string.Empty;
            bool redirect = false;
            string Result = string.Empty;

            if (Session["UserID"] != null)
            {
                RulesProperty oRule = new RulesProperty();
                oRule.RuleId = RuleId;
                oRule.MinimumAmount = minAmount;
                oRule.MaximumAmount = maxAmount;
                oRule.MinimumDiscount = minDiscount;
                oRule.MaximumDiscount = maxDiscount;
                oRule.RolesName = Roles;
                oRule.IsActive = IsActive;
                oRule.IsDelete = IsDelete;

                Result = Service.UpdateRule(oRule);

            }
            else
            {
                redirectAction = Url.Action("Login", "Account");
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
