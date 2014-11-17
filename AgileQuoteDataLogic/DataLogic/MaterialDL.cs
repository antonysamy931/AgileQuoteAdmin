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
    public class MaterialDL
    {
        AgileQuoteDevelopmentEntitiesV Entities = new AgileQuoteDevelopmentEntitiesV();
        AgileQuoteAdminDevelopmentEntities AdminEntities = new AgileQuoteAdminDevelopmentEntities();

        /// <summary>
        /// gets list of materials from database
        /// </summary>
        /// <returns> material list</returns>
        public List<MaterialProperty> GetMaterialList()
        {
            List<MaterialProperty> MaterialList = new List<MaterialProperty>();
            MaterialProperty oMaterialProperty = null;
            try
            {
                var oMaterialList = Entities.MaterialSelect(null).ToList();
                foreach (var item in oMaterialList)
                {
                    oMaterialProperty = new MaterialProperty();
                    oMaterialProperty.MaterialCode = item.MaterialCode;
                    oMaterialProperty.MaterialName = item.MaterialName;
                    oMaterialProperty.MaterialID = item.MaterialID;
                    oMaterialProperty.MaterialAmount =Extension.MathRound(item.Amount);
                    oMaterialProperty.MaterialCategory = item.CategoryName;
                    oMaterialProperty.MaterialDiscount = item.Discount.Value;
                    if (item.Installation != null)
                    {
                        oMaterialProperty.InstallFee = Convert.ToInt32(Extension.MathRound(item.Installation.Value));
                    }
                    oMaterialProperty.MaterialDescription = item.MaterialDescription;
                    if (item.Warranty != null)
                    {
                        oMaterialProperty.Warrenty = Extension.MonthConverter(item.Warranty.Value);
                    }
                    oMaterialProperty.MaterialIsActive = item.IsActive;
                    oMaterialProperty.MaterialIsDelete = item.IsDelete;
                    MaterialList.Add(oMaterialProperty);
                }
                return MaterialList;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// gets material by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns> returns material properties</returns>
        public MaterialProperty GetMaterialByID(int oMaterialId)
        {
            MaterialProperty oMaterialProperty = new MaterialProperty();
            try
            {
                var oMaterialList = Entities.MaterialSelect(oMaterialId.ToString()).FirstOrDefault();
                if (oMaterialList != null)
                {
                    oMaterialProperty.MaterialCode = oMaterialList.MaterialCode;
                    oMaterialProperty.MaterialName = oMaterialList.MaterialName;
                    oMaterialProperty.MaterialDescription = oMaterialList.MaterialDescription;
                    oMaterialProperty.MaterialID = oMaterialList.MaterialID;
                    oMaterialProperty.MaterialCategory = oMaterialList.CategoryName;
                    oMaterialProperty.MaterialAmount = Extension.MathRound(oMaterialList.Amount);
                    oMaterialProperty.MaterialDiscount = oMaterialList.Discount.Value;
                    if (oMaterialList.Warranty != null)
                    {
                        oMaterialProperty.HiddenWarrenty = Extension.MonthConverter(oMaterialList.Warranty.Value).ToString();
                        oMaterialProperty.Warrenty = Extension.MonthConverter(oMaterialList.Warranty.Value);
                    }

                    if (oMaterialList.Installation != null)
                    {
                        oMaterialProperty.InstallFee = Convert.ToInt32(Extension.MathRound(oMaterialList.Installation.Value));
                    }
                    oMaterialProperty.MaterialIsActive = oMaterialList.IsActive;
                    oMaterialProperty.MaterialIsDelete = oMaterialList.IsDelete;
                }
                return oMaterialProperty;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Insert material to the Database from the user
        /// </summary>
        /// <param name="oMaterialParameter"></param>
        public int InsertMaterial(MaterialProperty oMaterialParameter)
        {
            tbMaterial oMaterial = new tbMaterial();
            try
            {
                if (!IsInserterd(oMaterialParameter))
                {
                    oMaterial.MaterialCode = oMaterialParameter.MaterialCode;
                    oMaterial.MaterialName = oMaterialParameter.MaterialName;
                    oMaterial.IsActive = true;
                    oMaterial.IsDelete = false;
                    oMaterial.Discount = oMaterialParameter.MaterialDiscount;
                    oMaterial.CategoryName = oMaterialParameter.MaterialCategory;
                    oMaterial.Amount = oMaterialParameter.MaterialAmount;
                    oMaterial.MaterialDescription = oMaterialParameter.MaterialDescription;
                    oMaterial.Installation = Extension.IntToDecimal(oMaterialParameter.InstallFee);
                    oMaterial.Warranty = Extension.YearConverter(oMaterialParameter.Warrenty);
                    Entities.tbMaterials.AddObject(oMaterial);
                    Entities.SaveChanges();
                    return oMaterial.MaterialID;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// updates existing Material Database from the user value
        /// </summary>
        /// <param name="oMaterialParameter"></param>
        public int UpdateMaterial(MaterialProperty oMaterialParameter)
        {
            try
            {
                if (!IsUpdated(oMaterialParameter))
                {
                    var oEntityVariable = Entities.tbMaterials.Where(x => (x.MaterialID == oMaterialParameter.MaterialID && x.IsDelete == false && x.IsActive == true)).FirstOrDefault();
                    if (oEntityVariable != null)
                    {
                        oEntityVariable.MaterialCode = oMaterialParameter.MaterialCode;
                        oEntityVariable.MaterialName = oMaterialParameter.MaterialName;
                        oEntityVariable.IsActive = oMaterialParameter.MaterialIsActive;
                        oEntityVariable.IsDelete = oMaterialParameter.MaterialIsDelete;
                        oEntityVariable.Discount = oMaterialParameter.MaterialDiscount;
                        oEntityVariable.Amount = oMaterialParameter.MaterialAmount;
                        oEntityVariable.CategoryName = oMaterialParameter.MaterialCategory;
                        oEntityVariable.Warranty = Extension.YearConverter(oMaterialParameter.Warrenty);
                        oEntityVariable.MaterialDescription = oMaterialParameter.MaterialDescription;
                        oEntityVariable.Installation = Extension.IntToDecimal(oMaterialParameter.InstallFee);
                        Entities.SaveChanges();
                    }
                    return oEntityVariable.MaterialID;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                throw;

            }
        }

        /// <summary>
        /// updates value of isdelete field in datasbase to true
        /// </summary>
        /// <param name="id"></param>
        public string DeleteMaterial(int oMaterialId)
        {

            tbMaterial oMaterial = new tbMaterial();
            try
            {
                var oEntityVariable = Entities.tbMaterials.Where(x => (x.MaterialID == oMaterialId && x.IsDelete == false && x.IsActive == true)).FirstOrDefault();
                if (oEntityVariable != null)
                {
                    oEntityVariable.IsDelete = true;
                    oEntityVariable.IsActive = false;
                    Entities.SaveChanges();
                }
                return "success";
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// checks if the given material name and id exists in databsae already or not,
        /// if it exists, function returns true
        /// else it returns false
        /// </summary>
        /// <param name="oMaterialParameter"></param>
        /// <returns>boolien value based comparing database record and user value</returns>
        public bool IsInserterd(MaterialProperty oMaterialParameter)
        {
            try
            {
                return Entities.tbMaterials.Where(m => (m.MaterialName == oMaterialParameter.MaterialName || m.MaterialCode == oMaterialParameter.MaterialCode) && m.IsActive == true && m.IsDelete == false).Any();
            }
            catch
            {
                throw;
            }
        }

        public bool IsUpdated(MaterialProperty oMaterialParameter)
        {
            try
            {
                return Entities.tbMaterials.Where(x => x.MaterialID != oMaterialParameter.MaterialID && (x.MaterialName == oMaterialParameter.MaterialName || x.MaterialCode == oMaterialParameter.MaterialCode) && x.IsActive == true && x.IsDelete == false).Any();
            }
            catch
            {
                throw;
            }
        }

        public List<ImageProperty> GetImageDL()
        {
            List<ImageProperty> oImageList = new List<ImageProperty>();

            ImageProperty oImage;
            try
            {
                var Object = AdminEntities.tbImageCategories.ToList();
                if (Object.Count > 0)
                {
                    foreach (var Item in Object)
                    {
                        oImage = new ImageProperty();
                        oImage.CategoryId = Item.ImageCategoryId;
                        oImage.Name = Item.Name;
                        oImage.ImageFormat = Item.ImageFormat;
                        oImage.Height = Item.Height;
                        oImage.Width = Item.Widht;
                        oImageList.Add(oImage);
                    }
                }
                return oImageList;
            }
            catch
            {
                throw;
            }
        }

        public List<CategoryProperty> CategoryList()
        {
            List<CategoryProperty> oList = new List<CategoryProperty>();
            CategoryProperty oProperty = null;
            try
            {
                var objList = Entities.tbCategories.ToList();
                if (objList.Count > 0)
                {
                    foreach (var item in objList)
                    {
                        oProperty = new CategoryProperty();
                        oProperty.CategoryId = item.CategoryID;
                        oProperty.CategoryName = item.CategoryName;
                        oList.Add(oProperty);
                    }
                }
                return oList;
            }
            catch
            {
                throw;
            }
        }

        public string SugectionMaterialMappingDL(List<int> oMaterialList, int MaterialId)
        {
            try
            {
                List<int> InsertList = new List<int>();
                var oSugectionList = Entities.SugectionMaterialMappings.Where(x => x.MaterialId == MaterialId && x.IsActive == true && x.IsDelete == false).ToList();
                if (oSugectionList.Count > 0)
                {
                    List<int> oSugMaterialList = oSugectionList.Select(x => x.MappringMaterialId.Value).ToList();
                    if (oSugMaterialList.Count < oMaterialList.Count)
                    {
                        InsertList = oMaterialList.Except(oSugMaterialList).ToList();
                    }
                    else
                    {
                        InsertList = oSugMaterialList.Except(oMaterialList).ToList();
                    }
                }
                else
                {
                    InsertList = oMaterialList;
                }
                return InsertSugectionMaterialDL(InsertList, MaterialId);
            }
            catch
            {
                throw;
            }
        }

        public string OfferedMaterialMapping(List<int> oMaterialList, int MaterialId)
        {
            try
            {
                List<int> InsertList = new List<int>();
                var oOfferedList = Entities.tbOfferedMaterialMappings.Where(x => x.MaterialId == MaterialId && x.IsActive == true && x.IsDelete == false).ToList();
                if (oOfferedList.Count > 0)
                {
                    List<int> oOfferedMaterialList = oOfferedList.Select(x => x.MappingMaterialId.Value).ToList();
                    if (oOfferedMaterialList.Count < oMaterialList.Count)
                    {
                        InsertList = oMaterialList.Except(oOfferedMaterialList).ToList();
                    }
                    else
                    {
                        InsertList = oOfferedMaterialList.Except(oMaterialList).ToList();
                    }
                }
                else
                {
                    InsertList = oMaterialList;
                }
                return InsertOfferedMaterial(InsertList, MaterialId);
            }
            catch
            {
                throw;
            }
        }

        public string InsertSugectionMaterialDL(List<int> oMaterialList, int MaterialId)
        {
            try
            {
                foreach (var item in oMaterialList)
                {
                    SugectionMaterialMapping oSug = new SugectionMaterialMapping();
                    oSug.MaterialId = MaterialId;
                    oSug.MappringMaterialId = item;
                    oSug.IsActive = true;
                    oSug.IsDelete = false;
                    Entities.SugectionMaterialMappings.AddObject(oSug);
                }
                Entities.SaveChanges();
                return "Success";
            }
            catch
            {
                throw;
            }
        }

        public string InsertOfferedMaterial(List<int> oMaterialList, int MaterialId)
        {
            try
            {
                foreach (var item in oMaterialList)
                {
                    tbOfferedMaterialMapping objOffer = new tbOfferedMaterialMapping
                    {
                        MaterialId = MaterialId,
                        MappingMaterialId = item,
                        IsActive = true,
                        IsDelete = false
                    };
                    Entities.tbOfferedMaterialMappings.AddObject(objOffer);
                }
                Entities.SaveChanges();
                return "Success";
            }
            catch
            {
                throw;
            }
        }

        public List<MaterialProperty> GetMaterialMappingSugectionMaterial(int MaterialId)
        {
            try
            {
                //List<MaterialProperty> oList = new List<MaterialProperty>();
                List<int> objMappingMaterial = Entities.SugectionMaterialMappings.Where(x => x.MaterialId == MaterialId && x.IsActive == true && x.IsDelete == false).Select(x => x.MappringMaterialId.Value).ToList();
                //foreach (var item in objMappingMaterial)
                //{
                //    var objMaterial = Entities.tbMaterials.Where(x => x.MaterialID == item && x.IsActive == true && x.IsDelete == false).FirstOrDefault();
                //    if (objMaterial != null)
                //    {
                //        MaterialProperty oMaterialProp = new MaterialProperty();
                //        oMaterialProp.MaterialID = item.Value;
                //        oMaterialProp.MaterialName = objMaterial.MaterialName;
                //        oMaterialProp.MaterialCode = objMaterial.MaterialCode;
                //        oMaterialProp.MaterialDescription = objMaterial.MaterialDescription;
                //        oMaterialProp.MaterialAmount = Extension.RoundDecimal(objMaterial.Amount);
                //        oList.Add(oMaterialProp);
                //    }
                //}
                return CommonMaterialListGather(objMappingMaterial);
            }
            catch
            {
                throw;
            }
        }

        public List<MaterialProperty> GetMaterialMappingOfferedMaterial(int MaterialId)
        {
            try
            {
                //List<MaterialProperty> oList = new List<MaterialProperty>();
                List<int> objOfferedMaterial = Entities.tbOfferedMaterialMappings.Where(x => x.MaterialId == MaterialId && x.IsActive == true && x.IsDelete == false).Select(x => x.MappingMaterialId.Value).ToList();
                //if (objOfferedMaterial.Count > 0)
                //{
                //    foreach (var item in objOfferedMaterial)
                //    {
                //        var objMaterial = Entities.tbMaterials.Where(x => x.MaterialID == item && x.IsActive == true && x.IsDelete == false).FirstOrDefault();
                //        if (objMaterial != null)
                //        {
                //            MaterialProperty oMaterialProp = new MaterialProperty();
                //            oMaterialProp.MaterialID = item.Value;
                //            oMaterialProp.MaterialName = objMaterial.MaterialName;
                //            oMaterialProp.MaterialCode = objMaterial.MaterialCode;
                //            oMaterialProp.MaterialDescription = objMaterial.MaterialDescription;
                //            oMaterialProp.MaterialAmount = Extension.RoundDecimal(objMaterial.Amount);
                //            oList.Add(oMaterialProp);
                //        }
                //    }
                //}
                return CommonMaterialListGather(objOfferedMaterial);
            }
            catch
            {
                throw;
            }
        }

        public List<MaterialProperty> CommonMaterialListGather(List<int> MaterialList)
        {
            List<MaterialProperty> oList = new List<MaterialProperty>();
            try
            {
                if (MaterialList.Count > 0)
                {
                    foreach (var item in MaterialList)
                    {
                        var objMaterial = Entities.tbMaterials.Where(x => x.MaterialID == item && x.IsActive == true && x.IsDelete == false).FirstOrDefault();
                        if (objMaterial != null)
                        {
                            MaterialProperty oMaterialProp = new MaterialProperty();
                            oMaterialProp.MaterialID = item;
                            oMaterialProp.MaterialName = objMaterial.MaterialName;
                            oMaterialProp.MaterialCode = objMaterial.MaterialCode;
                            oMaterialProp.MaterialDescription = objMaterial.MaterialDescription;
                            oMaterialProp.MaterialAmount = Extension.RoundDecimal(objMaterial.Amount);
                            oList.Add(oMaterialProp);
                        }
                    }
                }
                return oList;
            }
            catch
            {
                throw;
            }
        }

        public string DeleteSugectionMaterial(int MaterialID, int MappingMaterial)
        {
            try
            {
                var objMappingMaterial = Entities.SugectionMaterialMappings.Where(x => x.MaterialId == MaterialID && x.MappringMaterialId == MappingMaterial && x.IsActive == true && x.IsDelete == false).FirstOrDefault();
                if (objMappingMaterial != null)
                {
                    objMappingMaterial.IsActive = false;
                    objMappingMaterial.IsDelete = true;
                }
                Entities.SaveChanges();
                return "Success";
            }
            catch
            {
                throw;
            }
        }

        public string DeleteOfferedMaterial(int MaterialID, int MappingMaterial)
        {
            var objMappingMaterial = Entities.tbOfferedMaterialMappings.Where(x => x.MaterialId == MaterialID && x.MappingMaterialId == MappingMaterial && x.IsActive == true && x.IsDelete == false).FirstOrDefault();
            if (objMappingMaterial != null)
            {
                objMappingMaterial.IsActive = false;
                objMappingMaterial.IsDelete = true;
            }
            Entities.SaveChanges();
            return "Success";
        }

    }
}