using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileQuoteAdminProperty.Property
{
   public class MaterialBundleProperty
    {
       public MaterialProperty oMaterial { get; set; }
      public  BundleProperty oBundle { get; set; }
      public MaterialListProperty oMaterialList { get; set; }
      public BundleListProperty oBundleList { get; set; }
      //public MaterialIDClass oMaterialID { get; set; }
    }
   
}
