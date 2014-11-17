using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileQuoteAdminProperty.Property
{
   public class RentalDataTable
    {
       public string sEcho { get; set; }

       public int iDisplayLength { get; set; }

       public int iDisplayStart { get; set; }

       public int iColumns { get; set; }

       public int iSortingCols { get; set; }

       public string sColumns { get; set; }
    }
}
