using CatalogoProdutos.Application.DTOs;
using CatalogoProdutos.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoProdutos.Api.Controllers
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        //api/produtos 
        [HttpGet]
        public async Task<ActionResult<IEnumerator<ProdutoDTO>>> GetProdutos()
        {
            var produtos = await _produtoService.GetProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id:int:min(1)}", Name = "GetProdutoId")]
        public async Task<ActionResult<ProdutoDTO>> Get(int id)
        {
            var produto = await _produtoService.GetProdutoById(id);

            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> Post([FromBody] ProdutoDTO produtoDTO)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _produtoService.Add(produtoDTO);

            return new CreatedAtRouteResult("GetProdutoId", new { id = produtoDTO.Id }, produtoDTO);
        }

        [HttpPut]
        public async Task<ActionResult<ProdutoDTO>> Put(int id, [FromBody] ProdutoDTO produtoDTO)
        {
            if (id != produtoDTO.Id)
            {
                return BadRequest();
            }

            await _produtoService.Update(produtoDTO);
            return Ok(produtoDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoDTO>> Delete(int id)
        {
            var produtoDto = _produtoService.GetProdutoById(id);
            if(produtoDto == null)
            {
                return NotFound();
            }

            await _produtoService.Remove(id);
            return Ok(produtoDto);
        }
    }
}
