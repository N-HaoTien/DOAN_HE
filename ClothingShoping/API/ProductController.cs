using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShoping.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IActionResult GetAll()
        {
            return Ok(new[] { "Abc", "Def" });
        }
    }
}
