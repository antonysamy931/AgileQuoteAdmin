using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileQuoteAdminProperty.Property;
using AgileQuoteDataLogic.Data;
using LogWriter;
namespace AgileQuoteDataLogic.DataLogic
{
    public class SalesOrganizationDL
    {

        AgileQuoteDevelopmentEntitiesV Entities = new AgileQuoteDevelopmentEntitiesV();
        /// <summary>
        /// It retrives the List of SalesOrganizationProperty Objects, Which contains
        /// the values of the field of a Record in the SalesOrganization Table.
        /// </summary>
        /// <returns>Returns List of SalesOrganizationProperty</returns>
        public List<SalesOrganizationProperty> GetSalesList()
        {
            List<SalesOrganizationProperty> SalesList = new List<SalesOrganizationProperty>();
            SalesOrganizationProperty OSalesOrganizationProperty = null;

            try
            {
                var OSalesList = Entities.SalesOrgSelect(null).ToList();
                foreach (var item in OSalesList)
                {
                    OSalesOrganizationProperty = new SalesOrganizationProperty();
                    OSalesOrganizationProperty.SalesOrgCode = item.SalesOrganizationCode;
                    OSalesOrganizationProperty.SalesOrgName = item.SalesOrganizationName;
                    OSalesOrganizationProperty.IsActive = (bool)item.IsActive;
                    OSalesOrganizationProperty.IsDelete = (bool)item.IsDelete;
                    OSalesOrganizationProperty.ReferenceCustomerCode = item.ReferenceCustomerCode;
                    SalesList.Add(OSalesOrganizationProperty);
                }
                return SalesList;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// It retrives All the fields of a record for a given SalesOrgCode from the SalesOrganization Table.
        /// </summary>
        /// <param name="SalesOrgCode"></param>
        /// <returns>Returns SalesOrganizationProperty Object</returns>
        public SalesOrganizationProperty GetSingleRecord(int SalesOrgCode)
        {
            SalesOrganizationProperty sProperty = new SalesOrganizationProperty();
            try
            {
                var obj = Entities.SalesOrgSelect(SalesOrgCode.ToString()).FirstOrDefault();
                if (obj != null)
                {
                    sProperty.ReferenceCustomerCode = obj.ReferenceCustomerCode;
                    sProperty.SalesOrgCode = obj.SalesOrganizationCode;
                    sProperty.SalesOrgName = obj.SalesOrganizationName;
                    sProperty.IsActive = obj.IsActive;
                    sProperty.IsDelete = obj.IsDelete;
                }
                return sProperty;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Inserting a Record into the SalesOrganization Table withour allowing the Dublicates.
        /// </summary>
        /// <param name="OSalesOrganizationProperty"></param>
        /// <returns>Returns a String Indicating Whether the Insertion was Sucessful or not.</returns>
        public string InsertSalesRecord(SalesOrganizationProperty OSalesOrganizationProperty)
        {
            tbSalesOrganization OsalesOrganization = new tbSalesOrganization();
            try
            {
                OsalesOrganization.SalesOrganizationCode = OSalesOrganizationProperty.SalesOrgCode;
                OsalesOrganization.SalesOrganizationName = OSalesOrganizationProperty.SalesOrgName;
                OsalesOrganization.ReferenceCustomerCode = OSalesOrganizationProperty.ReferenceCustomerCode;
                OsalesOrganization.IsActive = true;
                OsalesOrganization.IsDelete = false;
                Entities.tbSalesOrganizations.AddObject(OsalesOrganization);
                Entities.SaveChanges();
                return "Success";
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Updates the SalesOrganization Table.
        /// </summary>
        /// <param name="OSalesOrganizationProperty"></param>
        public string UpdateSalesRecord(SalesOrganizationProperty OSalesOrganizationProperty)
        {
            try
            {
                var Record = Entities.tbSalesOrganizations.Where(x => x.SalesOrganizationCode == OSalesOrganizationProperty.SalesOrgCode && x.IsDelete == false && x.IsActive == true).FirstOrDefault();
                if (Record != null)
                {
                    Record.SalesOrganizationName = OSalesOrganizationProperty.SalesOrgName;
                    Record.ReferenceCustomerCode = OSalesOrganizationProperty.ReferenceCustomerCode;
                    Record.IsActive = OSalesOrganizationProperty.IsActive;
                    Record.IsDelete = OSalesOrganizationProperty.IsDelete;
                    Entities.SaveChanges();
                }
                return "Success";

            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Validating for Insertion and Updation. 
        /// </summary>
        /// <param name="ReferenceCode"></param>
        /// <param name="SalesOrgName"></param>
        /// <returns>bool value indicating Whether to insert,update or not</returns>
        public bool IsSalesRecordInsertable(string ReferenceCode, string SalesOrgName)
        {
            try
            {
                return Entities.tbSalesOrganizations.Where(x => x.ReferenceCustomerCode == ReferenceCode || x.SalesOrganizationName == SalesOrgName && x.IsActive == true && x.IsDelete == false).Any();
            }
            catch
            {
                throw;
            }
        }

        public bool IsSalesRecordUpdatable(SalesOrganizationProperty OSalesOrganizationProperty)
        {
            try
            {
                if (OSalesOrganizationProperty.IsActive && !OSalesOrganizationProperty.IsDelete)
                {
                    return Entities.tbSalesOrganizations.Where(x => (x.ReferenceCustomerCode == OSalesOrganizationProperty.ReferenceCustomerCode || x.SalesOrganizationName == OSalesOrganizationProperty.SalesOrgName) && x.IsActive == true && x.IsDelete == false && x.SalesOrganizationCode != OSalesOrganizationProperty.SalesOrgCode).Any();
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }

        public string DeleteSalesRecordDL(int SalesOrgCode)
        {
            try
            {
                var Obj = Entities.tbSalesOrganizations.Where(x => x.SalesOrganizationCode == SalesOrgCode && x.IsDelete == false && x.IsActive == true).FirstOrDefault();
                if (Obj != null)
                {
                    Obj.IsActive = false;
                    Obj.IsDelete = true;
                    Entities.SaveChanges();
                    return "Success";
                }
                else
                {
                    return "Failed";
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
