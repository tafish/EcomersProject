using AutoMapper;
using Ecom.Cor.Entites.Product;
using Ecom.Cor.Interfis;
using Ecom.Infrastratiar.Data;
using Ecomers.Cor.DTO;
using Ecomers.Cor.Service;



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
    }
}
