using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileQuoteAdminProperty.Property;
using AgileQuoteDataLogic.Data;

namespace AgileQuoteDataLogic.DataLogic
{
    public class CompanyDL
    {
        AgileQuoteAdminDevelopmentEntities Entities = new AgileQuoteAdminDevelopmentEntities();
        /// <summary>
        /// To display all the records in company table.
        /// </summary>
        /// <returns></returns>
        public List<CompanyProperty> GetCompanyNameDL()
        {
            List<CompanyProperty> oCompanyNameList = new List<CompanyProperty>();
            CompanyProperty oCompany = null;
            try
            {
                var oCompanyName = Entities.spCompanySelect(null).ToList();
                foreach (var item in oCompanyName)
                {
                    oCompany = new CompanyProperty();
                    oCompany.CompanyCode = item.CompanyCode;
                    oCompany.CompanyName = item.CompanyName;
                    oCompany.IsActive = true;
                    oCompany.IsDelete = false;
                    oCompanyNameList.Add(oCompany);
                }
                return oCompanyNameList;
            }
            catch
            {
                throw;
            }            
        }

        /// <summary>
        /// To display single record in company table.
        /// </summary>
        /// <param name="CompanyCode"></param>
        /// <returns></returns>
        public CompanyProperty SingleCompanyNameDL(int CompanyCode)
        {
            CompanyProperty oCompanyProperty = new CompanyProperty();
            try
            {
                var oSingleCompanyName = Entities.spCompanySelect(CompanyCode).FirstOrDefault();
                if (oSingleCompanyName != null)
                {
                    oCompanyProperty.CompanyCode = oSingleCompanyName.CompanyCode;
                    oCompanyProperty.CompanyName = oSingleCompanyName.CompanyName;
                    oCompanyProperty.IsActive = true;
                    oCompanyProperty.IsDelete = false;
                }
                return oCompanyProperty;
            }
            catch
            {
                throw;
            }        
        }

        /// <summary>
        /// To insert the values in the company table.
        /// </summary>
        /// <param name="oCompanyProperty"></param>
        public string InsertCompanyNameDL(CompanyProperty oCompanyProperty)
        {
            tbCompany oCompany = new tbCompany();
            try
            {
                oCompany.CompanyCode = oCompanyProperty.CompanyCode;
                oCompany.CompanyName = oCompanyProperty.CompanyName;
                oCompany.IsActive = true;
                oCompany.IsDelete = false;
                Entities.tbCompanies.AddObject(oCompany);
                Entities.SaveChanges();
                return "Success";
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// To update the values in the company table.
        /// </summary>
        /// <param name="oCompanyProperty"></param>
        public string UpdateCompanyNameDL(CompanyProperty oCompanyProperty)
        {
            try
            {
                var oCompanyCode = Entities.tbCompanies.Where(x => x.CompanyCode == oCompanyProperty.CompanyCode).FirstOrDefault();
                if (oCompanyCode != null)
                {
                    oCompanyCode.CompanyCode = oCompanyProperty.CompanyCode;
                    oCompanyCode.CompanyName = oCompanyProperty.CompanyName;
                    oCompanyCode.IsActive = oCompanyProperty.IsActive;
                    oCompanyCode.IsDelete = oCompanyProperty.IsDelete;
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
        /// To delete the records in the company table.
        /// </summary>
        /// <param name="CompanyCode"></param>
        public string DeleteCompanyNameDL(int CompanyCode)
        {
            try
            {
                var oDeleteCompanyName = Entities.tbCompanies.Where(x => x.CompanyCode == CompanyCode && x.IsDelete == false && x.IsActive == true).FirstOrDefault();
                if (oDeleteCompanyName != null)
                {
                    oDeleteCompanyName.IsDelete = true;
                    oDeleteCompanyName.IsActive = false;
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
        /// Validation, To avoid duplication.
        /// </summary>
        /// <param name="CompanyName"></param>
        /// <returns></returns>
        public bool IsInserted(string CompanyName)
        {
            try
            {
                return Entities.tbCompanies.Where(x => x.CompanyName == CompanyName && x.IsActive == true && x.IsDelete == false).Any();
            }
            catch
            {
                throw;
            }
        }

        public bool IsUpdated(CompanyProperty oCompanyProperty)
        {
            try
            {
                if (!oCompanyProperty.IsDelete || oCompanyProperty.IsActive)
                {
                    return Entities.tbCompanies.Where(x => x.CompanyName == oCompanyProperty.CompanyName && x.IsActive == true && x.IsDelete == false).Any();
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

    }
}
