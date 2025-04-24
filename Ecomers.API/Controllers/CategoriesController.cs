using Ecom.Cor.Entites.Product;
using Ecom.Cor.Interfis;
using Ecomers.Cor.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecomers.API.Controllers
{
   
    public class CategoriesController : BaseController
    {
        public CategoriesController(IUnitOfWork work) : base(work)
        {
        }
        [HttpGet("gey-all")]
        public async Task<IActionResult> Get() 
        {
            try
            {
                var catogory = await work.categoryRepositrycs.GatAllAsinc();
                if (catogory is null)
                    return BadRequest();
                return Ok(catogory);
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
           
        }
        [HttpGet("get-by-Id/{Id}")]
        public async Task<IActionResult> GetById(int Id) 
        {
            try
            {
                var catogry = await work.categoryRepositrycs.GetBayIdAsinc(Id);
                if (catogry is null)
                    return BadRequest();
                return Ok(catogry);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpPut("add-Category")]
        public async Task<IActionResult> Add(CatagoryDTO catagoryDTO) 
        {
            try
            {
                var catagory = new Catagory()
                {
                    Name = catagoryDTO.Name,
                    Description = catagoryDTO.Description,
                };
                await work.categoryRepositrycs.AddAsinc(catagory);
                return Ok(new { Message ="Item Hase Ben Added" });
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
