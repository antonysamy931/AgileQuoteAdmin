using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileQuoteDataLogic.Data;
using AgileQuoteAdminProperty.Property;
using LogWriter;

namespace AgileQuoteDataLogic.DataLogic
{
    public class RentalProductsDL
    {
        AgileQuoteDevelopmentEntitiesV Entities = new AgileQuoteDevelopmentEntitiesV();
        public List<RentalProductsProperty> GetRentalProductsList()
        {
            List<RentalProductsProperty> RentalProductsList = new List<RentalProductsProperty>();
            RentalProductsProperty oRentalProductsProperty = null;
            try
            {
                // var oRentalProductsList = Entities.spRentalProductSelect(null, null).ToList();
                var oRentalProductsList = Entities.RentalProductSelect(null).ToList();
                foreach (var item in oRentalProductsList)
                {
                    oRentalProductsProperty = new RentalProductsProperty();
                    oRentalProductsProperty.RentalProductsName = item.RentalProductsName;
                    oRentalProductsProperty.RentalProductsID = item.RentalProductsID;
                    oRentalProductsProperty.Description = item.Description;
                    oRentalProductsProperty.Warrenty = item.Warrenty;
                    oRentalProductsProperty.UnitPrice = item.UnitPrice;
                    oRentalProductsProperty.Discount = item.Discount;
                    oRentalProductsProperty.NetPrice = item.NetPrice;
                    oRentalProductsProperty.IsActive = item.IsActive;
                    oRentalProductsProperty.IsDelete = item.IsDelete;
                    RentalProductsList.Add(oRentalProductsProperty);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RentalProductsList;
        }


        public RentalProductsProperty GetRentalProductsByID(int id)
        {
            RentalProductsProperty RentalProductsList = new RentalProductsProperty();
            try
            {
                var oRentalProductsList = Entities.RentalProductSelect(id).FirstOrDefault();
                if (oRentalProductsList != null)
                {
                    RentalProductsList.RentalProductsName = oRentalProductsList.RentalProductsName;
                    RentalProductsList.RentalProductsID = oRentalProductsList.RentalProductsID;
                    RentalProductsList.Description = oRentalProductsList.Description;
                    RentalProductsList.Warrenty = oRentalProductsList.Warrenty;
                    RentalProductsList.UnitPrice = oRentalProductsList.UnitPrice;
                    RentalProductsList.Discount = oRentalProductsList.Discount;
                    RentalProductsList.NetPrice = oRentalProductsList.NetPrice;
                    RentalProductsList.IsActive = oRentalProductsList.IsActive;
                    RentalProductsList.IsDelete = oRentalProductsList.IsDelete;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RentalProductsList;
        }

        public int InsertRentalProducts(RentalProductsProperty oRentalProductsParameter)
        {

            tbRentalProduct oRentalProducts = new tbRentalProduct();

            try
            {
                oRentalProducts.RentalProductsName = oRentalProductsParameter.RentalProductsName;
                oRentalProducts.Description = oRentalProductsParameter.Description;
                oRentalProducts.Warrenty = oRentalProductsParameter.Warrenty;
                oRentalProducts.UnitPrice = oRentalProductsParameter.UnitPrice;
                oRentalProducts.NetPrice = oRentalProductsParameter.NetPrice;
                oRentalProducts.Warrenty = oRentalProductsParameter.Warrenty;
                oRentalProducts.IsActive = true;
                oRentalProducts.IsDelete = false;
                oRentalProducts.Discount = oRentalProductsParameter.Discount;
                Entities.tbRentalProducts.AddObject(oRentalProducts);
                Entities.SaveChanges();
                return oRentalProducts.RentalProductsID;

            }
            catch
            {
                throw;

            }

        }

        public int UpdateRentalProducts(RentalProductsProperty oRentalProductsParameter)
        {
            try
            {
                var oRentalProducts = Entities.tbRentalProducts.Where(a => a.RentalProductsID == oRentalProductsParameter.RentalProductsID && a.IsDelete == false && a.IsActive == true).FirstOrDefault();
                if (oRentalProducts != null)
                {
                    oRentalProducts.RentalProductsName = oRentalProductsParameter.RentalProductsName;
                    oRentalProducts.Description = oRentalProductsParameter.Description;
                    oRentalProducts.Warrenty = oRentalProductsParameter.Warrenty;
                    oRentalProducts.UnitPrice = oRentalProductsParameter.UnitPrice;
                    oRentalProducts.NetPrice = oRentalProductsParameter.NetPrice;
                    oRentalProducts.Warrenty = oRentalProductsParameter.Warrenty;
                    oRentalProducts.IsActive = oRentalProductsParameter.IsActive;
                    oRentalProducts.IsDelete = oRentalProductsParameter.IsDelete;
                    oRentalProducts.Discount = oRentalProductsParameter.Discount;
                    Entities.SaveChanges();                    
                }
                return oRentalProductsParameter.RentalProductsID;
            }
            catch
            {
                throw;
            }
        }

        public void DeleteRentalProducts(int id)
        {
            var oRentalProducts = Entities.tbRentalProducts.Where(a => a.RentalProductsID == id && a.IsDelete == false && a.IsActive == true).FirstOrDefault();
            if (oRentalProducts != null)
            {

                try
                {
                    oRentalProducts.IsDelete = true;
                    Entities.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool IsInserterd(RentalProductsProperty oRentalProductsParameter)
        {
            bool status = false;
            try
            {
                status = Entities.tbRentalProducts.Where(a => a.RentalProductsName == oRentalProductsParameter.RentalProductsName).Any();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }


    }
}
