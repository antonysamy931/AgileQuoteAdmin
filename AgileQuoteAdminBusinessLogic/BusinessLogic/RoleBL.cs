using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileQuoteDataLogic.DataLogic;
using AgileQuoteAdminProperty.Property;
using LogWriter;

namespace AgileQuoteAdminBusinessLogic.BusinessLogic
{
    public class RoleBL
    {
        RoleDL oRoleDL = new RoleDL();
        /// <summary>
        /// GetRoleListBL is used to call GetRoleListDL
        /// </summary>
        /// <returns>Returns the RoleListProperty Object</returns>
        public List<RoleProperty> GetRoleListBL()
        {
            try
            {
                return oRoleDL.GetRoleListDL();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// GetSingleRecordBL is used to call GetSingleRoleRecordDL
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns>Returns the RoleProperty Object </returns>
        public RoleProperty GetSingleRecordBL(int RoleId)
        {
            try
            {
                return oRoleDL.GetSingleRoleRecordDL(RoleId);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// InsertRoleRecordBL is used to call InsertRoleRecord
        /// </summary>
        /// <param name="rp"></param>
        /// <returns>Returns whether the Insertion was sucessful or not</returns>
        public string InsertRoleRecordBL(RoleProperty oRoleProperty)
        {
            try
            {
                if (!oRoleDL.IsInserted(oRoleProperty.RoleName, oRoleProperty.Priority))
                {
                    return oRoleDL.InsertRoleRecord(oRoleProperty);
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
        /// UpdateRoleRecordBL is used to call InsertRoleRecord
        /// </summary>
        /// <param name="rp"></param>
        /// <returns>Returns whether the Updation was sucessful or not</returns>
        public string UpdateRoleRecordBL(RoleProperty oRoleProperty)
        {
            try
            {
                if (!oRoleDL.IsUpdated(oRoleProperty))
                {
                    return oRoleDL.UpdateRoleDL(oRoleProperty);
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
        /// DeleteRoleRecordBL is  used to call DeleteRoleDL
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns>Returns whether it was succesfully deleted or not</returns>
        public string DeleteRoleRecordBL(int RoleID)
        {
            try
            {

                return oRoleDL.DeleteRoleDL(RoleID);

            }
            catch
            {
                throw;
            }            
        }
    }
}
