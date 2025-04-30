using Ecom.Cor.Entites.Product;
using Ecomers.Cor.DTO;
using Ecomers.Cor.Sharing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Cor.Interfis
{
    public interface IProductRepositry : IGenericRepositry<Product>
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync(ProductParams productParams);
        Task<bool> AddAsync(AddProductDTO productDTO);
        Task<bool> UpdetAsync(UpdetProductDTO updetProductDTO);
        Task DelettAsync(Product product);
    }
}
