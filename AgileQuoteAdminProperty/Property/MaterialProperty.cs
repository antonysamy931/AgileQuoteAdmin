using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AgileQuoteAdminProperty.Property
{
    public class MaterialProperty
    {
        [Display(Name = "MaterialID")]
        [Required(ErrorMessage = "Please enter Material id")]
        public int MaterialID { get; set; }
        
        [Display(Name = "Material Code")]
        [Required(ErrorMessage = "Please enter Material code")]
        public string MaterialCode { get; set; }
        
        [Display(Name = "Material Name")]
        [Required(ErrorMessage = "Please enter Material Name")]
        public string MaterialName { get; set; }

        [Display(Name = "Material Description")]
        public string MaterialDescription { get; set; }

        public List<CategoryProperty> CategoryList { get; set; }

        public string DefaultCategory { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Please select material category")]
        public string MaterialCategory { get; set; }

        [Display(Name = "Material Amount")]
        [Required(ErrorMessage = "Please enter Material Amount")]
        public decimal MaterialAmount { get; set; }
        
        [Display(Name = "Material Discount")]
        [Required(ErrorMessage = "Please enter Material Discount")]
        public int MaterialDiscount { get; set; }

        [Display(Name = "Warrenty")]
        [Required(ErrorMessage = "Please select warrenty")]        
        [RegularExpression(@"^(\d{1,30})$", ErrorMessage = "Select valid warrenty")]
        public int Warrenty { get; set; }

        public string HiddenWarrenty { get; set; }

        [Display(Name = "Installation Fee")]
        //[Required(ErrorMessage = "Please enter installation fee")]
        [RegularExpression(@"^(\d{1,30})$", ErrorMessage = "Enter valid amount")]
        public int InstallFee { get; set; }

        [Display(Name = "Material Active")]
        public bool MaterialIsActive { get; set; }
        
        [Display(Name = "Material Delete")]
        public bool MaterialIsDelete { get; set; }

        public int Quantity { get; set; }
    }

    public class MaterialListProperty
    {
        public List<MaterialProperty> MaterialList { get; set; }
        public List<MaterialProperty> UpdatedMaterialList { get; set; }
    }

    public class CategoryProperty
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
