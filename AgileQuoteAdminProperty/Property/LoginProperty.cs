using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AgileQuoteAdminProperty.Property
{
    public class LoginProperty
    {
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        public string PassWord { get; set; }

        [Display(Name = "Secret Number")]
        public int SecretNumber { get; set; }

        public List<CompanyValues> CompanyNameList { get; set; }
        public string DefaultCompany { get; set; }
    }
}
