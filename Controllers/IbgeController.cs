using IbgeService.Models;
using IbgeService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace IbgeService.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class IbgeController : ControllerBase
    {
        private readonly IIbgeService _service;

        public IbgeController(IIbgeService service, ILogger<IbgeController> logger)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Retorna lista com top 20 de nomes mais frequentes
        /// </summary>
        /// <response code="200">Retornado lista com nomes</response>
        /// <response code="500">Um erro ocorreu ao retornar lista com nomes</response>
        [HttpGet("v1/frequencia")]
        public async Task<IActionResult> GetFrequentes()
        {
            var result = await _service.GetFrequenciaNomesAsync();
            return Ok(result);
        }

        /// <summary>
        /// Retorna frequencias do nome especificado
        /// </summary>
        /// <response code="200">Retornado lista com frequencias do nome especificado</response>
        /// <response code="500">Um erro ocorreu ao retornar lista com frequencias do nome especificado</response>
        /// <param name="nomes">Um ou mais nomes para pesquisa. Ex: (joao ou joao,maria)</param>
        /// <param name="queryParameters">Paramêtros opcionais para filtro da pesquisa</param>
        [HttpGet("v1/frequencia/{nomes}")]
        public async Task<IActionResult> GetFrequentesPorNomes([FromRoute] string nomes, [FromQuery] QueryParameters queryParameters)
        {
            var nomesSplit = nomes.Split(",");

            if (nomesSplit.Length > 1)
            {
                var resultNomes = await _service.GetFrequenciaNomesAsync(nomesSplit);
                return Ok(resultNomes);
            }

            var resultNome = await _service.GetFrequenciaNomeAsync(nomes, queryParameters);
            return Ok(resultNome);
        }

        /// <summary>
        /// Retorna ranking de nomes mais frequentes
        /// </summary>
        /// <response code="200">Retornado lista com ranking de nomes mais frequentes</response>
        /// <response code="500">Um erro ocorreu ao retornar lista com ranking de nomes mais frequentes</response>
        /// <param name="queryParameters">Paramêtros opcionais para filtro da pesquisa</param>
        [HttpGet("v1/ranking")]
        public async Task<IActionResult> GetRanking([FromQuery] QueryParameters queryParameters)
        {
            var result = await _service.GetRankingNomeAsync(queryParameters);
            return Ok(result);
        }
    }
}
