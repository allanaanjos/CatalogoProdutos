using CatalogoProdutos.Application.DTOs;
using CatalogoProdutos.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoProdutos.Api.Controllers
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerator<ProdutoDTO>>> GetProdutos()
        {
            var produtos = await _produtoService.GetProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProdutoDTO>> Get(int id)
        {
            var produto = await _produtoService.GetProdutoById(id);

            if (produto == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> Post([FromBody] ProdutoDTO produtoDTO)
        {
            if (ModelState.IsValid)
                return BadRequest(ModelState);

            await _produtoService.Add(produtoDTO);

             return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProdutoDTO>> Put(int id, [FromBody] ProdutoDTO produtoDTO)
        {
            if (id != produtoDTO.Id)
               return BadRequest();

            await _produtoService.Update(produtoDTO);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProdutoDTO>> Delete(int id)
        {
            var produtoDto = _produtoService.GetProdutoById(id);
            
            if(produtoDto == null)
               return NotFound();
           

            await _produtoService.Remove(id);
            return Ok();
        }
    }
}
