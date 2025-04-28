using AutoMapper;
using Ecom.Cor.Entites.Product;
using Ecom.Cor.Interfis;
using Ecomers.API.Helper;
using Ecomers.Cor.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecomers.API.Controllers
{

    public class CategoriesController : BaseController
    {
        public CategoriesController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }

        [HttpGet("gey-all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var catogory = await work.categoryRepositrycs.GatAllAsinc();
                if (catogory is null)
                    return BadRequest(new ResponseAPI(400));
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
                    return BadRequest(new ResponseAPI(400, $"not fond Catagory Id{Id}"));
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
                var catagory = mapper.Map<Catagory>(catagoryDTO);
                await work.categoryRepositrycs.AddAsinc(catagory);
                return Ok(new ResponseAPI(400, "Item Hase Ben Added"));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Updet-Catagory")]
        public async Task<IActionResult> UpdetCatagory(UpdetCatagoryDTO catagoryDTO)
        {
            try
            {
                var catagory = mapper.Map<Catagory>(catagoryDTO);
                await work.categoryRepositrycs.UpdateAsinc(catagory);
                return Ok(new ResponseAPI(400, "Item Hase Ben Updeted"));


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delet-catarogry/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await work.categoryRepositrycs.DeleteAsinc(Id);
                return Ok(new ResponseAPI(200, "Item Hase Ben Dleted"));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
