using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileQuoteAdminProperty.Property
{
    public class BundleProperty
    {
        public int sno { get; set; }
        public int BundleId { get; set; }
        public string BundleName { get; set; }
        public string BundleDescription { get; set; }
        public int BundleWarrenty { get; set; }
        public decimal BundleUnitPrice { get; set; }
        public int BundleDiscount { get; set; }
        public decimal BundleNetPrice { get; set; }
        public decimal BundleInstallation { get; set; }
        public int Quantity { get; set; }
        public string BundleType { get; set; }
    }

    public class BundleListProperty
    {
        public List<BundleProperty> BundleList { get; set; }
    }
}
