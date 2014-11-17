using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AgileQuoteAdminProperty.Property;
using AgileQuoteAdminBusinessLogic.BusinessLogic;

namespace AgileQuoteAdminService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {

        LogInBL oCheckAuthentication = new LogInBL();
        ExceptionClass oException = new ExceptionClass();
        RoleBL oRoleBL = new RoleBL();
        MaterialBL oMaterialBL = new MaterialBL();
        MaterialBundleMappingBL oMaterialBundle = new MaterialBundleMappingBL();
        BundleBL oBundleBL = new BundleBL();
        RentalProductsBL oRentalProductsBL = new RentalProductsBL();
        CurrencyBL oCurrencyBL = new CurrencyBL();
        SalesOrganizationBL OSalesOrganizationBL = new SalesOrganizationBL();
        RentalSparsBL oRentalSparsBL = new RentalSparsBL();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oRentalSpars"></param>
        /// <returns></returns>
        public int InsertRentalSparsService(RentalSparsProperty oRentalSpars)
        {
            try
            {
                return oRentalSparsBL.InsertRentalSparsBL(oRentalSpars);
            }
            catch (Exception e)
            {
                oException.ErrorReason = e.Message;
                oException.StackTrace = e.StackTrace;
                throw new FaultException<ExceptionClass>(oException, e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<RentalSparsProperty> RentalSparsListService()
        {
            try
            {
                return oRentalSparsBL.RentalSparsListBL();
            }
            catch (Exception e)
            {
                oException.ErrorReason = e.Message;
                oException.StackTrace = e.StackTrace;
                throw new FaultException<ExceptionClass>(oException, e.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RentalSparsId"></param>
        /// <returns></returns>
        public RentalSparsProperty SingleRentalSparsService(int RentalSparsId)
        {
            try
            {
                return oRentalSparsBL.SingleRentalSparsBL(RentalSparsId);
            }
            catch (Exception e)
            {
                oException.ErrorReason = e.Message;
                oException.StackTrace = e.StackTrace;
                throw new FaultException<ExceptionClass>(oException, e.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oRentalSpars"></param>
        /// <returns></returns>
        public int UpdateRentalSparsService(RentalSparsProperty oRentalSpars)
        {
            try
            {
                return oRentalSparsBL.UpdateRentalSparsBL(oRentalSpars);
            }
            catch (Exception e)
            {
                oException.ErrorReason = e.Message;
                oException.StackTrace = e.StackTrace;
                throw new FaultException<ExceptionClass>(oException, e.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RentalSparsId"></param>
        /// <returns></returns>
        public string DeleteRentalSparsService(int RentalSparsId)
        {
            try
            {
                return oRentalSparsBL.DeleteRentalSparsBL(RentalSparsId);
            }
            catch (Exception e)
            {
                oException.ErrorReason = e.Message;
                oException.StackTrace = e.StackTrace;
                throw new FaultException<ExceptionClass>(oException, e.Message);
            }
        }


        /// <summary>
        /// GetRoleListService method is used to retrive all records
        /// </summary>
        /// <returns>Returns GetRoleListBL</returns>
        public List<RoleProperty> GetRoleListService()
        {
            try
            {
                return oRoleBL.GetRoleListBL();
            }
            catch (Exception e)
            {
                oException.ErrorReason = e.Message;
                oException.StackTrace = e.StackTrace;
                throw new FaultException<ExceptionClass>(oException, e.Message);
            }
        }

        /// <summary>
        /// GetSingleRoleRecordService method is used to retrive the single record
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns>Returns GetSingleRecordBL</returns>
        public RoleProperty GetSingleRoleRecordService(int RoleId)
        {
            try
            {
                return oRoleBL.GetSingleRecordBL(RoleId);
            }
            catch (Exception e)
            {
                oException.ErrorReason = e.Message;
                oException.StackTrace = e.StackTrace;
                throw new FaultException<ExceptionClass>(oException, e.Message);
            }
        }

        /// <summary>
        /// InsertRoleRecordService method is used to insert a record into the data base
        /// </summary>
        /// <param name="rp"></param>
        /// <returns>Returns InsertRoleRecordBL</returns>
        public string InsertRoleRecordService(RoleProperty oRoleProperty)
        {
            try
            {
                return oRoleBL.InsertRoleRecordBL(oRoleProperty);
            }
            catch (Exception e)
            {
                oException.ErrorReason = e.Message;
                oException.StackTrace = e.StackTrace;
                throw new FaultException<ExceptionClass>(oException, e.Message);
            }
        }

        /// <summary>
        /// UpdateRoleService method is used to update a record into the data base
        /// </summary>
        /// <param name="rp"></param>
        /// <returns>Returns UpdateRoleRecordBL</returns>
        public string UpdateRoleService(RoleProperty oRoleProperty)
        {
            try
            {
                return oRoleBL.UpdateRoleRecordBL(oRoleProperty);
            }
            catch (Exception e)
            {
                oException.ErrorReason = e.Message;
                oException.StackTrace = e.StackTrace;
                throw new FaultException<ExceptionClass>(oException, e.Message);
            }
        }
        public string DeleteRoleService(int RoleID)
        {
            try
            {
                return oRoleBL.DeleteRoleRecordBL(RoleID);
            }
            catch (Exception e)
            {
                oException.ErrorReason = e.Message;
                oException.StackTrace = e.StackTrace;
                throw new FaultException<ExceptionClass>(oException, e.Message);
            }
        }

        /// <summary>
        /// It shows all records.
        /// </summary>
        /// <returns>object of oCurrencyBL</returns>
        public List<CurrencyProperty> GetCurrencyListService()
        {
            try
            {
                return oCurrencyBL.GetCurrencyListBL();
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }
        /// <summary>
        /// To get a single record.
        /// </summary>
        /// <param name="CurrencyId"></param>
        /// <returns>object of oCurrencyBL</returns>
        public CurrencyProperty GetSingleCurrencyRecordService(int CurrencyId)
        {
            try
            {
                return oCurrencyBL.GetSingleRecordBL(CurrencyId);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }
        /// <summary>
        /// To insert the record.
        /// </summary>
        /// <param name="cp"></param>
        /// <returns>object of oCurrencyBL</returns>
        public string InsertCurrencyRecordService(CurrencyProperty oCurrencyProperty)
        {
            try
            {
                return oCurrencyBL.InsertCurrencyRecordBL(oCurrencyProperty);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }
        /// <summary>
        /// To update the record.
        /// </summary>
        /// <param name="cp"></param>
        /// <returns>object of oCurrencyBL</returns>
        public string UpdateCurrencyService(CurrencyProperty oCurrencyProperty)
        {
            try
            {
                return oCurrencyBL.UpdateCurrencyBL(oCurrencyProperty);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public string DeleteCurrrencyService(int CurrencyId)
        {
            try
            {
                return oCurrencyBL.DeleteCurrencyBL(CurrencyId);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public List<CategoryProperty> CategoryList()
        {
            try
            {
                return oMaterialBL.CategoryListBL();
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        /// <summary>
        /// gets MaterialListProperty object from MaterialBL class
        /// </summary>
        /// <returns> MaterialListProperty</returns>
        public List<MaterialProperty> GetMaterialListService()
        {
            try
            {
                return oMaterialBL.GetMaterialListBL();
            }
            catch (Exception ex)
            {
                oException.StackTrace = ex.StackTrace;
                oException.ErrorReason = ex.Message;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }

        }
        /// <summary>
        /// Gets MaterialList by its ID from MaterialBL class
        /// </summary>
        /// <param name="id"></param>
        /// <returns>object of MaterialBL</returns>
        public MaterialProperty GetMaterialListByID(int oMaterialId)
        {
            try
            {
                return oMaterialBL.GetMaterialByID(oMaterialId);
            }
            catch (Exception ex)
            {
                oException.StackTrace = ex.StackTrace;
                oException.ErrorReason = ex.Message;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }
        /// <summary>
        /// Inserts Material from user to the database
        /// </summary>
        /// <param name="oMaterialParameter"></param>
        /// <returns>returns string that indicates status of Insertion </returns>
        public int InsertMaterial(MaterialProperty oMaterialParameter)
        {
            try
            {
                return oMaterialBL.InsertMaterial(oMaterialParameter);
            }
            catch (Exception ex)
            {
                oException.StackTrace = ex.StackTrace;
                oException.ErrorReason = ex.Message;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }
        /// <summary>
        /// Update Material from user to database
        /// </summary>
        /// <param name="oMaterialParameter"></param>
        /// <returns>returns string that indicates status of updation</returns>
        public int UpdateMaterial(MaterialProperty oMaterialParameter)
        {
            try
            {
                return oMaterialBL.UpdateMaterial(oMaterialParameter);
            }
            catch (Exception ex)
            {
                oException.StackTrace = ex.StackTrace;
                oException.ErrorReason = ex.Message;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }
        /// <summary>
        /// updates value of isdelete field in datasbase to true
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>string value that indicates the status of deletion</returns>
        public string DeleteMaterial(int oMaterialId)
        {
            try
            {
                string status = oMaterialBL.DeleteMaterial(oMaterialId);
                return status;
            }
            catch (Exception ex)
            {
                oException.StackTrace = ex.StackTrace;
                oException.ErrorReason = ex.Message;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public List<MaterialProperty> GetMaterialMappingSugectionMaterial(int MaterialId)
        {
            try
            {
                return oMaterialBL.GetMaterialMappingSugectionMaterialBL(MaterialId);
            }
            catch (Exception ex)
            {
                oException.StackTrace = ex.StackTrace;
                oException.ErrorReason = ex.Message;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public string SugectionMaterialMapping(List<int> oMaterialList, int MaterialId)
        {
            try
            {
                return oMaterialBL.SugectionMaterialMappingBL(oMaterialList, MaterialId);
            }
            catch(Exception ex)
            {
                oException.StackTrace = ex.StackTrace;
                oException.ErrorReason = ex.Message;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public string DeleteSugectionMaterial(int MaterialID, int MappingMaterial)
        {
            try
            {
                return oMaterialBL.DeleteSugectionMaterialBL(MaterialID, MappingMaterial);
            }
            catch (Exception ex)
            {
                oException.StackTrace = ex.StackTrace;
                oException.ErrorReason = ex.Message;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public string OfferedMaterialMapping(List<int> oMaterialList, int MaterialId)
        {
            try
            {
                return oMaterialBL.OfferedMaterialMappingBL(oMaterialList, MaterialId);
            }
            catch (Exception ex)
            {
                oException.StackTrace = ex.StackTrace;
                oException.ErrorReason = ex.Message;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public List<MaterialProperty> GetMaterialMappingOfferedMaterial(int MaterialId)
        {
            try
            {
                return oMaterialBL.GetMaterialMappingOfferedMaterialBL(MaterialId);
            }
            catch(Exception ex)
            {
                oException.StackTrace = ex.StackTrace;
                oException.ErrorReason = ex.Message;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public string DeleteOfferedMaterial(int MaterialID, int MappingMaterial)
        {
            try
            {
                return oMaterialBL.DeleteOfferedMaterialBL(MaterialID, MappingMaterial);
            }
            catch (Exception ex)
            {
                oException.StackTrace = ex.StackTrace;
                oException.ErrorReason = ex.Message;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }


        public List<RentalProductsProperty> GetRentalProductsListService()
        {
            try
            {
                return oRentalProductsBL.GetRentalProductsListBL();
            }
            catch (Exception ex)
            {
                oException.StackTrace = ex.StackTrace;
                oException.ErrorReason = ex.Message;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }

        }

        public RentalProductsProperty GetRentalProductsListByID(int id)
        {
            try
            {
                return oRentalProductsBL.GetRentalProductsByID(id);
            }
            catch (Exception ex)
            {
                oException.StackTrace = ex.StackTrace;
                oException.ErrorReason = ex.Message;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public int InsertRentalProducts(RentalProductsProperty oRentalProductsParameter)
        {
            try
            {
                return oRentalProductsBL.InsertRentalProducts(oRentalProductsParameter);
            }
            catch (Exception ex)
            {
                oException.StackTrace = ex.StackTrace;
                oException.ErrorReason = ex.Message;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public int UpdateRentalProducts(RentalProductsProperty oRentalProductsParameter)
        {
            try
            {
                int RentalProductId = oRentalProductsBL.UpdateRentalProducts(oRentalProductsParameter);
                return RentalProductId;
            }
            catch (Exception ex)
            {
                oException.StackTrace = ex.StackTrace;
                oException.ErrorReason = ex.Message;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public string DeleteRentalProducts(int ID)
        {
            try
            {
                string status = oRentalProductsBL.DeleteRentalProducts(ID);
                return status;
            }
            catch (Exception ex)
            {
                oException.StackTrace = ex.StackTrace;
                oException.ErrorReason = ex.Message;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oBundleProperty"></param>
        /// <returns></returns>
        //public string CreateBundle(string BundleName, string Catagory, List<string> FromMaterialID)
        //{

        //    try
        //    {
        //        string status = oBundleBL.CreateBundle(BundleName, Catagory, FromMaterialID);
        //        return status;
        //    }
        //    catch (Exception ex)
        //    {
        //        oException.StackTrace = ex.StackTrace;
        //        oException.ErrorReason = ex.Message;
        //        throw new FaultException<ExceptionClass>(oException, ex.Message);
        //    }

        //}

        //public List<BundleProperty> GetBundleListService(string id)
        //{
        //    try
        //    {
        //        return oBundleBL.GetBundleList(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        oException.StackTrace = ex.StackTrace;
        //        oException.ErrorReason = ex.Message;
        //        throw new FaultException<ExceptionClass>(oException, ex.Message);
        //    }


        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="BundleName"></param>
        ///// <param name="FromMaterialID"></param>
        ///// <returns></returns>
        //public string UpdateBundle(string BundleName, List<string> FromMaterialID)
        //{
        //    try
        //    {
        //        string status = oBundleBL.UpdateBundle(BundleName, FromMaterialID);
        //        return status;
        //    }
        //    catch (Exception ex)
        //    {
        //        oException.StackTrace = ex.StackTrace;
        //        oException.ErrorReason = ex.Message;
        //        throw new FaultException<ExceptionClass>(oException, ex.Message);
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<string> GetMaterialBundleMapping(string id)
        {
            try
            {
                List<string> MaterialID = new List<string>();
                MaterialID = oMaterialBundle.GetMaterialBundleMapping(id);
                return MaterialID;
            }
            catch (Exception ex)
            {
                oException.StackTrace = ex.StackTrace;
                oException.ErrorReason = ex.Message;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }

        }

        public BundleProperty GetBundleSingleRecord(int BundleID)
        {
            try
            {
                return oBundleBL.GetBundleSingleRecordBL(BundleID);
            }
            catch (Exception ex)
            {
                oException.StackTrace = ex.StackTrace;
                oException.ErrorReason = ex.Message;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public string InsertMaterialMappingToBundle(Dictionary<int, int> MaterialIDQuantinyList, string BundleName, int UserID, string BundleDescription, int Warrenty)
        {
            try
            {
                return oBundleBL.InsertMaterialMappingToBundleBL(MaterialIDQuantinyList, BundleName, UserID, BundleDescription, Warrenty);
            }
            catch (Exception ex)
            {
                oException.StackTrace = ex.StackTrace;
                oException.ErrorReason = ex.Message;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public string DeleteBundleMaterialRecord(int BundleID)
        {
            try
            {
                return oBundleBL.BundlematerialDelete(BundleID);
            }
            catch (Exception ex)
            {
                oException.StackTrace = ex.StackTrace;
                oException.ErrorReason = ex.Message;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public string UpdateBundle(Dictionary<int, int> MaterialIDQuantityList, string BundleName, string BundleDescription, int Warrenty, int BundleID)
        {
            try
            {
                return oBundleBL.UpdateBundleBL(MaterialIDQuantityList, BundleName, BundleDescription, Warrenty, BundleID);
            }
            catch (Exception ex)
            {
                oException.StackTrace = ex.StackTrace;
                oException.ErrorReason = ex.Message;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="oBundleProperty"></param>
        ///// <param name="MaterialIDList"></param>
        ///// <returns></returns>
        //public string BundleEdit(BundleProperty oBundleProperty, string MaterialIDList)
        //{
        //    string result = null;
        //    try
        //    {
        //        result = oBundleBL.BundleEdit(oBundleProperty, MaterialIDList);
        //    }
        //    catch (Exception ex)
        //    {
        //        oException.StackTrace = ex.StackTrace;
        //        oException.ErrorReason = ex.Message;
        //        throw new FaultException<ExceptionClass>(oException, ex.Message);
        //    }
        //    return result;
        //}

        public List<BundleProperty> GetBundleListBasedOnCategory(string CategoryName)
        {
            try
            {
                return oBundleBL.GetBundleListBasedOnCategoryBL(CategoryName);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public List<MaterialProperty> GetBundleMappingMaterial(int BundleID)
        {
            try
            {
                return oBundleBL.GetBundleMappingMaterialBL(BundleID);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public List<string> GetCategoryNameList()
        {
            try
            {
                return oBundleBL.GetCategoryList();
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public List<MaterialProperty> GetMaterialListBasedOnCategory(string CategoryName)
        {
            try
            {
                return oBundleBL.MaterialListBasedOnCategoryName(CategoryName);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        /// <summary>
        /// Retrives the List of SalesOrganizationProperty.
        /// </summary>
        /// <returns>returns SalesOrgranizationPropertyList</returns>
        public List<SalesOrganizationProperty> GetSalesOrganizationListService()
        {
            try
            {
                return OSalesOrganizationBL.GetSalesListProperty();
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        /// <summary>
        /// It Retrives a Single Record.
        /// </summary>
        /// <param name="SalesOrgCode"></param>
        /// <returns>It Returns a SalesOrganizationProperty</returns>
        public SalesOrganizationProperty GetSalesOrganizationRecord(int SalesOrgCode)
        {
            try
            {
                return OSalesOrganizationBL.GetSingleRecordList(SalesOrgCode);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        /// <summary>
        /// It Inserts a Record into the Database.
        /// </summary>
        /// <param name="OSalesOrganizationProperty"></param>
        /// <returns>Returns a string whether the insertion was sucessful or not.</returns>
        public string InsertRecordService(SalesOrganizationProperty OSalesOrganizationProperty)
        {
            try
            {
                return OSalesOrganizationBL.GetInsertedRecords(OSalesOrganizationProperty);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        /// <summary>
        /// It Updates a Record in the Database.
        /// </summary>
        /// <param name="OSalesOrganizationProperty"></param>
        /// <returns>Returns a string whether the Updation was sucessful or not</returns>
        public string UpdateRecordService(SalesOrganizationProperty OSalesOrganizationProperty)
        {
            try
            {
                return OSalesOrganizationBL.GetUpdatedRecord(OSalesOrganizationProperty);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SalesOrgCode"></param>
        /// <returns></returns>
        public string DeleteRecordService(int SalesOrgCode)
        {
            try
            {
                return OSalesOrganizationBL.DeleteSalesRecordBL(SalesOrgCode);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }





        UserRegistrationBL oUserRegBL = new UserRegistrationBL();
        public string UserRegistrationService(UserRegistration oUserReg, byte[] oUserImage, string name)
        {
            try
            {
                return oUserRegBL.InsertUserRegistrationBL(oUserReg, oUserImage, name);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public List<CompanyValues> CompanyNameService()
        {
            try
            {
                return oUserRegBL.CompanyNameListBL();
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UserRoleList> RoleNameService()
        {
            try
            {
                return oUserRegBL.RoleNameListBL();
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<RegistrationGrid> RegistrationListService()
        {
            try
            {
                return oUserRegBL.UserRegistrationListBL();
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="CompanyCode"></param>
        /// <returns></returns>
        public RegistrationGrid SingleRegistrationService(int UserId, int CompanyCode)
        {
            try
            {
                return oUserRegBL.SingleRegistrationBL(UserId, CompanyCode);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oUserReg"></param>
        /// <returns></returns>
        public string UpdateRegistrationService(RegistrationGrid oUserReg, byte[] oUserImage, string name)
        {
            try
            {
                return oUserRegBL.UpdateRegistrationBL(oUserReg, oUserImage, name);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public string DeleteRegistrationService(int UserId)
        {
            try
            {
                return oUserRegBL.DeleteRegistrationBL(UserId);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }
        public List<ImageProperty> GetImageService()
        {
            try
            {
                return oMaterialBL.GetImageBL();
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }

        }

        CompanyBL oCompanyBL = new CompanyBL();
        public List<CompanyProperty> GetCompanyNameService()
        {
            try
            {
                return oCompanyBL.GetCompanyNameBL();
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public CompanyProperty GetSingleCompanyName(int CompanyCode)
        {
            try
            {
                return oCompanyBL.SingleCompanyNameBL(CompanyCode);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public string InsertCompanyNameService(CompanyProperty oCompanyProperty)
        {
            try
            {
                return oCompanyBL.InsertCompanyNameBL(oCompanyProperty);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public string UpdateCompanyNameService(CompanyProperty oCompanyProperty)
        {
            try
            {
                return oCompanyBL.UpdateCompanyNameBL(oCompanyProperty);
            }

            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public string DeleteCompanyNameService(int CompanyCode)
        {
            try
            {
                return oCompanyBL.DeleteCompanyNameBL(CompanyCode);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }


        public bool CheckAuthentication(LoginProperty oLogin)
        {
            try
            {
                return oCheckAuthentication.CheckAuthenticationBL(oLogin);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public byte[] GetUserImage(int UserId)
        {
            try
            {
                return oCheckAuthentication.GetUserImageBL(UserId);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public Dictionary<int, string> GetUserName(LoginProperty oLogin)
        {
            try
            {
                return oCheckAuthentication.GetUserNameBL(oLogin);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        RulesBL oRules = new RulesBL();

        public List<RulesProperty> GetRulesList()
        {
            try
            {
                return oRules.GetRulesListBL();
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public RulesProperty GetSingleRule(int RuleId)
        {
            try
            {
                return oRules.GetSingleRuleBL(RuleId);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public string InsertRule(RulesProperty oRulesProperty)
        {
            try
            {
                return oRules.InsertRuleBL(oRulesProperty);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public string UpdateRule(RulesProperty oRulesProperty)
        {
            try
            {
                return oRules.UpdateRuleBL(oRulesProperty);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        public string DeleteRule(int RuleId)
        {
            try
            {
                return oRules.DeleteRuleBL(RuleId);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
        }

        //public List<QuoteBundleMaterial> GetQuoteBasedClientConfigureBundle(int QuoteID, string Request)
        //{
        //    try
        //    {
        //        return oBundleBL.QuoteBasedClientConfigureBundle(QuoteID, Request);
        //    }
        //    catch (Exception ex)
        //    {
        //        eDetails.ErrorMessage = ex.Message;
        //        eDetails.ErrorDetails = ex.StackTrace;
        //        throw new FaultException<Error>(eDetails, ex.ToString());
        //    }
        //}        

        //public QuoteBundleMaterialList GetConfigureBundleSingleRecord(int BundleId, int QuoteID)
        //{
        //    try
        //    {
        //        return oBundleBL.GetConfigureBundleSingleRecordBL(BundleId, QuoteID);
        //    }
        //    catch (Exception ex)
        //    {
        //        eDetails.ErrorDetails = ex.StackTrace;
        //        eDetails.ErrorMessage = ex.Message;
        //        throw new FaultException<Error>(eDetails, ex.ToString());
        //    }
        //}

        

        //public List<string> GetCategoryNameList()
        //{
        //    try
        //    {
        //        return oBundleBL.GetCategoryList();
        //    }
        //    catch (Exception ex)
        //    {
        //        eDetails.ErrorDetails = ex.StackTrace;
        //        eDetails.ErrorMessage = ex.Message;
        //        throw new FaultException<Error>(eDetails, ex.ToString());
        //    }
        //}



        //public MaterialProperty GetMaterialSingleRecord(int MaterialID, decimal BudgetTargetRate)
        //{
        //    try
        //    {
        //        return oBundleBL.MaterialSingleRecordGet(MaterialID, BudgetTargetRate);
        //    }
        //    catch (Exception ex)
        //    {
        //        eDetails.ErrorMessage = ex.Message;
        //        eDetails.ErrorDetails = ex.StackTrace;
        //        throw new FaultException<Error>(eDetails, ex.ToString());
        //    }
        //}

        //public string UpdateBundleMaterialRecord(int QuoteID, int? MaterialID, int? BundleID, string Type, int Quantity, decimal NetPrice)
        //{
        //    try
        //    {
        //        return oBundleBL.BundleMaterialUpdate(QuoteID, Type, MaterialID, BundleID, Quantity, NetPrice);
        //    }
        //    catch (Exception ex)
        //    {
        //        eDetails.ErrorMessage = ex.Message;
        //        eDetails.ErrorDetails = ex.StackTrace;
        //        throw new FaultException<Error>(eDetails, ex.ToString());
        //    }
        //}

    }
}
