using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paschoalotto.Devedor.API.Controllers;
using Paschoalotto.Devedor.Domain.Interfaces.Services;
using Paschoalotto.Devedor.Domain.Models.Parcela;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paschoalotto.Parcela.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/Parcela")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class ParcelaController : BaseController
    {
        private readonly IParcelaService _parcelaService;

        public ParcelaController(IParcelaService parcelaService)
        {
            _parcelaService = parcelaService;
        }

        /// <summary>
        /// Retorna uma lista de Parcelaes.
        /// </summary>
        /// <param name="idDevedor"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParcelaModel>>> GetAllByDevedorId(int idDevedor)
        {
            return CreaterResponse(_parcelaService, await _parcelaService.GetAllByDevedorId(idDevedor));
        }

        /// <summary>
        /// Cadastro de Parcelas.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ParcelaModel>> Post([FromBody] ParcelaAddModel request)
        {
            return CreaterResponse(_parcelaService, await _parcelaService.Post(request));
        }
    }
}
