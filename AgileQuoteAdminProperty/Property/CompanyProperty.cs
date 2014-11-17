using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AgileQuoteAdminProperty.Property
{
   public class CompanyProperty
    {
       public int CompanyCode { get; set; }

       [Display(Name="Company Name")]
       [Required(ErrorMessage="Please enter Company Name")]
       public string CompanyName { get; set; }

       public bool IsActive { get; set; }

       public bool IsDelete { get; set; }
    }
   public class CompanyNameList
   {
       public List<CompanyProperty> CompanyName { get; set; }
   }
}
