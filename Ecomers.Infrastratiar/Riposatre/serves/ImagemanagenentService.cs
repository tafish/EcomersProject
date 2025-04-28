using Ecomers.Cor.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecomers.Infrastratiar.Riposatre.serves
{
    public class ImagemanagenentService : IImagemanagenentService
    {
        private readonly IFileProvider fileProvider;
        public ImagemanagenentService(IFileProvider fileProvider)
        {
            this.fileProvider = fileProvider;
        }
        public async Task<List<string>> AddImageAsync(IFormFileCollection files, string src)
        {
            var saveImageSrc = new List<string>();
            var imageDirectory = Path.Combine("wwwroot", "Image", src);

            if (!Directory.Exists(imageDirectory))
            {
                Directory.CreateDirectory(imageDirectory);
            }

            foreach (var item in files)
            {
                if (item.Length > 0)
                {
                    var imageName = item.FileName;
                    var imageSrc = $"Image/{src}/{imageName}";
                    var root = Path.Combine(imageDirectory, imageName);

                    using (FileStream stream = new FileStream(root, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }

                    saveImageSrc.Add(imageSrc);
                }
            }

            return saveImageSrc;
        }



        public void DeletImegaAsinc(string src)
        {
            var info = fileProvider.GetFileInfo(src);
            var root = info.PhysicalPath;
            File.Delete(root);

        }
    }
}
