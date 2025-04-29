using AutoMapper;
using Ecom.Cor.Entites.Product;
using Ecom.Cor.Interfis;
using Ecom.Infrastratiar.Data.Config;
using Ecomers.API.Helper;
using Ecomers.Cor.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecomers.API.Controllers
{
    public class ProductsControIIer : BaseController
    {
        public ProductsControIIer(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }
        [HttpGet("Get-All")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var prodect = await work.productRepositry
                    .GatAllAsinc(p => p.Catagory, p => p.Photos);
                var result = mapper.Map<List<ProductDTO>>(prodect);

                if (prodect == null)
                    return BadRequest(new ResponseAPI(400));
                return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Get-by-Id/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                var prodat = await work.productRepositry.GetBayIdAsinc(Id
                    , p => p.Catagory, p => p.Photos);
                var result = mapper.Map<ProductDTO>(prodat);
                if (prodat is null)
                    return BadRequest(new ResponseAPI(400));
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Add-prodact")]
        public async Task<IActionResult> Add(AddProductDTO productDTO)
        {
            try
            {
                await work.productRepositry.AddAsync(productDTO);
                return Ok(new ResponseAPI(200));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }
        [HttpPut("Updet-prodact")]
        public async Task<IActionResult> Updet(UpdetProductDTO updetProductDTO) 
        {
            try
            {
                await work.productRepositry.UpdetAsync(updetProductDTO);
                return Ok(new ResponseAPI(200));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }
        [HttpDelete("Delete-prodact/{Id}")]
        public async Task<IActionResult> Delete(int Id) 
        {
            try
            {
                var prodact = await work.productRepositry
                    .GetBayIdAsinc(Id, p => p.Catagory, p => p.Photos);
                  await work.productRepositry.DeleteAsinc(Id);
                return Ok(new ResponseAPI(200));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }
    }
}
