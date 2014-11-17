using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace AgileQuoteAdminProperty.Property
{
   
   public class UserRegistration
    {
       [Display (Name="FirstName")]
       [Required(ErrorMessage="Please enter FirstName")]
       public string FirstName { get; set; }

       [Display (Name="LastName")]
       [Required(ErrorMessage = "Please enter LastName")]
       public string LastName{get;set;}

       [Display(Name = "UserName")]       
       public string UserName { get; set; }

       public byte[] ImageContent { get; set; }
       public bool IsActive { get; set; }
       public bool IsDelete { get; set; }

       public int UserId { get; set; }
       public int CompanyCode { get; set; }

       [Display(Name = "CompanyName")]
       [Required(ErrorMessage = "Please enter CompanyName")]
       public string CompanyName { get; set; }

       public List<CompanyValues> CompanyList { get; set; }
       public string DefaultCompany { get; set; }
       public string DefaultRole { get; set; }

       public List<UserRoleList> RoleList { get; set; }

       [Display(Name="Admin User")]
       public bool isAdminUser { get; set; }

       [Display(Name = "EmailId")]
       [Required(ErrorMessage = "Please enter EmailId")]
       [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
       public string EmailId { get; set; }
       
       [Display(Name = "Password")]
       [Required(ErrorMessage="Please set Password")]
       [RegularExpression(@"^(?:.*[a-z0-9]){7,}$",ErrorMessage="Password is too short")]
       public string Password { get; set; }

       [Display(Name = "Re-Enter Password")]
       [Required(ErrorMessage = "Please Re-Enter Password")]
       [System.Web.Mvc.Compare("Password",ErrorMessage="Password Mismatch")]
       public string RePassword { get; set; }

       [Display(Name = "PhoneNumber")]
       [Required(ErrorMessage = "Please enter PhoneNumber")]
       [RegularExpression(@"^[0-9]+$", ErrorMessage = "Numbers Only..")]
       public string PhoneNumber { get; set; }

       [Display(Name = "MobileNumber")]
       [RegularExpression(@"^[0-9]+$", ErrorMessage = "Numbers Only..")]
       [Required(ErrorMessage = "Please enter MobileNumber")]
        public string MobileNumber { get; set; }

       [Display(Name = "RoleName")]
       [Required(ErrorMessage = "Please enter RoleName")]
       public string RoleName { get; set; }

       [Display(Name = "AddressOne")]
       [Required(ErrorMessage="Please enter Address")]
       public string AddressOne { get; set; }

       [Display (Name="AddressTwo")]     
       public string AddressTwo { get; set; }

       //[Display(Name = "AddressType")]
       public string AddressType { get; set; }

       [Display(Name = "City")]
       [Required(ErrorMessage = "Please enter City")]
       public string City { get; set; }

       [Display(Name = "State")]
       [Required(ErrorMessage = "Please enter State")]
       public string State { get; set; }

       [Display(Name = "Country")]
       [Required(ErrorMessage = "Please enter Country")]
       public string Country { get; set; }

       [Display(Name = "PostalCode")]
       [Required(ErrorMessage = "Please enter PostalCode")]       
       public string PostalCode { get; set; }
       
    }
   public class CompanyValues
   {
       public string Name { get; set; }
       public int Code { get; set; }
   }
   public class UserRegistrationList
   {
       public List<RegistrationGrid> RegistrationList { get; set; }
   }
   public class UserRoleList
   {
       public int RoleId { get; set; }
       public string RoleName { get; set; }
   }
   public class RegistrationGrid
   {
       [Display(Name = "FirstName")]
       [Required(ErrorMessage = "Please enter FirstName")]
       public string FirstName { get; set; }

       public bool IsActive { get; set; }
       public bool IsDelete { get; set; }

       [Display(Name = "LastName")]
       [Required(ErrorMessage = "Please enter LastName")]
       public string LastName { get; set; }

       [Display(Name = "UserName")]
       public string UserName { get; set; }

       
       public int UserId { get; set; }

       [Display(Name = "Admin User")]
       public bool isAdminUser { get; set; }
      
       public int CompanyCode { get; set; }

       [Display(Name = "CompanyName")]
       [Required(ErrorMessage = "Please enter CompanyName")]
       public string CompanyName { get; set; }

       public List<CompanyValues> CompanyList { get; set; }
       public int DefaultCompany { get; set; }
       public string DefaultRole { get; set; }

       public List<UserRoleList> RoleList { get; set; }

       //public DateTime CreateDate{ get; set; }

       [Display(Name = "EmailId")]
       [Required(ErrorMessage = "Please enter EmailId")]
       [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
       public string EmailId { get; set; }
     
       [Display(Name = "PhoneNumber")]
       [Required(ErrorMessage = "Please enter PhoneNumber")]
       [RegularExpression(@"^[0-9]+$", ErrorMessage = "Numbers Only..")]
       public string PhoneNumber { get; set; }

       [Display(Name = "MobileNumber")]
       [RegularExpression(@"^[0-9]+$", ErrorMessage = "Numbers Only..")]
       [Required(ErrorMessage = "Please enter MobileNumber")]
       public string MobileNumber { get; set; }

       [Display(Name = "RoleName")]
       [Required(ErrorMessage = "Please enter RoleName")]
       public string RoleName { get; set; }

       [Display(Name = "AddressOne")]
       [Required(ErrorMessage = "Please enter Address")]
       public string AddressOne { get; set; }

       [Display(Name="AddressTwo")] 
       [Required(ErrorMessage = "Please enter Address")]
       public string AddressTwo { get; set; }

       //[Display(Name = "AddressType")]
       public string AddressType { get; set; }

       [Display(Name = "City")]
       [Required(ErrorMessage = "Please enter City")]
       public string City { get; set; }

       [Display(Name = "State")]
       [Required(ErrorMessage = "Please enter State")]
       public string State { get; set; }

       [Display(Name = "Country")]
       [Required(ErrorMessage = "Please enter Country")]
       public string Country { get; set; }

       [Display(Name = "PostalCode")]
       [Required(ErrorMessage = "Please enter PostalCode")]
       [RegularExpression(@"^[0-9]+$", ErrorMessage = "Numbers Only..")]
       public string PostalCode { get; set; }
       
   }
}
