using AutoMapper;
using Ecom.Cor.Entites.Product;
using Ecom.Cor.Interfis;
using Ecom.Infrastratiar.Data;
using Ecomers.Cor.DTO;
using Ecomers.Cor.Service;
using Microsoft.EntityFrameworkCore;




//using Ecom.Cor.Interfis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastratiar.Riposatre
{
    public class ProductRepositry : GenericRepositry<Product>, IProductRepositry
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private readonly IImagemanagenentService imagemanagenentService;
        public ProductRepositry(AppDbContext context, IMapper mapper, IImagemanagenentService imagemanagenentService) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
            this.imagemanagenentService = imagemanagenentService;
        }

        public async Task<bool> AddAsync(AddProductDTO productDTO)
        {
            if (productDTO == null) return false;
            var prodact = mapper.Map<Product>(productDTO);
            await context.Products.AddAsync(prodact);
            await context.SaveChangesAsync();
            var ImegaPath = await imagemanagenentService.AddImageAsync(productDTO.Photo, productDTO.Name);
            var Photo = ImegaPath.Select(Path => new Photo
            {
                IimegName = Path,
                ProductId = prodact.Id,

            }).ToList();

            await context.Photos.AddRangeAsync(Photo);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task DelettAsync(Product product)
        {
            var photo= await context.Photos.Where(p=>p.ProductId == product.Id)
                .ToListAsync();
            foreach (var item in photo)
            {
                imagemanagenentService.DeletImegaAsinc(item.IimegName);
            }
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }

        public async Task<bool> UpdetAsync(UpdetProductDTO updetProductDTO)
        {
            if (updetProductDTO is null)
            {
                return false;
            }
            var FinProduct = await context.Products.Include(c => c.Catagory)
                .Include(p=>p.Photos)
                .FirstOrDefaultAsync(m=>m.Id==updetProductDTO.Id);
            if (FinProduct is null)
            {
                return false;
            }
            mapper.Map<UpdetProductDTO>(FinProduct);
            var FindPhoto = await context.Photos
                .Where(p=>p.ProductId==updetProductDTO.Id).ToListAsync();
            foreach (var item in FindPhoto)
            {
                imagemanagenentService.DeletImegaAsinc(item.IimegName);

            }
            context.Photos.RemoveRange(FindPhoto);
            var ImegePath = await imagemanagenentService.AddImageAsync(updetProductDTO.Photo,updetProductDTO.Name);
            var photo = ImegePath.Select(Path => new Photo
            {
                IimegName = Path,
                ProductId = updetProductDTO.Id,
            }).ToList();

            await context.Photos.AddRangeAsync(photo);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
