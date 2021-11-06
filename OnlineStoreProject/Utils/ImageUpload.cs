using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Utils
{
    public class ImageUpload
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public ImageUpload(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        public async Task<string> Upload(IFormFile image)
        {
            try
            {
                //Save image to wwwroot/images
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(image.FileName);
                string extension = Path.GetExtension(image.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/images/", fileName);

                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                return fileName;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public void Delete(Product product)
        {
            //delete image from wwwroot/images
            if (product.ImagePath is not null)
            {
                var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "images", product.ImagePath);
                Console.WriteLine(imagePath);
                if (File.Exists(imagePath))
                {
                    Console.WriteLine(imagePath);
                    File.Delete(imagePath);
                }
            }
            
        }
    }
}
