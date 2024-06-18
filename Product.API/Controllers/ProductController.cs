using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Product.API.Models;
using System.Security;

namespace Product.API.Controllers
{
    [EnableCors("CrossPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly AppDbContext _ctx;
        public ProductController(AppDbContext context)
        {
            _ctx = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productList = await (from c in _ctx.Products
                               join d in _ctx.ProductTypes on c.ProductTypeId equals d.ProductTypeId
                               select new ProductViewModel
                               {
                                   ProductName = c.ProductName,
                                   ProductExpiry = c.ProductExpiry.ToShortDateString(),
                                   Company = c.Company,
                                   ProductPrice = c.ProductPrice,
                                   ProductId = c.ProductId,
                                   SelectedProductType = d.ProductTypeName
                               }).ToListAsync();
            return Ok(productList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var selectedpdt = await (from c in _ctx.Products
                                     join d in _ctx.ProductTypes on c.ProductTypeId equals d.ProductTypeId
                                     where c.ProductId == id
                                     select c).FirstOrDefaultAsync();
            if (selectedpdt == null)
            {
                return NotFound();
            }

            return Ok(selectedpdt);
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductViewModel model)
        {
            try
            {
                var pdt = new Products()
                {
                    ProductName = model.ProductName,
                    ProductPrice = model.ProductPrice,
                    Company = model.Company,
                    ProductExpiry = Convert.ToDateTime(model.ProductExpiry),
                    ProductTypeId = Convert.ToInt32(model.SelectedProductType)
                };
                await _ctx.Products.AddAsync(pdt);
                _ctx.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(ProductViewModel model)
        {
            var selectedpdt = await(from c in _ctx.Products
                               join d in _ctx.ProductTypes on c.ProductTypeId equals d.ProductTypeId
                               where c.ProductId == model.ProductId
                               select c).FirstOrDefaultAsync();
            if(selectedpdt == null)
            {
                return NotFound();
            }

            selectedpdt.ProductName = model.ProductName;
            selectedpdt.ProductExpiry = Convert.ToDateTime(model.ProductExpiry);
            selectedpdt.ProductPrice = model.ProductPrice;
            selectedpdt.Company = model.Company;
            selectedpdt.ProductTypeId = Convert.ToInt32(model.SelectedProductType);
            _ctx.Products.Update(selectedpdt);
            _ctx.SaveChanges();
            return Ok(selectedpdt);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var selectedpdt = await(from c in _ctx.Products
                               where c.ProductId == id
                               select c).FirstOrDefaultAsync();

            if (selectedpdt == null)
            {
                return NotFound();
            }

            selectedpdt.IsDeleted = true;
            _ctx.Products.Update(selectedpdt);
            await _ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
