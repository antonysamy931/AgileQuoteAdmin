using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices.ComTypes;
using AgileQuoteAdminProperty.Property;
using AgileQuoteDataLogic.DataLogic;
using AgileQuoteDataLogic.Data;

namespace AgileQuoteAdminBusinessLogic.BusinessLogic
{
  public  class MaterialBundleMappingBL
    {
      MaterialBundleMappingDL oMaterialBundle = new MaterialBundleMappingDL();
      public List<string> GetMaterialBundleMapping(string id)
      {
          List<string> MaterialId = new List<string>();
          try
          {
            MaterialId = oMaterialBundle.GetMaterialBundleMapping(id);
          }
          catch (Exception ex)
          {
              throw ex;
          }
          return MaterialId;
      }
    }
}
