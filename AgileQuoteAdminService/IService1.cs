using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AgileQuoteAdminProperty.Property;

namespace AgileQuoteAdminService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RentalSparsId"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string DeleteRentalSparsService(int RentalSparsId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oRentalSpars"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        int UpdateRentalSparsService(RentalSparsProperty oRentalSpars);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RentalSparsId"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        RentalSparsProperty SingleRentalSparsService(int RentalSparsId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        List<RentalSparsProperty> RentalSparsListService();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oRentalSpars"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        int InsertRentalSparsService(RentalSparsProperty oRentalSpars);


        /// <summary>
        /// GetRoleListService interface is declared which is used to retrive all records
        /// </summary>
        /// <returns>Returns the list of all records</returns>        
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        List<RoleProperty> GetRoleListService();

        /// <summary>
        /// GetSingleRoleRecordService interface is declared which is used to retrive single record
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns>Returns the single record list</returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        RoleProperty GetSingleRoleRecordService(int RoleId);

        /// <summary>
        /// InsertRoleRecordService interface is declared which is used to insert record
        /// </summary>
        /// <param name="rp"></param>
        /// <returns>Returns whether the Insertion was sucessful or not</returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string InsertRoleRecordService(RoleProperty oRoleProperty);

        /// <summary>
        /// UpdateRoleService interface is used to update record into the Data Base
        /// </summary>
        /// <param name="rp"></param>
        /// <returns>Returns whether the Updation was sucessful or not</returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string UpdateRoleService(RoleProperty oRoleProperty);

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string DeleteRoleService(int RoleID);


        /// <summary>
        /// To get all records.
        /// </summary>
        /// <returns>List of currencyproperty.</returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        List<CurrencyProperty> GetCurrencyListService();

        /// <summary>
        /// To get a single record.
        /// </summary>
        /// <param name="CurrencyId"></param>
        /// <returns>currencyproperty</returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        CurrencyProperty GetSingleCurrencyRecordService(int CurrencyId);

        /// <summary>
        /// To insert the records.
        /// </summary>
        /// <param name="cp"></param>
        /// <returns>string</returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string InsertCurrencyRecordService(CurrencyProperty oCurrencyProperty);
        /// <summary>
        /// To update the records.
        /// </summary>
        /// <param name="cp"></param>
        /// <returns>string</returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string UpdateCurrencyService(CurrencyProperty oCurrencyProperty);
        /// <summary>
        /// To Delete the record.
        /// </summary>
        /// <returns>string</returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string DeleteCurrrencyService(int CurrencyId);



        /// <summary>
        /// It Retrives the List of SalesOrganizationProperty
        /// </summary>
        /// <returns>Returns List of SalesOrganizationProperty</returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        List<SalesOrganizationProperty> GetSalesOrganizationListService();

        /// <summary>
        /// It Retrives the a Record for a Given Sales Organization Code
        /// </summary>
        /// <param name="SalesOrgCode"></param>
        /// <returns>Returns a Record</returns>       
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        SalesOrganizationProperty GetSalesOrganizationRecord(int SalesOrgCode);

        /// <summary>
        /// Inserts A Record into the SalesOrganization Table.
        /// </summary>
        /// <param name="OsalesOrganizationProperty"></param>
        /// <returns>Returns whether the insertion was sucessful or not</returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string InsertRecordService(SalesOrganizationProperty OsalesOrganizationProperty);

        /// <summary>
        /// Updates A Record.
        /// </summary>
        /// <param name="OsalesOrganizationProperty"></param>
        /// <returns>>Returns whether the Updation was sucessful or not</returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string UpdateRecordService(SalesOrganizationProperty OsalesOrganizationProperty);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string DeleteRecordService(int SalesOrgCode);



        /// <summary>
        /// gets lists of material as a service
        /// </summary>
        /// <returns>list of material property</returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        List<MaterialProperty> GetMaterialListService();
        /// <summary>
        /// gets material list by its ID as a service
        /// </summary>
        /// <param name="id"></param>
        /// <returns>material list property</returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        MaterialProperty GetMaterialListByID(int oMaterialId);
        /// <summary>
        /// inserts material to the database from user
        /// </summary>
        /// <param name="oMaterialParameter"></param>
        /// <returns>string that indicates the status of Insertion</returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        int InsertMaterial(MaterialProperty oMaterialParameter);
        /// <summary>
        /// updates material to the database from user
        /// </summary>
        /// <param name="oMaterialParameter"></param>
        /// <returns>string that indicates the status of updation</returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        int UpdateMaterial(MaterialProperty oMaterialParameter);
        /// <summary>
        /// updates value of isdelete field in datasbase to true
        /// </summary>
        /// <param name="oMaterialParameter"></param>
        /// <returns>string value that indicates the status of deletion</returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string DeleteMaterial(int oMaterialId);

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        List<CategoryProperty> CategoryList();

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string SugectionMaterialMapping(List<int> oMaterialList, int MaterialId);

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        List<MaterialProperty> GetMaterialMappingSugectionMaterial(int MaterialId);

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string DeleteSugectionMaterial(int MaterialID, int MappingMaterial);

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string OfferedMaterialMapping(List<int> oMaterialList, int MaterialId);

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        List<MaterialProperty> GetMaterialMappingOfferedMaterial(int MaterialId);

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string DeleteOfferedMaterial(int MaterialID, int MappingMaterial);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        List<RentalProductsProperty> GetRentalProductsListService();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        RentalProductsProperty GetRentalProductsListByID(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oRentalProductsParameter"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        int InsertRentalProducts(RentalProductsProperty oRentalProductsParameter);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oRentalProductsParameter"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        int UpdateRentalProducts(RentalProductsProperty oRentalProductsParameter);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string DeleteRentalProducts(int ID);

        // TODO: Add your service operations here
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="ID"></param>
        ///// <returns></returns>
        //[OperationContract]
        //[FaultContract(typeof(ExceptionClass))]
        //string CreateBundle(string BundleName, string Catagory, List<string> FromMaterialID);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="BundleName"></param>
        ///// <param name="FromMaterialID"></param>
        ///// <returns></returns>
        //[OperationContract]
        //[FaultContract(typeof(ExceptionClass))]
        //string UpdateBundle(string BundleName, List<string> FromMaterialID);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //[OperationContract]
        //[FaultContract(typeof(ExceptionClass))]
        //List<BundleProperty> GetBundleListService(string id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        List<string> GetMaterialBundleMapping(string id);

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        List<BundleProperty> GetBundleListBasedOnCategory(string CategoryName);

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        List<MaterialProperty> GetBundleMappingMaterial(int BundleID);

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        List<string> GetCategoryNameList();

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        List<MaterialProperty> GetMaterialListBasedOnCategory(string CategoryName);

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        BundleProperty GetBundleSingleRecord(int BundleID);

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string InsertMaterialMappingToBundle(Dictionary<int, int> MaterialIDQuantinyList, string BundleName, int UserID, string BundleDescription, int Warrenty);

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string DeleteBundleMaterialRecord(int BundleID);

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string UpdateBundle(Dictionary<int, int> MaterialIDQuantityList, string BundleName, string BundleDescription, int Warrenty, int BundleID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oBundleProperty"></param>
        /// <param name="MaterialIDList"></param>
        /// <returns></returns>
        //[OperationContract]
        //[FaultContract(typeof(ExceptionClass))]
        //string BundleEdit(BundleProperty oBundleProperty, string MaterialIDList);




        /// <summary>
        /// 
        /// </summary>
        /// <param name="oUserReg"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string UserRegistrationService(UserRegistration oUserReg, byte[] oUserImage, string name);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        List<CompanyValues> CompanyNameService();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        List<RegistrationGrid> RegistrationListService();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        List<UserRoleList> RoleNameService();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="CompanyCode"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        RegistrationGrid SingleRegistrationService(int UserId, int CompanyCode);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oUserReg"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string UpdateRegistrationService(RegistrationGrid oUserReg, byte[] oUserImage, string name);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string DeleteRegistrationService(int UserId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        List<ImageProperty> GetImageService();

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        List<CompanyProperty> GetCompanyNameService();

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        CompanyProperty GetSingleCompanyName(int CompanyCode);

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string InsertCompanyNameService(CompanyProperty oCompanyProperty);

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string UpdateCompanyNameService(CompanyProperty oCompanyProperty);

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string DeleteCompanyNameService(int CompanyCode);


        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        bool CheckAuthentication(LoginProperty oLogin);

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        byte[] GetUserImage(int UserId);

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        Dictionary<int, string> GetUserName(LoginProperty oLogin);



        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        List<RulesProperty> GetRulesList();

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        RulesProperty GetSingleRule(int RuleId);

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string InsertRule(RulesProperty oRulesProperty);

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string UpdateRule(RulesProperty oRulesProperty);

        [OperationContract]
        [FaultContract(typeof(ExceptionClass))]
        string DeleteRule(int RuleId);

        //[OperationContract]
        //[FaultContract(typeof(Error))]
        //List<QuoteBundleMaterial> GetQuoteBasedClientConfigureBundle(int QuoteID, string Request);        

        //[OperationContract]
        //[FaultContract(typeof(Error))]
        //QuoteBundleMaterialList GetConfigureBundleSingleRecord(int BundleId, int QuoteID);





        //[OperationContract]
        //[FaultContract(typeof(Error))]
        //MaterialProperty GetMaterialSingleRecord(int MaterialID, decimal BudgetTargetRate);

        //[OperationContract]
        //[FaultContract(typeof(Error))]
        //string UpdateBundleMaterialRecord(int QuoteID, int? MaterialID, int? BundleID, string Type, int Quantity, decimal NetPrice);


    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
