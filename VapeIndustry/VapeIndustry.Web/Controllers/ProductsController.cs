using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        
        
    }
}
