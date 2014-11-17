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
  public  class RentalProductsBL
    {
      RentalProductsDL oRentalProductsDL = new RentalProductsDL();       
        public List<RentalProductsProperty> GetRentalProductsListBL()
        {
            List<RentalProductsProperty> oRentalProductsListProperty = new List<RentalProductsProperty>();

            try
            {
                oRentalProductsListProperty = oRentalProductsDL.GetRentalProductsList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oRentalProductsListProperty;
        }
       
        public RentalProductsProperty GetRentalProductsByID(int id)
        {
            RentalProductsProperty oRentalProductsListByName = new RentalProductsProperty();
            try
            {
                oRentalProductsListByName = oRentalProductsDL.GetRentalProductsByID(id);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oRentalProductsListByName;
        }
        
        public int InsertRentalProducts(RentalProductsProperty oRentalProductsParameter)
        {
            int RentalProductId = 0; 
            try
            {

                if (!oRentalProductsDL.IsInserterd(oRentalProductsParameter))
                {
                    oRentalProductsParameter = CalculateNetprice(oRentalProductsParameter);
                    RentalProductId=oRentalProductsDL.InsertRentalProducts(oRentalProductsParameter);
                   
                }
                else
                {
                    RentalProductId = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RentalProductId;

        }

        
        public int UpdateRentalProducts(RentalProductsProperty oRentalProductsParameter)
        {
            int RentalProductId = 0;
            try
            {
                if (!oRentalProductsDL.IsInserterd(oRentalProductsParameter))
                {

                    oRentalProductsParameter = CalculateNetprice(oRentalProductsParameter);
                    RentalProductId=oRentalProductsDL.UpdateRentalProducts(oRentalProductsParameter);

                }
                else
                {
                    RentalProductId = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RentalProductId;

        }
        
        public string DeleteRentalProducts(int id)
        {
            string status = null;
            try
            {

                oRentalProductsDL.DeleteRentalProducts(id);
                status = "success";

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;

        }
        public RentalProductsProperty CalculateNetprice(RentalProductsProperty oRentalProducts)
        {
            oRentalProducts.NetPrice = oRentalProducts.UnitPrice - (oRentalProducts.UnitPrice * oRentalProducts.Discount / 100);
            return oRentalProducts;
        }


    }
}
