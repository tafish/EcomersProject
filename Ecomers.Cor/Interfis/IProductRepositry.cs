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

        Task<bool> AddAsync(AddProductDTO productDTO);
    }
}
