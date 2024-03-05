using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Core.ValueObject
{
    public  class Image_Value
    { 
        /// <summary>
        ///  is  to check in file is null or empty or is max size over 5 MB
        /// </summary>
       

        public bool   CheckImageSize(IFormFile imageFile)
        {
             if (imageFile == null || imageFile.Length == 0)
                {
                    return false;  
                }

            long fileSizeInBytes = imageFile.Length;
            double fileSizeInMegabytes = fileSizeInBytes / (1024 * 1024);  

            string fileExtension = Path.GetExtension(imageFile.FileName)?.ToLower();

            if (string.IsNullOrEmpty(fileExtension) || !(fileExtension == ".png" || fileExtension == ".jpg" || fileExtension == ".jpng"))
            {
                return false;
            }
            const double maxSizeInMegabytes = 4.0;
            if (fileSizeInMegabytes > maxSizeInMegabytes)
            {
                return false;  
            }
             
            return true;
        }

    }
}
