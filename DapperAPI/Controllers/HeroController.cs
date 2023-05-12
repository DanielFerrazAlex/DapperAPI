using AutoMapper;
using DapperAPI.Models;
using DapperAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DapperAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeroController : ControllerBase
    {
        private readonly IHeroRepository _repository;
        private readonly IMapper _mapper;

        public HeroController(IMapper mapper, IHeroRepository repository)
        {
            _mapper = mapper;
            _repository = repository;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entity>>> BuscarTodosOsHeros()
        {
            try
            {
                return Ok(await _repository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    "Erro ao recuperar dados no Banco de Dados");
            }
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Entity>> BuscarHeroPorId(int id)
        {
            try
            {
                var restultado = await _repository.GetById(id);
                if (restultado is null)
                    return NotFound($"Id: {id}, nao foi localizado. Tente novamente");

                var resultadoDTO = _mapper.Map<Entity>(restultado);
                return Ok(resultadoDTO);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar dados no Banco de Dados");
            }
        }

        [HttpGet("[action]/{name}")]
        public async Task<ActionResult<Entity>> BuscarHeroPorNome(string name)
        {
            try
            {
                var restultado = await _repository.GetByName(name);
                if (restultado is null)
                    return NotFound($"Name: {name}, nao foi localizado. Tente novamente");

                var resultadoDTO = _mapper.Map<Entity>(restultado);
                return Ok(resultadoDTO);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar dados no Banco de Dados");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarHero([FromBody] Entity entity)
        {
            try
            {
                await _repository.CreateAsync(entity);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao inserir dados no Banco de Dados");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizarHero([FromBody] Entity entity, int id)
        {
            try
            {
                await _repository.UpdateAsync(entity, id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao atualizar dados no Banco de Dados");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Entity>> DeletarHero(int id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao deletar dados no Banco de Dados");
            }
        }
    }
}
