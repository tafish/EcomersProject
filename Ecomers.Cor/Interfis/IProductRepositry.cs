using Ecom.Cor.Entites.Product;
using Ecomers.Cor.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Cor.Interfis
{
    public interface IProductRepositry : IGenericRepositry<Product>
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync(string? sor, int? categoryId, int pageSize, int pageNumber );
        Task<bool> AddAsync(AddProductDTO productDTO);
        Task<bool> UpdetAsync(UpdetProductDTO updetProductDTO);
        Task DelettAsync(Product product);
    }
}
