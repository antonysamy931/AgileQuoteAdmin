using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileQuoteDataLogic.DataLogic;
using AgileQuoteAdminProperty.Property;
using LogWriter;

namespace AgileQuoteAdminBusinessLogic.BusinessLogic
{
    public class CurrencyBL
    {

        CurrencyDL oCurrencyDL = new CurrencyDL();

        /// <summary>
        /// It retrieves all records from table.
        /// </summary>
        /// <returns>It returns CurrencyListProperty Object.</returns>
        public List<CurrencyProperty> GetCurrencyListBL()
        {

            try
            {
                return oCurrencyDL.GetCurrencyListDL();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// To get a single record using CurrencyId.
        /// </summary>
        /// <param name="CurrencyId"></param>
        /// <returns>It returns CurrencyProperty Object.</returns>
        public CurrencyProperty GetSingleRecordBL(int CurrencyId)
        {
            try
            {
                return oCurrencyDL.GetSingleRecordDL(CurrencyId);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// To insert the records.
        /// </summary>
        /// <param name="cp"></param>
        /// <returns>Returns whether the insertion successfull or not.</returns>
        public string InsertCurrencyRecordBL(CurrencyProperty oCurrencyProperty)
        {
            try
            {
                if (!oCurrencyDL.IsInserted(oCurrencyProperty.CurrencyName, oCurrencyProperty.CurrencyCode))
                {
                    return oCurrencyDL.InsertCurrencyRecordDL(oCurrencyProperty);
                }
                else
                {
                    return "Duplication occured";
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
        /// <param name="cp"></param>
        /// <returns>Returns whether the updation successfull or not.</returns>
        public string UpdateCurrencyBL(CurrencyProperty oCurrencyProperty)
        {            
            try
            {
                if (!oCurrencyDL.IsUpdated(oCurrencyProperty))
                {
                    return oCurrencyDL.UpdateCurrencyDL(oCurrencyProperty);
                }
                else
                {
                    return "Duplication occured";
                }
            }
            catch
            {
                throw;
            }            
        }

        public string DeleteCurrencyBL(int CurrencyId)
        {            
            try
            {

                return oCurrencyDL.DeleteCurrencyDL(CurrencyId);                
            }
            catch
            {
                throw;
            }            
        }

    }
}
