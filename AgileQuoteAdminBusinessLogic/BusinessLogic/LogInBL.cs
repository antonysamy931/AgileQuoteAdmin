using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileQuoteAdminProperty.Property;
using AgileQuoteDataLogic.DataLogic;

namespace AgileQuoteAdminBusinessLogic.BusinessLogic
{
    public class LogInBL
    {
        LoginDL oLoginDL = new LoginDL();
        public bool CheckAuthenticationBL(LoginProperty oLogin)
        {            
            try
            {
                return oLoginDL.CheckAuthenticationDL(oLogin);

            }

            catch
            {
                throw;
            }            
        }

        public byte[] GetUserImageBL(int UserId)
        {            
            try
            {
               return oLoginDL.GetUserImageDL(UserId);
            }
            catch
            {
                throw;
            }            
        }

        public Dictionary<int, string> GetUserNameBL(LoginProperty oLogin)
        {
            try
            {
                return oLoginDL.GetUserNameDL(oLogin);
            }
            catch
            {
                throw;
            }
        }

    }
}
