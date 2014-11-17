using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileQuoteDataLogic.DataLogic;
using AgileQuoteAdminProperty.Property;
using LogWriter;
using AgileQuoteDataLogic.Data;

namespace AgileQuoteDataLogic.DataLogic
{
    public class RoleDL
    {

        AgileQuoteAdminDevelopmentEntities Entities = new AgileQuoteAdminDevelopmentEntities();

        /// <summary>
        /// GetRoleListDL method is used to retrive all records from
        /// data base
        /// </summary>
        /// <returns>Returns List of RoleProperty Objects</returns>
        public List<RoleProperty> GetRoleListDL()
        {
            List<RoleProperty> RoleList = new List<RoleProperty>();
            RoleProperty oRoleProperty = null;
            try
            {
                var oRoleList = Entities.RoleSelect("").ToList();
                foreach (var item in oRoleList)
                {
                    oRoleProperty = new RoleProperty();
                    oRoleProperty.RoleId = item.RoleID;
                    oRoleProperty.RoleName = item.RoleName;
                    oRoleProperty.Priority = item.Priority;
                    oRoleProperty.IsVisible = true;
                    oRoleProperty.IsDelete = false;
                    RoleList.Add(oRoleProperty);
                }
                return RoleList;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// GetSingleRoleRecordBL method is used to retrive single record from the Data Base
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns>Returns the Record for a Given RoleId</returns>
        public RoleProperty GetSingleRoleRecordDL(int RoleId)
        {
            RoleProperty oRoleRecord = new RoleProperty();
            try
            {
                var oSingleRecord = Entities.RoleSelect(RoleId.ToString()).FirstOrDefault();
                if (oSingleRecord != null)
                {
                    oRoleRecord.RoleId = oSingleRecord.RoleID;
                    oRoleRecord.RoleName = oSingleRecord.RoleName;
                    oRoleRecord.Priority = oSingleRecord.Priority;
                    oRoleRecord.IsVisible = true;
                    oRoleRecord.IsDelete = false;
                }
                return oRoleRecord;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// InsertRoleRecord method is used to insert record into the data base
        /// </summary>
        /// <param name="rp"></param>        
        public string InsertRoleRecord(RoleProperty oRollProperty)
        {
            tbCustomerRole oRole = new tbCustomerRole();
            try
            {
                oRole.RoleName = oRollProperty.RoleName;
                oRole.Priority = oRollProperty.Priority;
                oRole.IsActive = true;
                oRole.IsDelete = false;
                Entities.tbCustomerRoles.AddObject(oRole);
                Entities.SaveChanges();
                return "Success";
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// UpdateRoleDL method is used to update record into the data base
        /// </summary>
        /// <param name="rp"></param>
        public string UpdateRoleDL(RoleProperty oRollProperty)
        {
            try
            {
                var oUpdate = Entities.tbCustomerRoles.Where(x => x.RoleID == oRollProperty.RoleId && x.IsDelete == false && x.IsActive == true).FirstOrDefault();
                if (oUpdate != null)
                {
                    oUpdate.RoleName = oRollProperty.RoleName;
                    oUpdate.Priority = oRollProperty.Priority;
                    oUpdate.IsActive = oRollProperty.IsVisible;
                    oUpdate.IsDelete = oRollProperty.IsDelete;
                    Entities.SaveChanges();                    
                }
                return "Success";
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// DeleteRoleDL method is used to delete record
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns>Returns record for given RoleID</returns>
        public string DeleteRoleDL(int RoleID)
        {
            try
            {
                var oDelete = Entities.tbCustomerRoles.Where(x => x.RoleID == RoleID && x.IsDelete == false && x.IsActive == true).FirstOrDefault();
                if (oDelete != null)
                {
                    oDelete.IsDelete = true;
                    oDelete.IsActive = false;
                    Entities.SaveChanges();                    
                }
                return "Success";
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// While inserting and updating, IsInserted method is used to check whether the record already exist or not
        /// </summary>
        /// <param name="RoleName"></param>
        /// <param name="RoleId"></param>
        /// <returns>Returns the Boolean value whether to Insert,Update or not</returns>
        public bool IsInserted(string RoleName, int Priority)
        {
            try
            {
                return Entities.tbCustomerRoles.Where(x => x.RoleName == RoleName || x.Priority == Priority && x.IsActive == true && x.IsDelete == false).Any();                
            }
            catch
            {
                throw;
            }
        }

        public bool IsUpdated(RoleProperty oRole)
        {
            try
            {
                if (!oRole.IsDelete)
                {
                    return Entities.tbCustomerRoles.Where(x => x.RoleID != oRole.RoleId && (x.RoleName == oRole.RoleName || x.Priority == oRole.Priority) && x.IsActive == true && x.IsDelete == false).Any();
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
