using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgileQuoteAdminProperty.Property;
using AgileQuoteDataLogic.Data;

namespace AgileQuoteDataLogic.DataLogic
{
    public class UserRegistrationDL
    {
        AgileQuoteAdminDevelopmentEntities Entities = new AgileQuoteAdminDevelopmentEntities();
        public string InsertUserRegistrationDL(UserRegistration oUserReg, byte[] oUserImage, string name)
        {
            tbCustomerDetail oCustomer = new tbCustomerDetail();
            tbCompany oCompany = new tbCompany();
            tbAddress oAddress = new tbAddress();
            tbUserImage oImage = new tbUserImage();
            tbMembershipLogin oMembership = new tbMembershipLogin();

            try
            {
                int CompanyCode = oUserReg.CompanyCode;

                oCustomer.FirstName = oUserReg.FirstName;
                oCustomer.LastName = oUserReg.LastName;
                oCustomer.RoleName = oUserReg.RoleName;
                oCustomer.EmailID = oUserReg.EmailId;
                oCustomer.IsActive = true;
                oCustomer.IsDelete = false;
                oCustomer.IsAdminUser = oUserReg.isAdminUser;
                oCustomer.CompanyCode = CompanyCode;
                Entities.tbCustomerDetails.AddObject(oCustomer);
                Entities.SaveChanges();

                oAddress.PhoneNumber = oUserReg.PhoneNumber;
                oAddress.MobileNumber = oUserReg.MobileNumber;
                oAddress.UserID = oCustomer.UserID;
                oAddress.AddressOne = oUserReg.AddressOne;
                oAddress.AddressTwo = oUserReg.AddressTwo;
                oAddress.AddressType = "Billing";
                oAddress.City = oUserReg.City;
                oAddress.State = oUserReg.State;
                oAddress.Country = oUserReg.Country;
                oAddress.PostalCode = oUserReg.PostalCode;
                oAddress.IsActive = true;
                oAddress.IsDelete = false;
                Entities.tbAddresses.AddObject(oAddress);

                oMembership.EmailID = oUserReg.EmailId;
                oMembership.CompanyName = oUserReg.CompanyName;
                oMembership.Password = oUserReg.Password;
                oMembership.IsActive = true;
                oMembership.IsDelete = false;
                Entities.tbMembershipLogins.AddObject(oMembership);
                
                if (oUserImage != null)
                {
                    oImage.ImageContent = oUserImage;
                    oImage.UserID = oCustomer.UserID;
                    oImage.IsActive = true;
                    oImage.IsDelete = false;
                    Entities.tbUserImages.AddObject(oImage);
                }

                Entities.SaveChanges();
                return "Success";

            }
            catch
            {
                throw;
            }
        }

        public List<CompanyValues> CompanyNameListDL()
        {
            List<CompanyValues> oList = new List<CompanyValues>();
            CompanyValues oCompany = null;
            try
            {
                var oCompanyList = Entities.tbCompanies.Where(x => x.CompanyName == x.CompanyName && x.IsDelete == false && x.IsActive == true).ToList();

                foreach (var item in oCompanyList)
                {
                    oCompany = new CompanyValues();
                    oCompany.Code = item.CompanyCode;
                    oCompany.Name = item.CompanyName;
                    oList.Add(oCompany);
                }
                return oList;
            }
            catch
            {
                throw;
            }
        }

        public List<UserRoleList> RoleNameListDL()
        {
            List<UserRoleList> oRole = new List<UserRoleList>();
            UserRoleList oRoles = null;
            try
            {
                var oRoleList = Entities.tbCustomerRoles.Where(x => x.RoleName == x.RoleName && x.IsDelete == false && x.IsActive == true).ToList();

                foreach (var item in oRoleList)
                {
                    oRoles = new UserRoleList();
                    oRoles.RoleId = item.RoleID;
                    oRoles.RoleName = item.RoleName;
                    oRole.Add(oRoles);
                }
                return oRole;
            }
            catch
            {
                throw;
            }
        }

        public List<RegistrationGrid> UserRegistrationListDL()
        {
            List<RegistrationGrid> oRegistrationList = new List<RegistrationGrid>();
            RegistrationGrid oRegistration = null;
            try
            {
                var oUserList = Entities.spRegistrationList(null).ToList();
                foreach (var item in oUserList)
                {
                    oRegistration = new RegistrationGrid();
                    oRegistration.UserName = item.UserName;
                    oRegistration.EmailId = item.EmailID;
                    oRegistration.RoleName = item.RoleName;
                    oRegistration.MobileNumber = item.MobileNumber;
                    oRegistration.State = item.State;
                    oRegistration.Country = item.Country;
                    oRegistration.CompanyCode = item.CompanyCode;
                    oRegistration.UserId = item.UserID;
                    oRegistrationList.Add(oRegistration);
                }
                return oRegistrationList;
            }
            catch
            {
                throw;
            }
        }

        public RegistrationGrid SingleRegistrationDL(int UserId, int CompanyCode)
        {
            RegistrationGrid oUserReg = new RegistrationGrid();
            try
            {
                var oSingleReg = Entities.spUserRegistration(UserId, CompanyCode).FirstOrDefault();
                if (oSingleReg != null)
                {
                    oUserReg.UserId = oSingleReg.UserID;
                    oUserReg.CompanyCode = oSingleReg.CompanyCode;
                    oUserReg.FirstName = oSingleReg.FirstName;
                    oUserReg.LastName = oSingleReg.LastName;
                    //oUserReg.CompanyName = oSingleReg.CompanyName;
                    oUserReg.EmailId = oSingleReg.EmailID;
                    //oUserReg.RoleName = oSingleReg.RoleName;
                    oUserReg.PhoneNumber = oSingleReg.PhoneNumber;
                    oUserReg.MobileNumber = oSingleReg.MobileNumber;
                    oUserReg.AddressOne = oSingleReg.AddressOne;
                    oUserReg.AddressTwo = oSingleReg.AddressTwo;
                    oUserReg.City = oSingleReg.City;
                    oUserReg.State = oSingleReg.State;
                    oUserReg.Country = oSingleReg.Country;
                    oUserReg.PostalCode = oSingleReg.PostalCode;
                    oUserReg.DefaultCompany = oSingleReg.CompanyCode;
                    oUserReg.DefaultRole = oSingleReg.RoleName;
                    oUserReg.isAdminUser = oSingleReg.IsAdminUser;
                }
                return oUserReg;
            }
            catch
            {
                throw;
            }
        }

        public string UpdateRegistrationDL(RegistrationGrid oUserReg, byte[] oUserImage, string name)
        {
            try
            {

                //var oCompany = Entities.tbCompanies.Where(x => x.CompanyCode == oUserReg.CompanyCode && x.IsDelete == false && x.IsActive == true).FirstOrDefault();

                //if (oCompany != null)
                //{
                //    oCompany.CompanyName = oUserReg.CompanyName;
                //}

                var oCustomer = Entities.tbCustomerDetails.Where(x => x.UserID == oUserReg.UserId && x.IsDelete == false && x.IsActive == true).FirstOrDefault();

                if (oCustomer != null)
                {
                    oCustomer.FirstName = oUserReg.FirstName;
                    oCustomer.LastName = oUserReg.LastName;
                    oCustomer.EmailID = oUserReg.EmailId;
                    oCustomer.RoleName = oUserReg.RoleName;
                    oCustomer.CompanyCode = oUserReg.CompanyCode;
                    oCustomer.IsAdminUser = oUserReg.isAdminUser;
                }

                var oAddress = Entities.tbAddresses.Where(x => x.UserID == oUserReg.UserId && x.IsDelete == false && x.IsActive == true).FirstOrDefault();

                if (oAddress != null)
                {
                    oAddress.AddressOne = oUserReg.AddressOne;
                    oAddress.AddressTwo = oUserReg.AddressTwo;
                    oAddress.PhoneNumber = oUserReg.PhoneNumber;
                    oAddress.MobileNumber = oUserReg.MobileNumber;
                    oAddress.City = oUserReg.City;
                    oAddress.State = oUserReg.State;
                    oAddress.Country = oUserReg.Country;
                    oAddress.PostalCode = oUserReg.PostalCode;
                }

                var oImage = Entities.tbUserImages.Where(x => x.UserID == oUserReg.UserId && x.IsDelete == false && x.IsActive == true).FirstOrDefault();

                if (oImage != null)
                {
                    if (oUserImage != null)
                    {
                        oImage.ImageContent = oUserImage;
                    }
                }

                Entities.SaveChanges();

                return "Success";
            }
            catch
            {
                throw;
            }
        }

        public string DeleteRegistrationDL(int UserId)
        {
            try
            {
                var oCustomer = Entities.tbCustomerDetails.Where(x => x.UserID == UserId && x.IsDelete == false && x.IsActive == true).FirstOrDefault();
                if (oCustomer != null)
                {
                    oCustomer.IsActive = false;
                    oCustomer.IsDelete = true;
                }

                var oAddress = Entities.tbAddresses.Where(x => x.UserID == UserId && x.IsDelete == false && x.IsActive == true).FirstOrDefault();
                if (oAddress != null)
                {
                    oAddress.IsActive = false;
                    oAddress.IsDelete = true;
                }
                Entities.SaveChanges();
                return "Success";
            }
            catch
            {
                throw;
            }
        }

        public bool IsInserted(int CompanyCode, string EmailId)
        {

            try
            {
                return Entities.tbCustomerDetails.Where(x => x.EmailID == EmailId && x.CompanyCode == CompanyCode && x.IsActive == true && x.IsDelete == false).Any();
            }
            catch
            {
                throw;
            }

            //bool oDefault = false;
            //bool IsRecordThere = false;
            //try
            //{
            //    var Obj = Entities.tbCustomerDetails.Where(x => x.CompanyCode == CompanyCode).ToList();
            //    foreach (var item in Obj)
            //    {
            //        IsRecordThere = Obj.Where(x => x.EmailID == EmailId).Any();
            //        if (IsRecordThere)
            //        {
            //            var Record = Obj.Where(x => x.EmailID == EmailId && x.IsDelete == false && x.IsActive == true).FirstOrDefault();
            //            if (Record != null)
            //            {
            //                oDefault = true;
            //                break;
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //return oDefault;

        }
    }
}
