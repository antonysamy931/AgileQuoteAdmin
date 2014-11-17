using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileQuoteDataLogic.DataLogic;
using AgileQuoteAdminProperty.Property;

namespace AgileQuoteAdminBusinessLogic.BusinessLogic
{
    public class UserRegistrationBL
    {
        UserRegistrationDL oUserRegDL = new UserRegistrationDL();
        public string InsertUserRegistrationBL(UserRegistration oUserReg, byte[] oUserImage, string name)
        {
            try
            {               
                if (!oUserRegDL.IsInserted(oUserReg.CompanyCode, oUserReg.EmailId))
                {
                    return oUserRegDL.InsertUserRegistrationDL(oUserReg, oUserImage, name);
                }
                else
                {
                    return "Failed";
                }
            }
            catch
            {
                throw;
            }            
        }


        public List<CompanyValues> CompanyNameListBL()
        {
            try
            {
                return oUserRegDL.CompanyNameListDL();
            }
            catch
            {
                throw;
            }
        }

        public List<UserRoleList> RoleNameListBL()
        {
            try
            {
                return oUserRegDL.RoleNameListDL();
            }
            catch
            {
                throw;
            }
        }

        public List<RegistrationGrid> UserRegistrationListBL()
        {
            try
            {
                return oUserRegDL.UserRegistrationListDL();
            }
            catch
            {
                throw;
            }
        }

        public RegistrationGrid SingleRegistrationBL(int UserId, int CompanyCode)
        {
            try
            {
                return oUserRegDL.SingleRegistrationDL(UserId, CompanyCode);
            }
            catch
            {
                throw;
            }
        }

        public string UpdateRegistrationBL(RegistrationGrid oUserReg, byte[] oUserImage, string name)
        {

            try
            {
                return oUserRegDL.UpdateRegistrationDL(oUserReg, oUserImage, name);
            }
            catch
            {
                throw;
            }
        }

        public string DeleteRegistrationBL(int UserId)
        {
            try
            {
                return oUserRegDL.DeleteRegistrationDL(UserId);
            }
            catch
            {
                throw;
            }
        }
    }
}
