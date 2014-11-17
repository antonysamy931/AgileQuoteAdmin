using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileQuoteAdminProperty.Property
{
    public class RulesProperty
    {
        public int RuleId { get; set; }
        public decimal MinimumAmount { get; set; }
        public decimal MaximumAmount { get; set; }
        public int MinimumDiscount { get; set; }
        public int MaximumDiscount { get; set; }
        public string RolesName { get; set; }
        public List<RoleProperty> Roles { get; set; }
        public List<int> RoleIdList { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

    public class RulesDropdownProperty
    {
        private List<int> _MinimumAmountValue;
        public List<int> MinimumAmountValue
        {
            get
            {
                _MinimumAmountValue = new List<int>();
                for (var i = 1000; i <= 3000000; i = i + 1000)
                {
                    _MinimumAmountValue.Add(i);
                }
                return _MinimumAmountValue;
            }

            set
            {
                _MinimumAmountValue = null;
            }
        }

        private List<int> _MaximumAmountValue;
        public List<int> MaximumAmountValue
        {
            get
            {
                _MaximumAmountValue = new List<int>();
                for (var i = 2000; i <= 3000000; i = i + 1000)
                {
                    _MaximumAmountValue.Add(i);
                }
                return _MaximumAmountValue;
            }

            set
            {
                _MaximumAmountValue = null;
            }
        }

        private List<int> _MinimumDiscountValue;
        public List<int> MinimumDiscountValue
        {
            get
            {
                _MinimumDiscountValue = new List<int>();
                _MinimumDiscountValue.Add(1);
                for (var i = 10; i <= 90; i = i + 10)
                {
                    _MinimumDiscountValue.Add(i);
                }
                return _MinimumDiscountValue;
            }

            set
            {
                _MinimumDiscountValue = null;
            }
        }

        private List<int> _MaximumDiscountValue;
        public List<int> MaximumDiscountValue
        {
            get
            {
                _MaximumDiscountValue = new List<int>();
                for (var i = 10; i <= 90; i = i + 10)
                {
                    _MaximumDiscountValue.Add(i);
                }
                return _MaximumDiscountValue;
            }

            set
            {
                _MaximumDiscountValue = null;
            }
        }
    }
}
