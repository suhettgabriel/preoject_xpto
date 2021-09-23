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
    public class ProdutoController : ControllerBase
    {
        public IRepository _repo { get; }
        public ProdutoController(IRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try 
	        {
                var result = await _repo.GetAllProdutosAsync(true);        
		        return Ok(result);
	        }
	        catch (Exception)
	        {

		        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
	        }
            
        }
        [HttpGet("{produtoId}")]
        public async Task<IActionResult> GetByAlunoId(int ProdutoId)
        {
            try 
	        {
                var result = await _repo.GetProdutosAsyncById(ProdutoId,true);
                return Ok(result);
            }
	        catch (Exception)
	        {

		        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
	        }
        }
        [HttpGet("ByFornecedor/{FornecedorId}")]
        public async Task<IActionResult> GetByFornecedorId(int FornecedorId)
        {
            try
            {
                var result = await _repo.GetProdutosAsyncByFornecedorId(FornecedorId, true);
                return Ok(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Produto model)
        {
           try 
	        {
                _repo.Add(model);
                if(await _repo.SaveChangesAsync()) 
                {
                    return Created($"/api/produto/{model.Id}", model);
                }
		        
	        }
	        catch (Exception)
	        {

		        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
	        }
            return BadRequest();
        }

        [HttpPut("{produtoId}")]
        public async Task<IActionResult> Put(int ProdutoId, Produto model)
        {
           try 
	        {
                var produto = await _repo.GetProdutosAsyncById(ProdutoId, false);
                if (produto == null) return NotFound();

                _repo.Update(model);
                if (await _repo.SaveChangesAsync())
                {
                    produto = await _repo.GetProdutosAsyncById(ProdutoId, true);
                    return Created($"/api/produto/{model.Id}", produto);
                }
	        }
	        catch (Exception)
	        {

		        return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
	        }
            return BadRequest();
        }

        [HttpDelete("{produtoId}")]
        public async Task<IActionResult> Delete(int ProdutoId)
        {
            try
            { 
            var produto = await _repo.GetProdutosAsyncById(ProdutoId, false);
            if (produto == null) return NotFound();
            _repo.Delete(produto);

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
