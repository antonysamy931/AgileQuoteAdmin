using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileQuoteDataLogic.Data;
using AgileQuoteAdminProperty.Property;
using AgileQuoteAdminProperty.Common;
using LogWriter;

namespace AgileQuoteDataLogic.DataLogic
{
    public class CurrencyDL
    {
        AgileQuoteDevelopmentEntitiesV Entities = new AgileQuoteDevelopmentEntitiesV();

        /// <summary>
        /// It retrieves all the records from the Currency table.
        /// </summary>
        /// <returns>Returns the list of currencyproperty.</returns>
        public List<CurrencyProperty> GetCurrencyListDL()
        {
            List<CurrencyProperty> currencyList = new List<CurrencyProperty>();
            CurrencyProperty oCurrencyProperty = null;
            try
            {
                var oCurrencyList = Entities.CurrencySelect(null).ToList();
                foreach (var item in oCurrencyList)
                {
                    oCurrencyProperty = new CurrencyProperty();
                    oCurrencyProperty.CurrencyId = item.CurrencyId;
                    oCurrencyProperty.CurrencyCode = item.CurrencyCode;
                    oCurrencyProperty.CurrencyName = item.CurrencyName;
                    oCurrencyProperty.Amount =Extension.MathRound(item.Amount.Value);
                    currencyList.Add(oCurrencyProperty);
                }
                return currencyList;
            }
            catch
            {
                throw;
            }            
        }

        /// <summary>
        /// To get a single record from the table.
        /// </summary>
        /// <param name="CurrencyId"></param>
        /// <returns>It returns CurrencyProperty Object.</returns>
        public CurrencyProperty GetSingleRecordDL(int CurrencyId)
        {
            CurrencyProperty oCurrencyRecord = new CurrencyProperty();
            try
            {
                var oSingleRecord = Entities.CurrencySelect(CurrencyId.ToString()).FirstOrDefault();
                if (oSingleRecord != null)
                {                    
                    oCurrencyRecord.CurrencyId = oSingleRecord.CurrencyId;
                    oCurrencyRecord.CurrencyCode = oSingleRecord.CurrencyCode;
                    oCurrencyRecord.CurrencyName = oSingleRecord.CurrencyName;
                    oCurrencyRecord.Amount = oSingleRecord.Amount.Value;
                    oCurrencyRecord.IsActive = oSingleRecord.IsActive.Value;
                    oCurrencyRecord.IsDelete = oSingleRecord.IsDelete.Value;
                }
                return oCurrencyRecord;
            }
            catch
            {
                throw;
            }
            
        }

        /// <summary>
        /// To insert the values to the table.
        /// </summary>
        /// <param name="cp"></param>
        public string InsertCurrencyRecordDL(CurrencyProperty oCurrencyProperty)
        {
            tbCurrency oCurrency = new tbCurrency();

            try
            {

                oCurrency.CurrencyId = oCurrencyProperty.CurrencyId;
                oCurrency.CurrencyCode = oCurrencyProperty.CurrencyCode;
                oCurrency.CurrencyName = oCurrencyProperty.CurrencyName;
                oCurrency.Amount = oCurrencyProperty.Amount;
                oCurrency.IsActive = true;
                oCurrency.IsDelete = false;
                Entities.tbCurrencies.AddObject(oCurrency);
                Entities.SaveChanges();
                return "Success";
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Validation, To avoid duplication records.
        /// </summary>
        /// <param name="CurrencyName"></param>
        /// <param name="CurrencyCode"></param>
        /// <returns></returns>
        public bool IsInserted(string CurrencyName, string CurrencyCode)
        {            
            try
            {
                return Entities.tbCurrencies.Where(x => x.CurrencyName == CurrencyName || x.CurrencyCode == CurrencyCode && x.IsActive == true && x.IsDelete == false).Any();
            }
            catch
            {
                throw;
            }           
        }

        public bool IsUpdated(CurrencyProperty oCurrencyProperty)
        {
            try
            {
                if (oCurrencyProperty.IsDelete)
                {
                    return false;
                }
                else
                {
                    return Entities.tbCurrencies.Where(x => x.CurrencyId != oCurrencyProperty.CurrencyId && (x.CurrencyCode == oCurrencyProperty.CurrencyCode || x.CurrencyName == oCurrencyProperty.CurrencyName) && x.IsActive == true && x.IsDelete == false).Any();
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// It updates the values in the table.
        /// </summary>
        /// <param name="cp"></param>
        public string UpdateCurrencyDL(CurrencyProperty oCurrencyProperty)
        {
            try
            {
                var oCurrency = Entities.tbCurrencies.Where(x => x.CurrencyId == oCurrencyProperty.CurrencyId && x.IsDelete == false && x.IsActive == true).FirstOrDefault();

                if (oCurrency != null)
                {
                    oCurrency.CurrencyCode = oCurrencyProperty.CurrencyCode;
                    oCurrency.CurrencyName = oCurrencyProperty.CurrencyName;
                    oCurrency.Amount = oCurrencyProperty.Amount;
                    oCurrency.IsActive = oCurrencyProperty.IsActive;
                    oCurrency.IsDelete = oCurrencyProperty.IsDelete;
                    Entities.SaveChanges();                    
                }
                return "Success";
            }
            catch
            {
                throw;
            }
        }

        public string DeleteCurrencyDL(int CurrencyId)
        {
            try
            {
                var oDeleteCurrency = Entities.tbCurrencies.Where(x => x.CurrencyId == CurrencyId && x.IsDelete == false && x.IsActive == true).FirstOrDefault();
                if (oDeleteCurrency != null)
                {
                    oDeleteCurrency.IsDelete = true;
                    oDeleteCurrency.IsActive = false;
                    Entities.SaveChanges();
                }
                return "Success";
            }
            catch
            {
                throw;
            }
        }

    }
}
