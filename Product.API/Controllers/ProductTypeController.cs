using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.API.Models;

namespace Product.API.Controllers
{
    [EnableCors("CrossPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : Controller
    {
        private readonly AppDbContext _ctx;
        public ProductTypeController(AppDbContext context)
        {
            _ctx = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productList = await (from c in _ctx.ProductTypes                                     
                                     select new ProductTypeViewModel
                                     {
                                         ProductTypeId = c.ProductTypeId,
                                         ProductTypeName = c.ProductTypeName
                                     }).ToListAsync();
            return Ok(productList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var selectedpdt = await (from c in _ctx.ProductTypes
                                     where c.ProductTypeId == id
                                     select c).FirstOrDefaultAsync();
            if (selectedpdt == null)
            {
                return NotFound();
            }

            return Ok(selectedpdt);
        }


        [HttpPost]
        public async Task<IActionResult> AddProductType(ProductTypeViewModel model)
        {
            try
            {
                var pdtType = new ProductType()
                {
                    ProductTypeName = model.ProductTypeName
                };
                await _ctx.ProductTypes.AddAsync(pdtType);
                _ctx.SaveChanges();
                return Ok(pdtType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(ProductTypeViewModel model)
        {
            var selectedpdt = await (from c in _ctx.ProductTypes                                    
                                     where c.ProductTypeId == model.ProductTypeId
                                     select c).FirstOrDefaultAsync();
            if (selectedpdt == null)
            {
                return NotFound();
            }
            selectedpdt.ProductTypeName = model.ProductTypeName;
            _ctx.ProductTypes.Update(selectedpdt);
            _ctx.SaveChanges();
            return Ok(selectedpdt);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var selectedpdt = await (from c in _ctx.ProductTypes
                                     where c.ProductTypeId == id
                                     select c).FirstOrDefaultAsync();

            if (selectedpdt == null)
            {
                return NotFound();
            }

            selectedpdt.IsDeleted = true;
            _ctx.ProductTypes.Update(selectedpdt);
            await _ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
