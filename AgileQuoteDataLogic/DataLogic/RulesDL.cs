using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileQuoteDataLogic.Data;
using AgileQuoteAdminProperty.Property;
using AgileQuoteAdminProperty.Common;

namespace AgileQuoteDataLogic.DataLogic
{
    public class RulesDL
    {
        AgileQuoteDevelopmentEntitiesV oEntities = new AgileQuoteDevelopmentEntitiesV();
        AgileQuoteAdminDevelopmentEntities oAdminEntities = new AgileQuoteAdminDevelopmentEntities();

        public List<RulesProperty> GetRulesList()
        {
            try
            {
                List<RulesProperty> rList = new List<RulesProperty>();

                var oRulesList = oEntities.tbApproverRules.Where(x => x.IsActive == true && x.IsDelete == false).ToList();
                if (oRulesList.Count > 0)
                {
                    foreach (var item in oRulesList)
                    {
                        RulesProperty oProperty = new RulesProperty();
                        oProperty.RuleId = item.RuleId;
                        oProperty.MaximumDiscount = item.MaximumDiscount;
                        oProperty.MinimumDiscount = item.MinimumDiscount;
                        oProperty.MaximumAmount = Extension.MathRound(item.MaximumAmount);
                        oProperty.MinimumAmount = Extension.MathRound(item.MinimumAmount);
                        if (item.RoleId != null)
                        {
                            var values = item.RoleId.Split(',');
                            foreach (var obj in values)
                            {
                                int RoleId = Convert.ToInt32(obj);
                                var oRolename = oAdminEntities.tbCustomerRoles.Where(x => x.RoleID == RoleId && x.IsActive == true && x.IsDelete == false).Select(x => x.RoleName).FirstOrDefault();
                                if (oProperty.RolesName != null)
                                {
                                    oProperty.RolesName = oProperty.RolesName + "," + oRolename;
                                }
                                else
                                {
                                    oProperty.RolesName = oRolename;
                                }
                            }
                        }
                        rList.Add(oProperty);
                    }
                }
                return rList;
            }
            catch
            {
                throw;
            }
        }

        public RulesProperty GetSingleRule(int RuleId)
        {
            try
            {
                RulesProperty oProperty = new RulesProperty();
                var oRule = oEntities.tbApproverRules.Where(x => x.RuleId == RuleId && x.IsActive == true && x.IsDelete == false).FirstOrDefault();
                if (oRule != null)
                {
                    oProperty.RuleId = oRule.RuleId;
                    oProperty.MinimumAmount = oRule.MinimumAmount;
                    oProperty.MaximumAmount = oRule.MaximumAmount;
                    oProperty.MinimumDiscount = oRule.MinimumDiscount;
                    oProperty.MaximumDiscount = oRule.MaximumDiscount;
                    oProperty.IsActive = oRule.IsActive;
                    oProperty.IsDelete = oRule.IsDelete;
                    if (oRule.RoleId != null)
                    {
                        var values = oRule.RoleId.Split(',');

                        List<int> roleList = new List<int>();
                        foreach (var item in values)
                        {
                            roleList.Add(Convert.ToInt32(item));
                        }
                        oProperty.RoleIdList = roleList;

                    }
                }
                return oProperty;
            }
            catch
            {
                throw;
            }
        }

        public string InsertRule(RulesProperty oRulesProperty)
        {
            try
            {
                if (!CheckRules(oRulesProperty))
                {
                    tbApproverRule oRules = new tbApproverRule();
                    oRules.MaximumDiscount = oRulesProperty.MaximumDiscount;
                    oRules.MinimumDiscount = oRulesProperty.MinimumDiscount;
                    oRules.MaximumAmount = oRulesProperty.MaximumAmount;
                    oRules.MinimumAmount = oRulesProperty.MinimumAmount;
                    oRules.RoleId = oRulesProperty.RolesName;
                    oRules.IsActive = true;
                    oRules.IsDelete = false;
                    oEntities.tbApproverRules.AddObject(oRules);
                    oEntities.SaveChanges();
                    return "Success";
                }
                else
                {
                    return "Rule already defined";
                }
            }
            catch
            {
                throw;
            }
        }

        public string UpdateRule(RulesProperty oRulesProperty)
        {
            try
            {
                if (!CheckRules(oRulesProperty))
                {
                    var oRule = oEntities.tbApproverRules.Where(x => x.RuleId == oRulesProperty.RuleId
                        && x.IsActive == true && x.IsDelete == false).FirstOrDefault();
                    if (oRule != null)
                    {
                        oRule.IsActive = oRulesProperty.IsActive;
                        oRule.IsDelete = oRulesProperty.IsDelete;
                        oRule.MaximumAmount = oRulesProperty.MaximumAmount;
                        oRule.MinimumAmount = oRulesProperty.MinimumAmount;
                        oRule.MaximumDiscount = oRulesProperty.MaximumDiscount;
                        oRule.MinimumDiscount = oRulesProperty.MinimumDiscount;
                        oRule.RoleId = oRulesProperty.RolesName;
                        oEntities.SaveChanges();
                    }
                    return "Success";
                }
                else
                {
                    return "Rule already defined";
                }
            }
            catch
            {
                throw;
            }
        }

        public string DeleteRule(int RuleId)
        {
            try
            {
                var oRule = oEntities.tbApproverRules.Where(x => x.RuleId == RuleId && x.IsActive == true && x.IsDelete == false).FirstOrDefault();
                if (oRule != null)
                {
                    oRule.IsActive = false;
                    oRule.IsDelete = true;
                    oEntities.SaveChanges();
                }
                return "Success";
            }
            catch
            {
                throw;
            }
        }

        public bool CheckRules(RulesProperty oRulesProperty)
        {
            try
            {
                if (oRulesProperty.IsActive && !oRulesProperty.IsDelete)
                {
                    return oEntities.tbApproverRules.Where(x => x.MaximumAmount == oRulesProperty.MaximumAmount
                        && x.MinimumAmount == oRulesProperty.MinimumAmount && x.MaximumDiscount == oRulesProperty.MaximumDiscount
                        && x.MinimumDiscount == oRulesProperty.MinimumDiscount && x.RoleId == oRulesProperty.RolesName && x.IsActive == true && x.IsDelete == false).Any();
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
