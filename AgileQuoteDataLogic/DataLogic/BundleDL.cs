using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices.ComTypes;
using AgileQuoteAdminProperty.Property;
using AgileQuoteDataLogic.DataLogic;
using AgileQuoteDataLogic.Data;
using System.Data;
using AgileQuoteAdminProperty.Common;

namespace AgileQuoteDataLogic.DataLogic
{
    public class BundleDL
    {
        AgileQuoteDevelopmentEntitiesV Entities = new AgileQuoteDevelopmentEntitiesV();
        //tbBundle oBundle = new tbBundle();
        //tbMaterial oMaterial = new tbMaterial();
        //tbBundleMaterialMapping tbBundleMaterialMappings = new tbBundleMaterialMapping();
        //List<string> InsertMaterial = new List<string>();
        //List<string> UpdateMaterial = new List<string>();
        //List<string> DeleteMaterial = new List<string>();
        //MaterialBundleMappingDL oMaterialBundleMappingDL = new MaterialBundleMappingDL();


        /// <summary>
        /// GetBundleListBasedOnCategory method returns collection of bundle property based on category name
        /// </summary>
        /// <param name="CategoryName">Category name string nullable</param>
        /// <returns>List of bundleproperty</returns>
        public List<BundleProperty> GetBundleListBasedOnCategory(string CategoryName)
        {
            List<BundleProperty> oBundleList = new List<BundleProperty>();
            BundleProperty oBundle = null;
            int Sno = 1;
            try
            {
                var oBundleCategoryBase = Entities.spBundleCategoryBaseSelect(CategoryName).ToList();
                if (oBundleCategoryBase != null)
                {
                    foreach (var item in oBundleCategoryBase)
                    {
                        oBundle = new BundleProperty();
                        oBundle.BundleDescription = item.BundleDescription;
                        oBundle.BundleDiscount = item.Discount.Value;
                        oBundle.BundleId = item.BundleID;
                        oBundle.BundleName = item.BundleName;
                        oBundle.BundleNetPrice = Extension.MathRound(item.NetPrice.Value);
                        oBundle.BundleUnitPrice = Extension.MathRound(item.UnitPrice.Value);
                        if (item.Warrenty != null)
                        {
                            oBundle.BundleWarrenty = Extension.MonthConverter(item.Warrenty.Value);
                        }
                        oBundle.BundleInstallation = Entities.tbBundles.Where(x => x.BundleID == item.BundleID && x.IsActive == true && x.IsDelete == false).Select(x => x.Installation).FirstOrDefault().Value;
                        oBundle.sno = Sno;
                        oBundle.Quantity = ConstantValues.DefaultQuntity;
                        oBundleList.Add(oBundle);
                        Sno++;
                    }
                }
                return oBundleList;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Get category name list
        /// </summary>
        /// <returns>Collection of string</returns>
        public List<string> GetCategoryNameList()
        {
            List<string> oCategoryName = new List<string>();
            try
            {
                var ooCategoryName = Entities.tbCategories.Where(x => x.IsActive == true && x.IsDelete == false).ToList();
                if (ooCategoryName != null)
                {
                    foreach (var item in ooCategoryName)
                    {
                        oCategoryName.Add(item.CategoryName);
                    }
                }
                return oCategoryName;
            }
            catch
            {
                throw;
            }
        }

        public List<MaterialProperty> GetBundleMappingMaterial(int BundleID)
        {
            try
            {
                List<MaterialProperty> oMaterialList = new List<MaterialProperty>();
                MaterialProperty oMaterial = null;
                var oMaterialObject = (from o in Entities.tbMaterials
                                       join oo in Entities.tbBundleMaterialMappings
                                       on
                                       o.MaterialID equals oo.MaterialID
                                       join ooo in Entities.tbBundles
                                       on oo.BundleID equals ooo.BundleID
                                       where ooo.BundleID == BundleID && ooo.IsActive == true && ooo.IsDelete == false
                                       && oo.IsActive == true && oo.IsDelete == false && o.IsActive == true && o.IsDelete == false
                                       select new { o.MaterialID, o.MaterialName, o.MaterialCode, o.MaterialDescription, o.Discount, o.Amount, oo.Quantity }).ToList();
                if (oMaterialObject.Count > 0)
                {
                    foreach (var item in oMaterialObject)
                    {
                        oMaterial = new MaterialProperty();
                        oMaterial.MaterialID = item.MaterialID;
                        oMaterial.MaterialCode = item.MaterialCode;
                        oMaterial.MaterialName = item.MaterialName;
                        oMaterial.MaterialDescription = item.MaterialDescription;
                        oMaterial.MaterialDiscount = item.Discount.Value;
                        oMaterial.MaterialAmount = Extension.MathRound(item.Amount);
                        oMaterial.Quantity = item.Quantity;
                        oMaterialList.Add(oMaterial);
                    }
                }
                return oMaterialList;
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// Get material list based on category method returns collection of material based on category name
        /// </summary>
        /// <param name="CategoryName">Category name string</param>
        /// <returns>List of material property</returns>
        public List<MaterialProperty> GetMaterialListBasedOnCategory(string CategoryName)
        {
            List<MaterialProperty> oMaterialList = new List<MaterialProperty>();
            MaterialProperty oMaterial = null;
            try
            {
                var oMaterialCategoryBase = Entities.spMaterialCategoryBaseSelect(CategoryName).ToList();
                if (oMaterialCategoryBase != null)
                {
                    foreach (var item in oMaterialCategoryBase)
                    {
                        oMaterial = new MaterialProperty();
                        oMaterial.MaterialAmount = Extension.MathRound(item.Amount);
                        oMaterial.MaterialCode = item.MaterialCode;
                        oMaterial.MaterialDescription = item.MaterialDescription;
                        oMaterial.MaterialDiscount = item.Discount.Value;
                        oMaterial.MaterialID = item.MaterialID;
                        oMaterial.MaterialName = item.MaterialName;
                        oMaterial.Quantity = ConstantValues.DefaultQuntity;
                        oMaterialList.Add(oMaterial);
                    }
                }
                return oMaterialList;
            }
            catch
            {
                throw;
            }
        }

        public BundleProperty GetBundleSingleRecord(int BundleID)
        {
            try
            {
                BundleProperty oBundle = new BundleProperty();
                var obj = Entities.spBundleCategoryBaseSelect(null).Where(x => x.BundleID == BundleID).FirstOrDefault();
                if (obj != null)
                {
                    oBundle.BundleDescription = obj.BundleDescription;
                    oBundle.BundleDiscount = obj.Discount.Value;
                    oBundle.BundleId = obj.BundleID;
                    oBundle.BundleType = Entities.tbBundles.Where(x => x.BundleID == BundleID && x.IsActive == true && x.IsDelete == false).Select(x => x.BundleCategory).FirstOrDefault();
                    oBundle.BundleName = obj.BundleName;
                    oBundle.BundleUnitPrice = Extension.MathRound(obj.UnitPrice.Value);
                    oBundle.BundleNetPrice = Extension.MathRound(obj.NetPrice.Value);
                    oBundle.BundleWarrenty = Extension.MonthConverter(obj.Warrenty.Value);
                }
                return oBundle;
            }
            catch
            {
                throw;
            }
        }

        public string UpdateBundle(Dictionary<int, int> MaterialIDQuantityList, string BundleName, string BundleDescription, int Warrenty, int BundleID)
        {
            List<int> MaterialIDList = new List<int>();
            List<int> oMaterialIDList = new List<int>();
            List<int> qMaterialIDList = new List<int>();
            bool oBundleExist = false;
            try
            {
                MaterialIDList = MaterialIDQuantityList.Select(x => x.Key).ToList();

                var oNameExist = Entities.tbBundles.Any(x => x.BundleName == BundleName && x.IsActive == true && x.IsDelete == false && x.BundleID != BundleID);
                if (oNameExist)
                {
                    return "Bundle name already exist.";
                }

                List<int> oBundleIDList = Entities.tbBundles.Where(x => x.IsDelete == false && x.IsActive == true && x.BundleID != BundleID).Select(x => x.BundleID).ToList();
                if (oBundleIDList != null)
                {
                    foreach (var item in oBundleIDList)
                    {
                        oMaterialIDList = (from o in Entities.tbBundleMaterialMappings.Where(x => x.BundleID == item && x.IsActive == true && x.IsDelete == false) select new { id = o.MaterialID }).Select(x => x.id).ToList();
                        if (oMaterialIDList.Count < MaterialIDList.Count)
                        {
                            qMaterialIDList = MaterialIDList.Except(oMaterialIDList).ToList();
                        }
                        else
                        {
                            qMaterialIDList = oMaterialIDList.Except(MaterialIDList).ToList();
                        }

                        if (qMaterialIDList.Count == 0)
                        {
                            oBundleExist = true;
                            string oBundleName = (from o in Entities.tbBundles.Where(x => x.BundleID == item) select new { name = o.BundleName }).Select(x => x.name).FirstOrDefault();
                            return "Bundle Already exist. Bundle name is " + oBundleName;
                        }
                    }
                }

                if (oBundleExist == false)
                {
                    return UpdateMaterialMappingToBundle(MaterialIDQuantityList, BundleName, BundleDescription, Warrenty, BundleID);
                }
                return ConstantValues.SuccessMessage;
            }
            catch
            {
                throw;
            }
        }

        public string InsertMaterialMappingToBundle(Dictionary<int, int> MaterialIDQuantityList, string BundleName, int UserID, string BundleDescription, int Warrenty)
        {
            try
            {
                List<int> MaterialIDList = new List<int>();
                List<int> oMaterialIDList = new List<int>();
                List<int> qMaterialIDList = new List<int>();
                bool oBundleExist = false;

                MaterialIDList = MaterialIDQuantityList.Select(x => x.Key).ToList();

                var oNameExist = Entities.tbBundles.Any(x => x.BundleName == BundleName && x.IsActive == true && x.IsDelete == false);
                if (oNameExist)
                {
                    return "Bundle name already exist.";
                }

                List<int> oBundleIDList = Entities.tbBundles.Where(x => x.IsDelete == false && x.IsActive == true).Select(x => x.BundleID).ToList();
                if (oBundleIDList != null)
                {
                    foreach (var item in oBundleIDList)
                    {
                        oMaterialIDList = (from o in Entities.tbBundleMaterialMappings.Where(x => x.BundleID == item && x.IsActive == true && x.IsDelete == false) select new { id = o.MaterialID }).Select(x => x.id).ToList();
                        if (oMaterialIDList.Count < MaterialIDList.Count)
                        {
                            qMaterialIDList = MaterialIDList.Except(oMaterialIDList).ToList();
                        }
                        else
                        {
                            qMaterialIDList = oMaterialIDList.Except(MaterialIDList).ToList();
                        }

                        if (qMaterialIDList.Count == 0)
                        {
                            oBundleExist = true;
                            string oBundleName = (from o in Entities.tbBundles.Where(x => x.BundleID == item) select new { name = o.BundleName }).Select(x => x.name).FirstOrDefault();
                            return "Bundle Already exist. Bundle name is " + oBundleName;
                        }
                    }
                }

                if (oBundleExist == false)
                {
                    return MaterialMappingToBundle(MaterialIDQuantityList, BundleName, UserID, BundleDescription, Warrenty);
                }
                return ConstantValues.SuccessMessage;
            }
            catch
            {
                throw;
            }
        }

        public string UpdateMaterialMappingToBundle(Dictionary<int, int> MaterialIDList, string BundleName, string BundleDescription, int Warrenty, int BundleID)
        {
            decimal discount = 0;
            decimal unitprice = 0;
            decimal netprice = 0;
            decimal installation = 0;
            try
            {
                if (MaterialIDList.Count > 0)
                {
                    foreach (var item in MaterialIDList)
                    {
                        var oMaterial = Entities.tbMaterials.Where(x => x.MaterialID == item.Key && x.IsActive == true && x.IsDelete == false).FirstOrDefault();
                        if (oMaterial != null)
                        {
                            decimal tempNetPrice = 0;
                            tempNetPrice = oMaterial.Amount - (oMaterial.Amount * Convert.ToDecimal((double)oMaterial.Discount.Value / (double)100));
                            unitprice = unitprice + oMaterial.Amount;
                            netprice = netprice + (tempNetPrice * item.Value);
                            installation = installation + oMaterial.Installation.Value;
                        }
                    }

                    discount = (1 - Convert.ToDecimal((double)netprice / (double)unitprice)) * 100;

                    var oBundleObject = Entities.tbBundles.Where(x => x.BundleID == BundleID && x.IsActive == true && x.IsDelete == false).FirstOrDefault();
                    if (oBundleObject != null)
                    {
                        oBundleObject.UnitPrice = unitprice;
                        oBundleObject.NetPrice = netprice;
                        oBundleObject.Installation = installation;
                        oBundleObject.Discount = Convert.ToInt32(Math.Floor(discount));
                        oBundleObject.BundleName = BundleName;
                        oBundleObject.BundleDescription = BundleDescription;
                        oBundleObject.Warrenty = Extension.YearConverter(Warrenty);
                    }

                    foreach (var item in MaterialIDList)
                    {
                        var oMaterialMapping = Entities.tbBundleMaterialMappings.Where(x => x.BundleID == BundleID && x.MaterialID == item.Key && x.IsActive == true && x.IsDelete == false).FirstOrDefault();
                        if (oMaterialMapping != null)
                        {
                            oMaterialMapping.Quantity = item.Value;
                        }
                        else
                        {
                            tbBundleMaterialMapping oBundleMaterialMapping = new tbBundleMaterialMapping();
                            oBundleMaterialMapping.BundleID = BundleID;
                            oBundleMaterialMapping.IsActive = true;
                            oBundleMaterialMapping.IsDelete = false;
                            oBundleMaterialMapping.MaterialID = item.Key;
                            oBundleMaterialMapping.Quantity = item.Value;
                            Entities.tbBundleMaterialMappings.AddObject(oBundleMaterialMapping);
                        }
                    }
                }
                Entities.SaveChanges();
                return ConstantValues.SuccessMessage;
            }
            catch
            {
                throw;
            }
        }

        public string MaterialMappingToBundle(Dictionary<int, int> MaterialIDList, string BundleName, int UserID, string BundleDescription, int Warrenty)
        {
            try
            {
                if (MaterialIDList.Count > 0)
                {
                    decimal discount = 0;
                    decimal unitprice = 0;
                    decimal netprice = 0;
                    decimal installation = 0;

                    int MaterialId = MaterialIDList.Select(x => x.Key).FirstOrDefault();
                    string CategoryName = (from o in Entities.tbMaterials where o.MaterialID == MaterialId select new { category = o.CategoryName }).Select(x => x.category).FirstOrDefault();

                    foreach (var item in MaterialIDList)
                    {
                        var oMaterial = Entities.tbMaterials.Where(x => x.MaterialID == item.Key && x.IsActive == true && x.IsDelete == false).FirstOrDefault();
                        if (oMaterial != null)
                        {
                            decimal tempNetPrice = 0;
                            //discount = discount + oMaterial.Discount.Value;
                            tempNetPrice = oMaterial.Amount - (oMaterial.Amount * Convert.ToDecimal((double)oMaterial.Discount.Value / (double)100));
                            unitprice = unitprice + (oMaterial.Amount * item.Value);
                            netprice = netprice + (tempNetPrice * item.Value);
                            installation = installation + oMaterial.Installation.Value;
                        }
                    }

                    //netprice = unitprice - (unitprice * (discount / 100));

                    discount = (1 - Convert.ToDecimal((double)netprice / (double)unitprice)) * 100;
                    tbBundle oBundle = new tbBundle();
                    oBundle.BundleCategory = CategoryName;
                    oBundle.BundleName = BundleName;
                    oBundle.BundleDescription = BundleDescription;
                    oBundle.BundleType = "ClientConfigured";
                    oBundle.CreatedBy = UserID;
                    oBundle.Discount = Convert.ToInt32(Math.Floor(discount));
                    oBundle.UnitPrice = unitprice;
                    oBundle.NetPrice = netprice;
                    oBundle.Installation = installation;
                    oBundle.IsActive = true;
                    oBundle.IsDelete = false;
                    oBundle.Warrenty = Extension.YearConverter(Warrenty);
                    Entities.tbBundles.AddObject(oBundle);
                    Entities.SaveChanges();

                    foreach (var item in MaterialIDList)
                    {
                        tbBundleMaterialMapping oBundleMaterialMapping = new tbBundleMaterialMapping();
                        oBundleMaterialMapping.BundleID = oBundle.BundleID;
                        oBundleMaterialMapping.IsActive = true;
                        oBundleMaterialMapping.IsDelete = false;
                        oBundleMaterialMapping.MaterialID = item.Key;
                        oBundleMaterialMapping.Quantity = item.Value;
                        Entities.tbBundleMaterialMappings.AddObject(oBundleMaterialMapping);
                    }
                    Entities.SaveChanges();
                }
                return ConstantValues.SuccessMessage;
            }
            catch
            {
                throw;
            }
        }

        public string DeleteBundleRecord(int BundleId)
        {
            try
            {
                var oBundleMaterialMapping = (from o in Entities.tbBundleMaterialMappings
                                              where o.BundleID == BundleId && o.IsActive == true && o.IsDelete == false
                                              select o).ToList();
                if (oBundleMaterialMapping.Count > 0)
                {
                    foreach (var item in oBundleMaterialMapping)
                    {
                        item.IsActive = false;
                        item.IsDelete = true;
                    }
                }

                var oBundle = (from o in Entities.tbBundles
                               where o.BundleID == BundleId && o.IsActive == true && o.IsDelete == false
                               select o).FirstOrDefault();

                if (oBundle != null)
                {
                    oBundle.IsActive = false;
                    oBundle.IsDelete = true;
                }
                Entities.SaveChanges();

                return "success";
            }
            catch
            {
                throw;
            }
        }

        ///// <summary>
        ///// Select client configured bundle collection based on quoteID
        ///// </summary>
        ///// <param name="QuoteID">integer quoteid</param>
        ///// <param name="Request">string request configure</param>
        ///// <returns>collection</returns>
        //public List<QuoteBundleMaterial> GetQuoteBasedClientConfigureBundle(int QuoteID, string Request)
        //{
        //    try
        //    {
        //        List<QuoteBundleMaterial> oQuoteBundleMaterialList = new List<QuoteBundleMaterial>();
        //        QuoteBundleMaterial oQuoteBundleMaterial = null;
        //        decimal oBundgetTargetRate = GetBudgetTargetRate(QuoteID);
        //        int Sno = 1;
        //        int UserID = 0;
        //        var qQuote = aQuoteEntities.tbQuotes.Where(x => x.QuoteID == QuoteID).FirstOrDefault();
        //        if (qQuote != null)
        //        {
        //            UserID = qQuote.CreatedBy;
        //        }
        //        var oBundle = (from o in aQuoteEntities.tbQuoteBundleMappings
        //                       join oo in aQuoteEntities.tbBundles
        //                       on o.BundleID equals oo.BundleID
        //                       where o.QuoteID == QuoteID && oo.CreatedBy == UserID
        //                       && o.IsActive == true && o.IsDelete == false && oo.IsActive == true && oo.IsDelete == false
        //                       select new
        //                       {
        //                           o.BundleID,
        //                           o.Quantity,
        //                           oo.BundleDescription,
        //                           oo.Discount,
        //                           oo.BundleName,
        //                           oo.UnitPrice,
        //                           o.NetPrice,
        //                           oo.Warrenty
        //                       }).ToList();
        //        if (oBundle != null)
        //        {
        //            foreach (var item in oBundle)
        //            {
        //                oQuoteBundleMaterial = new QuoteBundleMaterial();
        //                oQuoteBundleMaterial.Quantity = item.Quantity.Value;
        //                oQuoteBundleMaterial.Code = item.BundleID;
        //                oQuoteBundleMaterial.Description = item.BundleDescription;
        //                oQuoteBundleMaterial.Discount = item.Discount.Value;
        //                oQuoteBundleMaterial.Name = item.BundleName;
        //                oQuoteBundleMaterial.Sno = Sno;
        //                oQuoteBundleMaterial.NetPrice = oBundgetTargetRate == null ? item.NetPrice.Value : (item.NetPrice.Value / oBundgetTargetRate);
        //                oQuoteBundleMaterial.UnitPrice = oBundgetTargetRate == null ? item.UnitPrice.Value : (item.UnitPrice.Value / oBundgetTargetRate);
        //                oQuoteBundleMaterial.GrossPrice = oBundgetTargetRate == null ? (item.UnitPrice.Value * item.Quantity.Value) : ((item.UnitPrice.Value * item.Quantity.Value) / oBundgetTargetRate);
        //                oQuoteBundleMaterialList.Add(oQuoteBundleMaterial);
        //                Sno++;
        //            }


        //        }
        //        return oQuoteBundleMaterialList;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //public QuoteBundleMaterialList GetConfigureBundleSingleRecord(int BundleId, int QuoteID)
        //{
        //    string Type = "Bundle";
        //    try
        //    {
        //        QuoteBundleMaterialList objQuoteBundleMaterialList = new QuoteBundleMaterialList();
        //        QuoteBundleMaterial oQuoteBundleMaterial = GetQuoteBasedMaterialBundle(QuoteID, null, BundleId, Type);
        //        List<QuoteBundleMaterial> oQuoteBundleMaterialList = new List<QuoteBundleMaterial>();
        //        QuoteBundleMaterial ooQuoteBundleMaterial = null;
        //        decimal bTargetRate = GetBudgetTargetRate(QuoteID);
        //        var listObject = (from o in aQuoteEntities.tbQuoteBundleMappings
        //                          join oo in aQuoteEntities.tbBundleMaterialMappings
        //                          on
        //                          o.BundleID equals oo.BundleID
        //                          join ooo in aQuoteEntities.tbMaterials
        //                          on
        //                          oo.MaterialID equals ooo.MaterialID
        //                          where o.QuoteID == QuoteID && o.BundleID == BundleId && o.IsActive == true && o.IsDelete == false
        //                          && oo.IsActive == true && oo.IsDelete == false
        //                          select new { ooo.MaterialID, ooo.MaterialCode, ooo.MaterialName, ooo.MaterialDescription, ooo.Amount, ooo.Discount }).ToList();
        //        if (listObject.Count > 0)
        //        {
        //            foreach (var item in listObject)
        //            {
        //                ooQuoteBundleMaterial = new QuoteBundleMaterial();
        //                ooQuoteBundleMaterial.MaterialCode = item.MaterialCode;
        //                ooQuoteBundleMaterial.Description = item.MaterialDescription;
        //                ooQuoteBundleMaterial.Discount = item.Discount.Value;
        //                ooQuoteBundleMaterial.Name = item.MaterialName;
        //                ooQuoteBundleMaterial.UnitPrice = bTargetRate == null ? item.Amount : (item.Amount / bTargetRate);
        //                oQuoteBundleMaterialList.Add(ooQuoteBundleMaterial);
        //            }
        //        }

        //        objQuoteBundleMaterialList.ListQuoteBundleMaterial = oQuoteBundleMaterialList;
        //        objQuoteBundleMaterialList.qQuoteBundleMaterial = oQuoteBundleMaterial;
        //        return objQuoteBundleMaterialList;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}



        //public decimal GetBudgetTargetRate(int QuoteID)
        //{
        //    try
        //    {
        //        return aQuoteEntities.tbQuotes.Where(x => x.QuoteID == QuoteID).Select(x => x.BudgetRateTarget).FirstOrDefault().Value;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}




        //public MaterialProperty GetMaterialSingleRecord(int MaterialID, decimal? BudgetTargetRate)
        //{
        //    try
        //    {
        //        MaterialProperty mMaterialProperty = new MaterialProperty();
        //        var sqMaterialSelect = aQuoteEntities.MaterialSelect(MaterialID.ToString()).FirstOrDefault();
        //        if (sqMaterialSelect != null)
        //        {
        //            mMaterialProperty.MaterialAmount = BudgetTargetRate == null ? sqMaterialSelect.Amount : sqMaterialSelect.Amount / BudgetTargetRate.Value;
        //            mMaterialProperty.MaterialCode = sqMaterialSelect.MaterialCode;
        //            mMaterialProperty.MaterialDescription = sqMaterialSelect.MaterialDescription;
        //            mMaterialProperty.MaterialDiscount = sqMaterialSelect.Discount.Value;
        //            mMaterialProperty.MaterialId = sqMaterialSelect.MaterialID;
        //            mMaterialProperty.MaterialName = sqMaterialSelect.MaterialName;
        //        }
        //        return mMaterialProperty;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


    }
}
