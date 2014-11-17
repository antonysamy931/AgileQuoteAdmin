using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.InteropServices.ComTypes;
using AgileQuoteAdminProperty.Property;
using AgileQuoteDataLogic.DataLogic;
using AgileQuoteDataLogic.Data;

namespace AgileQuoteAdminBusinessLogic.BusinessLogic
{

    public class MaterialBL
    {

        MaterialDL oMaterialDL = new MaterialDL();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ImageProperty> GetImageBL()
        {
            try
            {
                return oMaterialDL.GetImageDL();
            }
            catch
            {
                throw;
            }            
        }

        /// <summary>
        ///  calls GetMaterialList() function from DataLayer
        /// </summary>
        /// <returns> MaterialListProperty object</returns>
        public List<MaterialProperty> GetMaterialListBL()
        {
           try
            {
                return oMaterialDL.GetMaterialList();

            }
            catch
            {
                throw;
            }            
        }

        /// <summary>
        /// calls GetMaterialByID(id) function from DataLayer
        /// </summary>
        /// <param name="id"></param>
        /// <returns> MaterialListProperty object</returns>
        public MaterialProperty GetMaterialByID(int oMaterialId)
        {            
            try
            {
                return oMaterialDL.GetMaterialByID(oMaterialId);

            }
            catch
            {
                throw;
            }            
        }

        /// <summary>
        /// callsInsertMaterial function from DataLayer if IsInserterd reurns false
        /// </summary>
        /// <param name="oMaterialParameter"></param>
        /// <returns>string value indicates that status of the updation</returns>
        public int InsertMaterial(MaterialProperty oMaterialParameter)
        {
            try
            {
                return oMaterialDL.InsertMaterial(oMaterialParameter);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// calls UpdateMaterial function from DataLayer if IsInserterd reurns false
        /// </summary>
        /// <param name="oMaterialParameter"></param>
        /// <returns>string value indicates that status of the updation</returns>
        public int UpdateMaterial(MaterialProperty oMaterialParameter)
        {            
            try
            {
                return oMaterialDL.UpdateMaterial(oMaterialParameter);
            }
            catch
            {
                throw;
            }            
        }

        /// <summary>
        ///  updates value of isdelete field in datasbase to true
        /// </summary>
        /// <param name="id"></param>
        /// <returns>string value that indicates the status of deletion</returns>
        public string DeleteMaterial(int oMaterialId)
        {            
            try
            {
                return oMaterialDL.DeleteMaterial(oMaterialId);                
            }
            catch
            {
                throw;
            }            
        }

        public List<CategoryProperty> CategoryListBL()
        {
            try
            {
                return oMaterialDL.CategoryList();
            }
            catch
            {
                throw;
            }
        }

        public string SugectionMaterialMappingBL(List<int> oMaterialList, int MaterialId)
        {
            try
            {
                return oMaterialDL.SugectionMaterialMappingDL(oMaterialList, MaterialId);
            }
            catch
            {
                throw;
            }
        }

        public List<MaterialProperty> GetMaterialMappingSugectionMaterialBL(int MaterialId)
        {
            try
            {
                return oMaterialDL.GetMaterialMappingSugectionMaterial(MaterialId);
            }
            catch
            {
                throw;
            }
        }

        public string DeleteSugectionMaterialBL(int MaterialID, int MappingMaterial)
        {
            try
            {
                return oMaterialDL.DeleteSugectionMaterial(MaterialID, MappingMaterial);
            }
            catch
            {
                throw;
            }
        }

        public string OfferedMaterialMappingBL(List<int> oMaterialList, int MaterialId)
        {
            try
            {
                return oMaterialDL.OfferedMaterialMapping(oMaterialList, MaterialId);
            }
            catch
            {
                throw;
            }
        }

        public List<MaterialProperty> GetMaterialMappingOfferedMaterialBL(int MaterialId)
        {
            try
            {
                return oMaterialDL.GetMaterialMappingOfferedMaterial(MaterialId);
            }
            catch
            {
                throw;
            }
        }

        public string DeleteOfferedMaterialBL(int MaterialID, int MappingMaterial)
        {
            try
            {
                return oMaterialDL.DeleteOfferedMaterial(MaterialID, MappingMaterial);
            }
            catch
            {
                throw;
            }
        }
    }
}