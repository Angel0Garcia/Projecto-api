using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using VapeIndustry.Api.Models;

namespace VapeIndustry.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        private readonly VapeIndustryDbContext _context;

        public ProductsController(VapeIndustryDbContext context) 
        { 
            _context = context;
        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult>CrearProducto(Product producto)
        {
            await _context.Products.AddAsync(producto);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<IEnumerable<Product>>>ListaProductos()
        {
            var products = await _context.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet]
        [Route("ver")]
        public async Task<IActionResult>VerProducto(int id)
        {
            Product producto = await _context.Products.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);

        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> ActualizarProducto(int id, Product product)
        {
            var productoExistente = await _context.Products.FindAsync(id);

            productoExistente.Name = product.Name;
            productoExistente.Price = product.Price;
            productoExistente.Description = product.Description;

            _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("eliminar")]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            var productoBorrar = await _context.Products.FindAsync(id);

            _context.Products.Remove(productoBorrar);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
