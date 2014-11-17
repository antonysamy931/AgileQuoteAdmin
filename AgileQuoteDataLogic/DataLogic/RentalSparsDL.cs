using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileQuoteAdminProperty.Property;
using AgileQuoteDataLogic.Data;
using LogWriter;

namespace AgileQuoteDataLogic.DataLogic
{
   public class RentalSparsDL
    {
       AgileQuoteDevelopmentEntitiesV Entities = new AgileQuoteDevelopmentEntitiesV();
        public List<RentalSparsProperty> RentalSparsListDL()
        {
            List<RentalSparsProperty> RentalSparsList = new List<RentalSparsProperty>();
            RentalSparsProperty oRentalSpars = null;
            try
            {
                var oRentalSparsList = Entities.RentalSparsSelect(null).ToList();
                foreach (var item in oRentalSparsList)
                {
                    oRentalSpars = new RentalSparsProperty();
                    oRentalSpars.RentalSparsId = item.RentalSparsID;
                    oRentalSpars.RentalSparsName = item.RentalSparsName;
                    oRentalSpars.Description = item.Description;
                    oRentalSpars.Warrenty =(decimal)item.Warrenty;
                    oRentalSpars.UnitPrice =(decimal) item.UnitPrice;
                    oRentalSpars.Discount =(int) item.Discount;
                    oRentalSpars.NetPrice = (decimal)item.NetPrice;
                    oRentalSpars.IsActive = true;
                    oRentalSpars.IsDelete = false;
                    RentalSparsList.Add(oRentalSpars);
                }            
             }
            catch (Exception ex)
            {
                throw ex;
            }
            return RentalSparsList;
        }
        public RentalSparsProperty SingleRentalSparsDL(int RentalSparsId)
        {
            RentalSparsProperty oRentalSpars = null;
            var oSingleRecord = Entities.RentalSparsSelect(RentalSparsId).FirstOrDefault();
            try
            {
                if (oSingleRecord != null)
                {
                    oRentalSpars = new RentalSparsProperty();
                    oRentalSpars.RentalSparsId = oSingleRecord.RentalSparsID;
                    oRentalSpars.RentalSparsName = oSingleRecord.RentalSparsName;
                    oRentalSpars.Description = oSingleRecord.Description;
                    oRentalSpars.Warrenty = (decimal)oSingleRecord.Warrenty;
                    oRentalSpars.UnitPrice = (decimal)oSingleRecord.UnitPrice;
                    oRentalSpars.Discount = (int)oSingleRecord.Discount;
                    oRentalSpars.NetPrice = (decimal)oSingleRecord.NetPrice;
                    oRentalSpars.IsActive = true;
                    oRentalSpars.IsDelete = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oRentalSpars;
        }
        public int InsertRentalSparsDL(RentalSparsProperty oRentalSparsProperty)
        {
            tbRentalSpar oRentalSpars = new tbRentalSpar();
            try
            {
                oRentalSpars.RentalSparsName = oRentalSparsProperty.RentalSparsName;
                oRentalSpars.Description = oRentalSparsProperty.Description;
                oRentalSpars.Warrenty = oRentalSparsProperty.Warrenty;
                oRentalSpars.UnitPrice = oRentalSparsProperty.UnitPrice;
                oRentalSpars.Discount = oRentalSparsProperty.Discount;
                oRentalSpars.NetPrice = oRentalSparsProperty.NetPrice;
                oRentalSpars.IsActive = true;
                oRentalSpars.IsDelete = false;
                Entities.tbRentalSpars.AddObject(oRentalSpars);
                Entities.SaveChanges();
                return oRentalSpars.RentalSparsID;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
        public bool IsInserted(string RentalSparsName)
        {
            bool oName = false;
            try
            {
                oName = Entities.tbRentalSpars.Where(x => x.RentalSparsName == RentalSparsName).Any();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oName;
        }
        public int UpdateRentalSparsDL(RentalSparsProperty oRentalSparsProperty)
        {
            int RentalSpareID = 0;
            try
            {
                var oUpdateRental = Entities.tbRentalSpars.Where(x => x.RentalSparsID == oRentalSparsProperty.RentalSparsId && x.IsDelete == false && x.IsActive == true).FirstOrDefault();
                if (oUpdateRental != null)
                {
                    oUpdateRental.RentalSparsName = oRentalSparsProperty.RentalSparsName;
                    oUpdateRental.Description = oRentalSparsProperty.Description;
                    oUpdateRental.Warrenty = oRentalSparsProperty.Warrenty;
                    oUpdateRental.UnitPrice = oRentalSparsProperty.UnitPrice;
                    oUpdateRental.Discount = oRentalSparsProperty.Discount;
                    oUpdateRental.NetPrice = oRentalSparsProperty.NetPrice;
                    oUpdateRental.IsActive = true;
                    oUpdateRental.IsDelete = false;
                    Entities.SaveChanges();
                    RentalSpareID = oUpdateRental.RentalSparsID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RentalSpareID;
        }
        public void DeleteRentalParseDL(int RentalSparsId)
        {
            try
            {
                var oDeleteRental = Entities.tbRentalSpars.Where(x => x.RentalSparsID == RentalSparsId && x.IsDelete == false && x.IsActive == true).FirstOrDefault();
                if (oDeleteRental != null)
                {
                    oDeleteRental.IsDelete = true;
                    Entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
