using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AgileQuoteAdminProperty.Property
{
   public class RentalSparsProperty
    {
        [Display(Name="RentalSparsId")]
        public int RentalSparsId { get; set; }

        [Display(Name="RentalSparsName")]
        [Required(ErrorMessage="Please Enter RetalSparsName")]
        public string RentalSparsName { get; set; }

        [Display(Name="Description")]
        public string Description { get; set; }

        [Display(Name = "Warrenty")]
        public decimal Warrenty { get; set; }

        [Display(Name="UnitPrice")]
        public decimal UnitPrice { get; set; }

        [Display(Name="Discount")]
        public int Discount { get; set; }

        [Display(Name="NetPrice")]
        public decimal NetPrice { get; set; }

        [Display(Name="Active")]
        public bool IsActive { get; set; }

        [Display(Name="Delete")]
        public bool IsDelete { get; set; }
    }
   public class RentalSparsListProperty
   {
       public List<RentalSparsProperty> RentalSparsList { get; set; } 
   }
}
