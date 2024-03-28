using AspNetCoreWebApiProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ApplicationDBContext _context;
        public ProductsController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _context.Products.Find(id);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            {
                try
                {
                    if (id != product.ProductId)
                     return StatusCode(StatusCodes.Status400BadRequest);
                    _context.Products.Update(product);
                    _context.SaveChanges(true);
                    return StatusCode(StatusCodes.Status200OK);

                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id , Product product)
        {
            {
                try
                {
                    if (id != product.ProductId)
                    return StatusCode(StatusCodes.Status400BadRequest);
                    _context.Products.Remove(product);
                    _context.SaveChanges(true);
                    return StatusCode(StatusCodes.Status200OK);

                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
        }

    }
}
