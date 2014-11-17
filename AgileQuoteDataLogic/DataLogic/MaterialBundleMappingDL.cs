using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices.ComTypes;
using AgileQuoteAdminProperty.Property;
using AgileQuoteDataLogic.DataLogic;
using AgileQuoteDataLogic.Data;
using System.Data;

namespace AgileQuoteDataLogic.DataLogic
{
   public class MaterialBundleMappingDL
    {
       AgileQuoteDevelopmentEntitiesV Entities = new AgileQuoteDevelopmentEntitiesV();
        tbBundleMaterialMapping oBundleMapping = new tbBundleMaterialMapping();

        public bool IsInserted(int MaterialID, int BundleID)
        {
            bool Status=false;

            try
            {
               Status = Entities.tbBundleMaterialMappings.Where(x => (x.BundleID == BundleID)&&(x.MaterialID==MaterialID)).Any();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Status;
        }

        public void CreateBundle(int MaterialID, int BundleID)
        {

            try
            {
              
                oBundleMapping.BundleID = BundleID;
                oBundleMapping.MaterialID = MaterialID;
                oBundleMapping.IsActive = true;
                oBundleMapping.IsDelete = false;
                Entities.tbBundleMaterialMappings.AddObject(oBundleMapping);
                Entities.SaveChanges();
                Entities.ObjectStateManager.ChangeObjectState(oBundleMapping, EntityState.Added);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<string> GetMaterialBundleMapping(string id)
        {
            try
            {
                List<string> MaterialId = new List<string>();
                int BundleId = Convert.ToInt32(id);
                var obj = Entities.tbBundleMaterialMappings.Where(x => (x.BundleID == BundleId ) && (x.IsDelete==false&&x.IsActive==true)).ToList();
                foreach (var v in obj)
                {
                    MaterialId.Add(v.MaterialID.ToString());
                }
                
                return MaterialId;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
