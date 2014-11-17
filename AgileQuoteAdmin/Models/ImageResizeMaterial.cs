using System;
using System.Collections.Generic;
using System.Linq;
using ImageResizer;
using System.Web;
using System.IO;
using AgileQuoteAdminProperty.Property;
namespace AgileQuoteAdmin.Models
{
    public class ImageResizeMaterial
    {
        public void ImageResizefunction(string oImageID, List<ImageProperty> oList, string Type)
        {
            try
            {
                Dictionary<string, string> ImageCategory = new Dictionary<string, string>();
                ImageCategory.Add("Original", string.Empty);
                foreach (var item in oList)
                {
                    ImageCategory.Add(item.Name.ToLower(), "width=" + item.Width + "&height=" + item.Height + "&quality=90&crop=auto&format=jpg");
                }
                foreach (String fileKey in HttpContext.Current.Request.Files.Keys)
                {
                    HttpPostedFile file = HttpContext.Current.Request.Files[fileKey];
                    if (file.ContentLength <= 0)
                    {
                        continue;
                    }
                    String UploadFolder = HttpContext.Current.Server.MapPath("~/Content/" + Type + "/");

                    if (!Directory.Exists(UploadFolder))
                    {
                        Directory.CreateDirectory(UploadFolder);
                    }


                    foreach (KeyValuePair<string, string> oItem in ImageCategory)
                    {
                        string filename = "";
                        string FolderCreate = HttpContext.Current.Server.MapPath("~/Content/" + Type + "/" + oImageID);
                        if (!Directory.Exists(FolderCreate))
                        {
                            Directory.CreateDirectory(FolderCreate);
                        }
                        if (System.IO.File.Exists(HttpContext.Current.Server.MapPath("~/Content/" + Type + "/" + oImageID)))
                        {

                            System.IO.File.Delete(HttpContext.Current.Server.MapPath("~/Content/" + Type + "/" + oImageID));
                            filename = HttpContext.Current.Server.MapPath("~/Content/" + Type + "/" + oImageID + "/" + oItem.Key);
                        }
                        else
                        {
                            filename = HttpContext.Current.Server.MapPath("~/Content/" + Type + "/" + oImageID + "/" + oItem.Key);
                        }
                        filename = ImageBuilder.Current.Build(file, filename, new ResizeSettings(oItem.Value), false, true);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
     
    }
}