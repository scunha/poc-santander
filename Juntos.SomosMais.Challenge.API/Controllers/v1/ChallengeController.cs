using Juntos.SomosMais.Challenge.Domain.Interfaces.Services;
using Juntos.SomosMais.Challenge.Domain.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Juntos.SomosMais.Challenge.API.Controllers.v1
{
    public class ChallengeController(IChallengeService challengeService) : Controller
    {

        /// <summary>
        /// Realiza o insert e tratamento de dados através de um arquivo CSV de entrada
        /// </summary>
        /// <param name="region">Região do Usuário que pode ser Sul, Sudeste, Centro-Oeste, Norte e Nordeste</param>
        /// <param name="type">Classificação do usuário que pode ser Especial, Normal ou Laborious</param>
        /// <param name="pageNumber">Página</param>
        /// <param name="pageSize">Total de registros por página</param>
        /// <returns>Not Found</returns>
        [ActionName(nameof(GetUsers))]
        [HttpGet("{region}/{type}/{pageNumber}/{pageSize}")]
        [ProducesResponseType<bool>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsers([FromRoute, Required] string region, string type, int pageNumber, int pageSize) => Ok(challengeService.GetListPagination(region, type, pageNumber, pageSize));
        

        
        
    }
}
