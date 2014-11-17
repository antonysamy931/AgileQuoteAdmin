using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileQuoteAdminProperty.Property;
using AgileQuoteDataLogic.Data;

namespace AgileQuoteDataLogic.DataLogic
{
    public class LoginDL
    {
        AgileQuoteAdminDevelopmentEntities Entities = new AgileQuoteAdminDevelopmentEntities();
        public bool CheckAuthenticationDL(LoginProperty oLogin)
        {
            try
            {
                return (from o in Entities.tbMembershipLogins
                        join oo in Entities.tbCustomerDetails
                        on o.EmailID equals oo.EmailID
                        where o.EmailID == oLogin.UserName && o.Password == oLogin.PassWord && o.IsActive == true && o.IsDelete == false
                        && oo.IsAdminUser == true && oo.IsActive == true && oo.IsDelete == false
                        select o).Any();
            }
            catch
            {
                throw;
            }

            //var oUserId = Entities.tbCustomerDetails.Where(x => x.UserID==x.UserID && x.EmailID==oLogin.UserName).FirstOrDefault();

            //bool oResult = false;
            //try
            //{
            //    if (Entities.tbMembershipLogins.Where(x => x.CompanyName == oLogin.CompanyName && x.EmailID == oLogin.UserName && x.Password == oLogin.PassWord).Any())
            //    {
            //        if (Entities.tbCustomerDetails.Where(x => x.UserID == oUserId.UserID && x.IsAdminUser == true).Any())
            //        {
            //            oResult = true;
            //        }
            //    }

            //    return oResult;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

        }

        public byte[] GetUserImageDL(int UserId)
        {

            byte[] image = null;
            try
            {
                var Object = Entities.tbUserImages.Where(x => x.UserID == UserId && x.IsActive == true && x.IsDelete == false).FirstOrDefault();
                if (Object != null)
                {
                    image = Object.ImageContent;

                }
                return image;
            }
            catch
            {
                throw;
            }
        }

        public Dictionary<int, string> GetUserNameDL(LoginProperty oLogin)
        {
            Dictionary<int, string> oUserDetails = new Dictionary<int, string>();
            try
            {
                var UserId = Entities.tbCustomerDetails.Where(x => x.EmailID == oLogin.UserName && x.IsActive == true && x.IsDelete == false).FirstOrDefault();
                var UserName = Entities.tbCustomerDetails.Where(x => x.EmailID == oLogin.UserName && x.IsActive == true && x.IsDelete == false).FirstOrDefault();
                if (UserId != null && UserName != null)
                {
                    oUserDetails.Add(UserId.UserID, UserName.FirstName);
                }
                return oUserDetails;
            }
            catch
            {
                throw;
            }
        }
    }
}
