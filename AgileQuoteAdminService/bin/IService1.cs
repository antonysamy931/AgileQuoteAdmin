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
        /// GetRoleListService interface is declared which is used to retrive all records
        /// </summary>
        /// <returns>Returns the list of all records</returns>
        [FaultContract(typeof(ExceptionClass))]
        [OperationContract]
        List<RoleProperty> GetRoleListService();

        /// <summary>
        /// GetSingleRoleRecordService interface is declared which is used to retrive single record
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns>Returns the single record list</returns>
        [OperationContract]
        RoleProperty GetSingleRoleRecordService(int RoleId);

        /// <summary>
        /// InsertRoleRecordService interface is declared which is used to insert record
        /// </summary>
        /// <param name="rp"></param>
        /// <returns>Returns whether the Insertion was sucessful or not</returns>
        [OperationContract]
        string InsertRoleRecordService(RoleProperty rp);

        /// <summary>
        /// UpdateRoleService interface is used to update record into the Data Base
        /// </summary>
        /// <param name="rp"></param>
        /// <returns>Returns whether the Updation was sucessful or not</returns>
        [OperationContract]
        string UpdateRoleService(RoleProperty rp);
        [OperationContract]
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
        CurrencyProperty GetSingleCurrencyRecordService(int CurrencyId);
        /// <summary>
        /// To insert the records.
        /// </summary>
        /// <param name="cp"></param>
        /// <returns>string</returns>
        [OperationContract]
        string InsertCurrencyRecordService(CurrencyProperty cp);
        /// <summary>
        /// To update the records.
        /// </summary>
        /// <param name="cp"></param>
        /// <returns>string</returns>
        [OperationContract]
        string UpdateCurrencyService(CurrencyProperty cp);
        /// <summary>
        /// To Delete the record.
        /// </summary>
        /// <returns>string</returns>
        [OperationContract]
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
        SalesOrganizationProperty GetSalesOrganizationRecord(int SalesOrgCode);

        /// <summary>
        /// Inserts A Record into the SalesOrganization Table.
        /// </summary>
        /// <param name="OsalesOrganizationProperty"></param>
        /// <returns>Returns whether the insertion was sucessful or not</returns>
        [OperationContract]
        string InsertRecordService(SalesOrganizationProperty OsalesOrganizationProperty);

        /// <summary>
        /// Updates A Record.
        /// </summary>
        /// <param name="OsalesOrganizationProperty"></param>
        /// <returns>>Returns whether the Updation was sucessful or not</returns>
        [OperationContract]
        string UpdateRecordService(SalesOrganizationProperty OsalesOrganizationProperty);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        string DeleteRecordService(int SalesOrgCode);



        /// <summary>
        /// gets lists of material as a service
        /// </summary>
        /// <returns>list of material property</returns>
        [OperationContract]
        List<MaterialProperty> GetMaterialListService();
        /// <summary>
        /// gets material list by its ID as a service
        /// </summary>
        /// <param name="id"></param>
        /// <returns>material list property</returns>
        [OperationContract]
        MaterialProperty GetMaterialListByID(int id);
        /// <summary>
        /// inserts material to the database from user
        /// </summary>
        /// <param name="oMaterialParameter"></param>
        /// <returns>string that indicates the status of Insertion</returns>
        [OperationContract]
        string InsertMaterial(MaterialProperty oMaterialParameter);
        /// <summary>
        /// updates material to the database from user
        /// </summary>
        /// <param name="oMaterialParameter"></param>
        /// <returns>string that indicates the status of updation</returns>
        [OperationContract]
        string UpdateMaterial(MaterialProperty oMaterialParameter);
        /// <summary>
        /// updates value of isdelete field in datasbase to true
        /// </summary>
        /// <param name="oMaterialParameter"></param>
        /// <returns>string value that indicates the status of deletion</returns>
        [OperationContract]
        string DeleteMaterial(int ID);









 
        [OperationContract]
        List<RentalProductsProperty> GetRentalProductsListService();
       
        [OperationContract]
        RentalProductsProperty GetRentalProductsListByID(int id);
         
        [OperationContract]
        string InsertRentalProducts(RentalProductsProperty oRentalProductsParameter);
        
        [OperationContract]
        string UpdateRentalProducts(RentalProductsProperty oRentalProductsParameter);
       
        [OperationContract]
        string DeleteRentalProducts(int ID);







        // TODO: Add your service operations here
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [OperationContract]
        string CreateBundle(string BundleName, string Catagory, List<string> FromMaterialID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BundleName"></param>
        /// <param name="FromMaterialID"></param>
        /// <returns></returns>
        [OperationContract]
        string UpdateBundle(string BundleName, List<string> FromMaterialID);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<BundleProperty> GetBundleListService(string id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        List<string> GetMaterialBundleMapping(string id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oBundleProperty"></param>
        /// <param name="MaterialIDList"></param>
        /// <returns></returns>
        [OperationContract]
        string BundleEdit(BundleProperty oBundleProperty, string MaterialIDList);




        /// <summary>
        /// 
        /// </summary>
        /// <param name="oUserReg"></param>
        /// <returns></returns>
        [OperationContract]
        string UserRegistrationService(UserRegistration oUserReg);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CompanyValues> CompanyNameService();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<RegistrationGrid> RegistrationListService();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<UserRoleList> RoleNameService();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="CompanyCode"></param>
        /// <returns></returns>
        [OperationContract]
        RegistrationGrid SingleRegistrationService(int UserId, int CompanyCode);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oUserReg"></param>
        /// <returns></returns>
        [OperationContract]
        string UpdateRegistrationService(RegistrationGrid oUserReg);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [OperationContract]
        string DeleteRegistrationService(int UserId);


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
