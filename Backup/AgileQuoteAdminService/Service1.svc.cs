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
      public  int InsertRentalSparsService(RentalSparsProperty oRentalSpars)
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
      public  RentalSparsProperty SingleRentalSparsService(int RentalSparsId)
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
        public string InsertRoleRecordService(RoleProperty rp)
        {
            try
            {
                return oRoleBL.InsertRoleRecordBL(rp);
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
        public string UpdateRoleService(RoleProperty rp)
        {
            try
            {
                return oRoleBL.UpdateRoleRecordBL(rp);
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
        public string InsertCurrencyRecordService(CurrencyProperty cp)
        {
            try
            {
                return oCurrencyBL.InsertCurrencyRecordBL(cp);
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
        public string UpdateCurrencyService(CurrencyProperty cp)
        {
            try
            {
                return oCurrencyBL.UpdateCurrencyBL(cp);
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
        public MaterialProperty GetMaterialListByID(int id)
        {
            try
            {
                return oMaterialBL.GetMaterialByID(id);
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
                int MaterialId = oMaterialBL.InsertMaterial(oMaterialParameter);
                return MaterialId;
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
                int MaterialID = oMaterialBL.UpdateMaterial(oMaterialParameter);
                return MaterialID;
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
        public string DeleteMaterial(int ID)
        {
            try
            {
                string status = oMaterialBL.DeleteMaterial(ID);
                return status;
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
        public string CreateBundle(string BundleName, string Catagory, List<string> FromMaterialID)
        {

            try
            {
                string status = oBundleBL.CreateBundle(BundleName,Catagory, FromMaterialID);
                return status;
            }
            catch (Exception ex)
            {
                oException.StackTrace = ex.StackTrace;
                oException.ErrorReason = ex.Message;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }

        }

        public List<BundleProperty> GetBundleListService(string id)
        {
            try
            {
                return oBundleBL.GetBundleList(id);
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
        /// <param name="BundleName"></param>
        /// <param name="FromMaterialID"></param>
        /// <returns></returns>
        public string UpdateBundle(string BundleName, List<string> FromMaterialID)
        {
            try
            {
                string status = oBundleBL.UpdateBundle(BundleName, FromMaterialID);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oBundleProperty"></param>
        /// <param name="MaterialIDList"></param>
        /// <returns></returns>
        public string BundleEdit(BundleProperty oBundleProperty, string MaterialIDList)
        {
            string result = null;
            try
            {
                result = oBundleBL.BundleEdit(oBundleProperty, MaterialIDList);
            }
            catch (Exception ex)
            {
                oException.StackTrace = ex.StackTrace;
                oException.ErrorReason = ex.Message;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
            return result;
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
                List<CompanyValues> list = oUserRegBL.CompanyNameListBL();
                return list;
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
                List<UserRoleList> oRoleList = oUserRegBL.RoleNameListBL();
                return oRoleList;
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

        LogInBL oCheckAuthentication = new LogInBL();
        public bool CheckAuthentication(LoginProperty oLogin)
        {
            bool oResult = false;
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
            return oResult;
        }
        public byte[] GetUserImage(int UserId)
        {
            byte[] Uimage;
            try
            {
                Uimage = oCheckAuthentication.GetUserImageBL(UserId);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
            return Uimage;
        }
        public Dictionary<int, string> GetUserName(LoginProperty oLogin)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            try
            {
                dictionary = oCheckAuthentication.GetUserNameBL(oLogin);
            }
            catch (Exception ex)
            {
                oException.ErrorReason = ex.Message;
                oException.StackTrace = ex.StackTrace;
                throw new FaultException<ExceptionClass>(oException, ex.Message);
            }
            return dictionary;

        }
    }
}
