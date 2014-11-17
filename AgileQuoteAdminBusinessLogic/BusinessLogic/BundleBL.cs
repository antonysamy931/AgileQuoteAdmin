using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices.ComTypes;
using AgileQuoteAdminProperty.Property;
using AgileQuoteDataLogic.DataLogic;
using AgileQuoteDataLogic.Data;

namespace AgileQuoteAdminBusinessLogic.BusinessLogic
{
    public class BundleBL
    {

        BundleDL oBundleDL = new BundleDL();
        //MaterialBundleMappingDL oMaterialBundleMapping = new MaterialBundleMappingDL();
        //BundleProperty oBp = new BundleProperty();
        //public List<string> MaterialList = new List<string>();

        public List<BundleProperty> GetBundleListBasedOnCategoryBL(string CategoryName)
        {
            try
            {
                return oBundleDL.GetBundleListBasedOnCategory(CategoryName);
            }
            catch
            {
                throw;
            }
        }

        public List<MaterialProperty> GetBundleMappingMaterialBL(int BundleID)
        {
            try
            {
                return oBundleDL.GetBundleMappingMaterial(BundleID);
            }
            catch
            {
                throw;
            }
        }

        public List<string> GetCategoryList()
        {
            try
            {
                return oBundleDL.GetCategoryNameList();
            }
            catch
            {
                throw;
            }
        }

        public List<MaterialProperty> MaterialListBasedOnCategoryName(string CategoryName)
        {
            try
            {
                return oBundleDL.GetMaterialListBasedOnCategory(CategoryName);
            }
            catch
            {
                throw;
            }
        }

        public BundleProperty GetBundleSingleRecordBL(int BundleID)
        {
            try
            {
                return oBundleDL.GetBundleSingleRecord(BundleID);
            }
            catch
            {
                throw;
            }
        }

        public string InsertMaterialMappingToBundleBL(Dictionary<int, int> MaterialIDQuantityList, string BundleName, int UserID, string BundleDescription, int Warrenty)
        {
            try
            {
                return oBundleDL.InsertMaterialMappingToBundle(MaterialIDQuantityList, BundleName, UserID, BundleDescription, Warrenty);
            }
            catch
            {
                throw;
            }
        }

        public string BundlematerialDelete(int BundleID)
        {
            try
            {
                return oBundleDL.DeleteBundleRecord(BundleID);
            }
            catch
            {
                throw;
            }
        }

        public string UpdateBundleBL(Dictionary<int, int> MaterialIDQuantityList, string BundleName, string BundleDescription, int Warrenty, int BundleID)
        {
            try
            {
                return oBundleDL.UpdateBundle(MaterialIDQuantityList, BundleName, BundleDescription, Warrenty, BundleID);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BundleName"></param>
        /// <param name="FromMaterialID"></param>
        /// <returns></returns>
        //  public string CreateBundle(string BundleName,string Catagory, List<string> FromMaterialID)
        //  {
        //      Dictionary<string, string> MaterialCategoryMap = new Dictionary<string, string>();
        //      BundleProperty oBundle = new BundleProperty();
        //      string status = null;
        //      try
        //      {
        //          if (!oBundleDL.IsInserterd(BundleName))
        //          {
        //                oBundle = CalculateNetprice(oBundle, FromMaterialID); 
        //                oBp.BundleName = BundleName;
        //                oBp.NetPrice = oBundle.NetPrice;
        //                oBp.Discount = oBundle.Discount;
        //                oBp.UnitPrice = oBundle.UnitPrice;
        //                oBp.BundleCatagory = Catagory;

        //               oBundleDL.CreateBundle(oBp, FromMaterialID);
        //              int BundleID = Convert.ToInt32(oBundleDL.SelectBundle(BundleName));

        //              foreach (string StringMaterialID in FromMaterialID)
        //              {
        //                  string CategoryName = oBundleDL.SelectMaterialCategory(Convert.ToInt32(StringMaterialID));
        //                  MaterialCategoryMap.Add(StringMaterialID, CategoryName);
        //              }
        //              var distinctList = MaterialCategoryMap.Values.Distinct().ToList();
        //              if (distinctList.Count == 1)
        //              {
        //                  foreach (string StringMaterialID in FromMaterialID)
        //                  {
        //                      try
        //                      {
        //                          int MaterialID = Convert.ToInt32(StringMaterialID);
        //                          oMaterialBundleMapping.CreateBundle(MaterialID, BundleID);
        //                      }
        //                      catch (Exception ex)
        //                      {
        //                          throw ex;
        //                      }
        //                  }
        //                  status = "success";
        //              }
        //              else
        //              {
        //                  status = "failed";
        //              }
        //          }
        //          else
        //          {
        //             return status = "failed";
        //          }

        //      }
        //      catch (Exception ex)
        //      {
        //          throw ex;
        //      }
        //      return status;
        //  }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="Amount"></param>
        ///// <param name="Discount"></param>
        ///// <returns></returns>
        //  public BundleProperty CalculateNetprice(BundleProperty OBundle, List<string> MaterialList)
        //  {
        //      decimal Amount = 0;
        //      int Discount = 0;
        //      foreach (string StringMaterialID in MaterialList)
        //      {
        //          oBp = oBundleDL.SelectMaterialValue(Convert.ToInt32(StringMaterialID));
        //          Amount += oBp.UnitPrice;
        //          Discount += oBp.Discount;
        //      }
        //      OBundle.UnitPrice = Amount;
        //      OBundle.Discount = Discount;
        //      OBundle.NetPrice=Amount - (Amount * Discount / 100);
        //      return OBundle;
        //  }

        //  public List<BundleProperty> GetBundleList(string id)
        //  {
        //        List<BundleProperty> BundleList=new List<BundleProperty>();
        //      try
        //      {
        //          BundleList = oBundleDL.GetBundleList(id);

        //      }
        //      catch (Exception ex)
        //      {
        //          throw ex;
        //      }

        //      return BundleList;
        //  }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="BundleName"></param>
        ///// <param name="FromMaterialID"></param>
        ///// <returns></returns>
        //  public string UpdateBundle(string BundleName, List<string> FromMaterialID)
        //  {
        //      Dictionary<string, string> MaterialCategoryMap = new Dictionary<string, string>();
        //      string status = null;
        //      try
        //      {

        //       //   oBundleDL.CreateBundle(BundleName);

        //          int BundleID = Convert.ToInt32(oBundleDL.SelectBundle(BundleName));
        //          foreach (string StringMaterialID in FromMaterialID)
        //          {
        //              string CategoryName = oBundleDL.SelectMaterialCategory(Convert.ToInt32(StringMaterialID));
        //              MaterialCategoryMap.Add(StringMaterialID, CategoryName);

        //          }
        //          var distinctList = MaterialCategoryMap.Values.Distinct().ToList();
        //          if (distinctList.Count == 1)
        //          {
        //              foreach (string StringMaterialID in FromMaterialID)
        //              {
        //                  try
        //                  {
        //                      int MaterialID = Convert.ToInt32(StringMaterialID);
        //                      oMaterialBundleMapping.CreateBundle(MaterialID, BundleID);                        
        //                   }
        //                catch (Exception ex)
        //                 {
        //                  throw ex;
        //                 }
        //              }
        //              status = "success";
        //          }
        //          else
        //          {
        //              status = "failed";
        //          }
        //      }
        //      catch (Exception ex)
        //      {
        //          throw ex;
        //      }
        //      return status;

        //  }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="oBundleProperty"></param>
        ///// <param name="MaterialIDList"></param>
        ///// <returns></returns>
        //  public string BundleEdit(BundleProperty oBundleProperty, string MaterialIDList)
        //  {

        //      var MaterialIDArr = MaterialIDList.Split(',');           
        //      BundleProperty oBundle = new BundleProperty();           
        //      foreach (var v in MaterialIDArr)
        //      {
        //          MaterialList.Add(v.ToString());
        //      }
        //      oBundle = CalculateNetprice(oBundleProperty, MaterialList);
        //      oBundleProperty.UnitPrice =oBundle.UnitPrice;
        //      oBundleProperty.Discount = oBundle.Discount;
        //      oBundleProperty.NetPrice = oBundle.NetPrice;
        //      string result = null;
        //      try
        //      {
        //          result=oBundleDL.BundleEdit(oBundleProperty, MaterialList);

        //      }
        //      catch (Exception ex)
        //      {
        //          throw ex;
        //      }
        //      return result;
        //  }

        //public List<QuoteBundleMaterial> QuoteBasedClientConfigureBundle(int QuoteID, string Request)
        //{
        //    try
        //    {
        //        return oBundleDL.GetQuoteBasedClientConfigureBundle(QuoteID, Request);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //public QuoteBundleMaterialList GetConfigureBundleSingleRecordBL(int BundleId, int QuoteID)
        //{
        //    try
        //    {
        //        return oBundleDL.GetConfigureBundleSingleRecord(BundleId, QuoteID);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}



        //public MaterialProperty MaterialSingleRecordGet(int MaterialID, decimal BudgetTargetRate)
        //{
        //    try
        //    {
        //        return oBundleDL.GetMaterialSingleRecord(MaterialID, BudgetTargetRate);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //public string BundleMaterialUpdate(int QuoteID, string Type, int? MaterialID, int? BundleID, int Quantity, decimal NetPrice)
        //{
        //    try
        //    {
        //        return oBundleDL.UpdateMaterialBundleRecord(QuoteID, BundleID, Quantity, NetPrice, false);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

    }
}
