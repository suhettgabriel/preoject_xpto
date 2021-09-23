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
    public class FornecedorController : ControllerBase
    {
        public FornecedorController()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpGet("{FornecedorId}")]
        public IActionResult Get(int ProdutoId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        [HttpPut("{FornecedorId}")]
        public IActionResult Put(int FornecedorId)
        {
            return Ok();
        }

        [HttpDelete("{FornecedorId}")]
        public IActionResult Delete(int FornecedorId)
        {
            return Ok();
        }
    }
}
