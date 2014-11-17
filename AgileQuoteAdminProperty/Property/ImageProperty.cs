using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace AgileQuoteAdminProperty.Property
{
   public class ImageProperty
    {
       public string CategoryId {get;set; }
       public string Name{get;set;}
       public string ImageFormat{get;set;}
       public int Height{get;set;}
       public int Width{get;set;}       
    }
   public class ImagePropertyList
   {
       public List<ImageProperty> ImageList;
   }
}
