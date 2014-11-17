using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AgileQuoteAdminProperty.Property
{
    
   public class CurrencyProperty
    {
       
       public int CurrencyId { get; set; }

       [Display(Name="CurrencyCode")]
       [Required(ErrorMessage="Please enter CurrencyCode")]
       public string CurrencyCode { get; set; }

       [Display(Name="CurrencyName")]
       [Required(ErrorMessage="Please enter CurrencyName")]
       public string CurrencyName { get; set; }

       [Display(Name="Amount")]
       [Required(ErrorMessage="Please enter Amount")]
       public decimal Amount { get; set; }

       [Display(Name="Active")]
       public bool IsActive { get; set; }

       [Display(Name="Delete")]
       public bool IsDelete { get; set; }

    }
 
   public class CurrencyListProperty
   {
       public List<CurrencyProperty> CurrencyList { get; set; }
   }
}
