using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XPTO_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        public ProdutoController()
        {
            
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpGet("{produtoId}")]
        public IActionResult Get(int ProdutoId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        [HttpPut("{produtoId}")]
        public IActionResult Put(int ProdutoId)
        {
            return Ok();
        }

        [HttpDelete("{produtoId}")]
        public IActionResult Delete(int ProdutoId)
        {
            return Ok();
        }
    }
}
