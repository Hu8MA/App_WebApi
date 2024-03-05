using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Com.Core.EntitiesException;
using Com.Core.ValueObject;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using static System.Net.WebRequestMethods;

namespace Com.Services.File
{
    public interface IService_Image
    {
        public Task<string> Save(IFormFile file , int userId);
        public Task<bool> Delete( int userId);
         public Task<List<string>> GetImagesURL(string link , string folderpath,int userId);
     }

    public class Service_Image : IService_Image
    {
        private readonly IWebHostEnvironment _environment;
        
        public Service_Image(IWebHostEnvironment environment )
        {
            _environment = environment;
 
        }

        public Task<string> Save(IFormFile file,int userId)
        {
            try
            {       string floderpath = "ImagesUploaded\\" + userId.ToString();
                    string uplodefile = Path.Combine(_environment.WebRootPath, floderpath);
                    if(!System.IO.Directory.Exists(uplodefile))
                    {
                        System.IO.Directory.CreateDirectory(uplodefile);
                    }
                    else
                    {
                         string newuplodefile = uplodefile + ""+1;
                         System.IO.Directory.CreateDirectory(newuplodefile);

                    }
                string uniqimage = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filepath = Path.Combine(uplodefile, uniqimage);
                file.CopyTo(new FileStream(filepath, FileMode.Create));
                return Task.FromResult(floderpath);
               
            }
            catch
            {
                throw new BadRequestException("The error when Save Image");
            }
    
        }


        public Task<bool> Delete(int userId)
        {
            try
            {
                string filePath = Path.Combine(_environment.WebRootPath, "ImagesUploaded\\" + userId);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                    return Task.FromResult(true);
                }
                else
                {
                    return Task.FromResult(false);
                }
            }
            catch 
            {
                return Task.FromResult(false);
            }
        }
     


        public async Task<List<string>> GetImagesURL(string link,string folderpath, int userId)
        {
            string imagespath = Path.Combine(_environment.WebRootPath, folderpath); 

            List<string> urls = new List<string>();
            try
            {            
                if (Directory.Exists(imagespath))
                {
                    DirectoryInfo directory = new DirectoryInfo(imagespath);
                    FileInfo[] files = directory.GetFiles();

                    foreach (FileInfo file in files)
                    {
                        string path = imagespath +"\\" +file.Name;

                        if (System.IO.File.Exists(path))
                        {
                            string url = link + "/ImagesUploaded/" + userId + "/" + file.Name;
                            urls.Add(url);
                        }
                        else
                        {
                            throw new NotFoundException($"User images not found.");

                        }
                    }

                    return urls;
                }
                else
                {
                    throw new NotFoundException($"User images not found.");
                }
            }
            catch
            {
                throw new NotFoundException($"User images not found.");

            }
        }

 
}
}
