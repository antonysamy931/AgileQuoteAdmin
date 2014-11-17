using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileQuoteAdminProperty.Property;
using AgileQuoteDataLogic.DataLogic;

namespace AgileQuoteAdminBusinessLogic.BusinessLogic
{
  public class CompanyBL
    {
      CompanyDL oCompanyDL = new CompanyDL();
      /// <summary>
      /// To display all records.
      /// </summary>
      /// <returns></returns>
      public List<CompanyProperty> GetCompanyNameBL()
      {          
          try
          {
              return oCompanyDL.GetCompanyNameDL();
          }
          catch
          {
              throw;
          }          
      }

      /// <summary>
      /// To display single record.
      /// </summary>
      /// <param name="CompanyCode"></param>
      /// <returns></returns>
      public CompanyProperty SingleCompanyNameBL(int CompanyCode)
      {      
          try
          {
              return oCompanyDL.SingleCompanyNameDL(CompanyCode);
          }
          catch
          {
              throw;
          }          
      }

      /// <summary>
      /// To insert the record.
      /// </summary>
      /// <param name="oCompanyProperty"></param>
      /// <returns></returns>
      public string InsertCompanyNameBL(CompanyProperty oCompanyProperty)
      {
          try
          {
              if (!oCompanyDL.IsInserted(oCompanyProperty.CompanyName))
              {
                  return oCompanyDL.InsertCompanyNameDL(oCompanyProperty);
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
      /// To update the record.
      /// </summary>
      /// <param name="oCompanyProperty"></param>
      /// <returns></returns>
      public string UpdateCompanyNameBL(CompanyProperty oCompanyProperty)
      {          
          try
          {
              if (!oCompanyDL.IsUpdated(oCompanyProperty))
              {
                  return oCompanyDL.UpdateCompanyNameDL(oCompanyProperty);
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
      /// To delete the record.
      /// </summary>
      /// <param name="CompanyCode"></param>
      /// <returns></returns>
      public string DeleteCompanyNameBL(int CompanyCode)
      {          
          try
          {
              return oCompanyDL.DeleteCompanyNameDL(CompanyCode);              
          }
          catch
          {
              throw;
          }          
      }
    }
}
