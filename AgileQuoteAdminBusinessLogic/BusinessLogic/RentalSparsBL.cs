using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileQuoteDataLogic.DataLogic;
using AgileQuoteAdminProperty.Property;
using LogWriter;

namespace AgileQuoteAdminBusinessLogic.BusinessLogic
{
   public class RentalSparsBL
    {
      RentalSparsDL oRentalSpars=new RentalSparsDL();
       /// <summary>
       /// To list all list in RentalSpars table
       /// </summary>
       /// <returns></returns>
      public List<RentalSparsProperty> RentalSparsListBL()
      {
          List<RentalSparsProperty> oRentalSparsList = new List<RentalSparsProperty>();
          try
          {
              oRentalSparsList = oRentalSpars.RentalSparsListDL();
          }
          catch (Exception ex)
          {
              throw ex;
          }
          return oRentalSparsList;
      }
       /// <summary>
       /// To list single record in RentalSpars table.
       /// </summary>
       /// <param name="RentalSparsId"></param>
       /// <returns></returns>
      public RentalSparsProperty SingleRentalSparsBL(int RentalSparsId)
      {
          RentalSparsProperty oSingleRentalSpars = new RentalSparsProperty();
          try
          {
              oSingleRentalSpars = oRentalSpars.SingleRentalSparsDL(RentalSparsId);
           
          }
            catch (Exception ex)
            {
                throw ex;
            }
          return oSingleRentalSpars;
      }
       /// <summary>
       /// To insert the records in table
       /// </summary>
       /// <param name="oRentalSparsProperty"></param>
       /// <returns></returns>
      public int InsertRentalSparsBL(RentalSparsProperty oRentalSparsProperty)
      {
          int RentalSparsID = 0;
          try
          {
              if (!oRentalSpars.IsInserted(oRentalSparsProperty.RentalSparsName))
              {
                  oRentalSparsProperty.NetPrice = CalculateNetPrice(oRentalSparsProperty.UnitPrice,oRentalSparsProperty.Discount);
                  RentalSparsID=oRentalSpars.InsertRentalSparsDL(oRentalSparsProperty);
              }
              else
              {
                  return RentalSparsID;
              }
          }
          catch (Exception ex)
          {
              throw ex;
          }
          return RentalSparsID;
      }

      public decimal CalculateNetPrice(decimal UnitPrice,int Discount)
      {
          decimal NetPrice;
          try
          {
              NetPrice =(UnitPrice - (UnitPrice * Discount) / 100);
          }
          catch (Exception ex)
          {
              throw ex;
          }
          return NetPrice;
 
      }

      public int UpdateRentalSparsBL(RentalSparsProperty oRentalSparsProperty)
      {
          int RentalSparsID = 0;
          try
          {
              if (!oRentalSpars.IsInserted(oRentalSparsProperty.RentalSparsName))
              {
                  oRentalSparsProperty.NetPrice = CalculateNetPrice(oRentalSparsProperty.UnitPrice, oRentalSparsProperty.Discount);
                 RentalSparsID= oRentalSpars.UpdateRentalSparsDL(oRentalSparsProperty);
              }
              else
              {
                  return RentalSparsID;
              }
          }
          catch (Exception ex)
          {
              throw ex;
          }
          return RentalSparsID;
      }
      public string DeleteRentalSparsBL(int RentalSparsId)
      {
          string result = "";
          try
          {
              oRentalSpars.DeleteRentalParseDL(RentalSparsId);
              result = "Success";
          }
          catch (Exception ex)
          {
              throw ex;
          }
          return result;
      }
    }
}
