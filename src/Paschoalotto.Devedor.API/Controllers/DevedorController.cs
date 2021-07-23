using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paschoalotto.Devedor.Domain.Interfaces.Services;
using Paschoalotto.Devedor.Domain.Models.Devedor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paschoalotto.Devedor.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/Devedor")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class DevedorController : BaseController
    {
        private readonly IDevedorService _devedorService;

        public DevedorController(IDevedorService devedorService)
        {
            _devedorService = devedorService;
        }

        /// <summary>
        /// Retorna uma lista de devedores.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DevedorModel>>> GetAllAsync()
        {
            return CreaterResponse(_devedorService, await _devedorService.GetAllAsync());
        }

        /// <summary>
        /// Cadastro de devedores.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<DevedorModel>> Post([FromBody] DevedorModel request)
        {
            return CreaterResponse(_devedorService, await _devedorService.Post(request));
        }
    }
}
