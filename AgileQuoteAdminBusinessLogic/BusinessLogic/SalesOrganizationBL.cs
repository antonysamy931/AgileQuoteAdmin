using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileQuoteAdminProperty.Property;
using AgileQuoteDataLogic.DataLogic;
namespace AgileQuoteAdminBusinessLogic.BusinessLogic
{
    public class SalesOrganizationBL
    {
        SalesOrganizationDL OSalesOrganizationDL = new SalesOrganizationDL();
        SalesOrgranizationPropertyList OSalesOrgranizationPropertyList = new SalesOrgranizationPropertyList();

        /// <summary>
        ///  Retriving the List of SalesOrgranizationProperty from SalesOrganizationDL and assigns it to a List.
        /// </summary>
        /// <returns>Returns SalesOrgranizationPropertyList </returns>
        public List<SalesOrganizationProperty> GetSalesListProperty()
        {
            try
            {
                return OSalesOrganizationDL.GetSalesList();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        ///  Retriving the Record from the SalesOrganizationDL.
        /// </summary>
        /// <param name="SalesOrgCode"></param>
        /// <returns>Returns Single Record for a Given SalesOrgCode</returns>
        public SalesOrganizationProperty GetSingleRecordList(int SalesOrgCode)
        {
            try
            {
                return OSalesOrganizationDL.GetSingleRecord(SalesOrgCode);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Inserting the Record Into the SalesOrganization.
        /// </summary>
        /// <param name="OSalesOrganizationProperty"></param>
        /// <returns>Returns whether the Insertion was sucessful or not</returns>        
        public string GetInsertedRecords(SalesOrganizationProperty OSalesOrganizationProperty)
        {

            try
            {
                if (!OSalesOrganizationDL.IsSalesRecordInsertable(OSalesOrganizationProperty.ReferenceCustomerCode, OSalesOrganizationProperty.SalesOrgName))
                {
                    return OSalesOrganizationDL.InsertSalesRecord(OSalesOrganizationProperty);                    
                }
                else
                {
                    return "Duplicate record occured";                    
                }
            }
            catch 
            {
                throw;
            }
        }

        /// <summary>
        /// Updating a record in the SalesOrganization.
        /// </summary>
        /// <param name="OSalesOrganizationProperty"></param>
        /// <returns>Returns whether the Updation was sucessful or not</returns>
        public string GetUpdatedRecord(SalesOrganizationProperty OSalesOrganizationProperty)
        {                        
                try
                {
                    if (!OSalesOrganizationDL.IsSalesRecordUpdatable(OSalesOrganizationProperty))
                    {
                        return OSalesOrganizationDL.UpdateSalesRecord(OSalesOrganizationProperty);
                    }
                    else
                    {
                        return "Duplicate record occured";
                    }
                }
                catch
                {
                    throw;
                }            
        }

        public string DeleteSalesRecordBL(int SalesOrgCode)
        {            
            try
            {
                return OSalesOrganizationDL.DeleteSalesRecordDL(SalesOrgCode);
            }
            catch
            {
                throw;
            }
        }

    }
}
