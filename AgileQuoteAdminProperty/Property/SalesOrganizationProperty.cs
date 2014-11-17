using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace AgileQuoteAdminProperty.Property
{
    public class SalesOrganizationProperty
    {
        [Display(Name = "Sales Code")]
        [Required(ErrorMessage = "Please Enter Sales Organization code")]
        public int SalesOrgCode { get; set; }

        [Display(Name = "Sales Name")]
        [Required(ErrorMessage = "Please Enter Sales Organization Name")]
        public string SalesOrgName { get; set; }

        [Display(Name = "Reference Customer Code")]
        [Required(ErrorMessage = "Please Enter Reference Customer Code Name")]
        public string ReferenceCustomerCode { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "Delete")]
        public bool IsDelete { get; set; }
    }
    public class SalesOrgranizationPropertyList
    {
        public List<SalesOrganizationProperty> SalesOrganizationList { get; set; }
    }
}
