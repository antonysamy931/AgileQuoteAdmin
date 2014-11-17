
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AgileQuoteAdminProperty.Property
{
  public  class RentalProductsProperty
    {
      [Display(Name = "RentalProductsID")]
      [Required(ErrorMessage = "Please enter RentalProductsID")]
        public int RentalProductsID { get; set; }

      [Display(Name = "RentalProductsName")]
      [Required(ErrorMessage = "Please enter RentalProductsName")]
        public string RentalProductsName { get; set; }

      [Display(Name = "Description")]
      [Required(ErrorMessage = "Please enter Description")]
        public string Description { get; set; }

      [Display(Name = "Warrenty")]
      [Required(ErrorMessage = "Please enter Warrenty")]
        public decimal? Warrenty { get; set; }

      [Display(Name = "UnitPrice")]
      [Required(ErrorMessage = "Please enter UnitPrice")]
        public decimal? UnitPrice { get; set; }

      [Display(Name = "Discount")]
      [Required(ErrorMessage = "Please enter Discount")]
        public int? Discount { get; set; }

      [Display(Name = "NetPrice")]
      [Required(ErrorMessage = "Please enter NetPrice")]
        public decimal? NetPrice { get; set; }
      
        public bool IsActive { get; set; }     

        public bool IsDelete { get; set; }
    }
  public class RentalProductsListProperty
  {

      public List<RentalProductsProperty> RentalProductsList { get; set; }
  }
}
