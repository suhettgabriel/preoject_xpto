using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPTO_API.Data;
using XPTO_API.Models;

namespace XPTO_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        public IRepository _repo { get; }

        public FornecedorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
           try 
	        {	        
		        return Ok();
	        }
	        catch (Exception)
	        {

		        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
	        }
        }
        [HttpGet("{FornecedorId}")]
        public IActionResult Get(int ProdutoId)
        {
           try 
	        {	        
		        return Ok();
	        }
	        catch (Exception)
	        {

		        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
	        }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Fornecedor model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/fornecedor/{model.Id}", model);
                }

            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
            return BadRequest();
        }

        [HttpPut("{FornecedorId}")]
        public IActionResult Put(int FornecedorId)
        {
           try 
	        {	        
		        return Ok();
	        }
	        catch (Exception)
	        {

		        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
	        }
        }

        [HttpDelete("{FornecedorId}")]
        public IActionResult Delete(int FornecedorId)
        {
           try 
	        {	        
		        return Ok();
	        }
	        catch (Exception)
	        {

		        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
	        }
        }
    }
}
