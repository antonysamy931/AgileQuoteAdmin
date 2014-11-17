using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogWriter;

namespace AgileQuoteAdminBusinessLogic
{
    public class Class1
    {
        public string Method()
        {
            string a=null;
            try
            {
                a = "success";
            }
            catch (Exception ex)
            {
                LogWriter.LogWriter.Log(ex.StackTrace);
            }
            return a;
        }
    }
}
