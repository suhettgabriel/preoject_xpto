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
        public async Task<IActionResult> Get()
        {
           try 
	        {
                var results = await _repo.GetAllFornecedoresAsync(true);        
		        return Ok(results);
	        }
	        catch (Exception)
	        {

		        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
	        }
        }
        [HttpGet("{FornecedorId}")]
        public async Task<IActionResult> Get(int ProdutoId)
        {
           try 
	        {
                var results = await _repo.GetFornecedorAsyncById(ProdutoId, true);
                return Ok(results);
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
        public async Task<IActionResult> Put(int FornecedorId, Fornecedor model)
        {
           try 
	        {
                var Fornecedor = await _repo.GetFornecedorAsyncById(FornecedorId, false);
                if (Fornecedor == null) return NotFound();

                _repo.Update(model);
                if(await _repo.SaveChangesAsync())
                {
                    return Ok();
                }

	        }
	        catch (Exception)
	        {

		        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
	        }
            return BadRequest();
        }

        [HttpDelete("{FornecedorId}")]
        public async Task<IActionResult> Delete(int FornecedorId)
        {
           try 
	        {
                var Fornecedor = await _repo.GetFornecedorAsyncById(FornecedorId, false);
                if (Fornecedor == null) return NotFound();

                _repo.Delete(Fornecedor);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
	        catch (Exception)
	        {

		        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
	        }
            return BadRequest();
        }
    }
}
