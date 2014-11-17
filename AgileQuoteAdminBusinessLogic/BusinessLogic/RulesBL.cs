using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileQuoteDataLogic.DataLogic;
using AgileQuoteAdminProperty.Property;

namespace AgileQuoteAdminBusinessLogic.BusinessLogic
{
    public class RulesBL
    {
        RulesDL oRules = new RulesDL();

        public List<RulesProperty> GetRulesListBL()
        {
            try
            {
                return oRules.GetRulesList();
            }
            catch
            {
                throw;
            }
        }

        public RulesProperty GetSingleRuleBL(int RuleId)
        {
            try
            {
                return oRules.GetSingleRule(RuleId);
            }
            catch
            {
                throw;
            }
        }

        public string InsertRuleBL(RulesProperty oRulesProperty)
        {
            try
            {
                return oRules.InsertRule(oRulesProperty);
            }
            catch
            {
                throw;
            }
        }

        public string UpdateRuleBL(RulesProperty oRulesProperty)
        {
            try
            {
                return oRules.UpdateRule(oRulesProperty);
            }
            catch
            {
                throw;
            }
        }

        public string DeleteRuleBL(int RuleId)
        {
            try
            {
                return oRules.DeleteRule(RuleId);
            }
            catch
            {
                throw;
            }
        }
    }
}
