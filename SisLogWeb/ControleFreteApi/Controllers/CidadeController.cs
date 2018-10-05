using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFreteApi.Domain.Interface;
using ControleFreteApi.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleFreteApi.Controllers
{

    public class CidadeController : Controller
    {
        private ICidadeService _cidadeService;
        public CidadeController(ICidadeService cidadeService)
        {
            _cidadeService = cidadeService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("frete/v1/cidades/")]
        [HttpGet]
        [ProducesResponseType(typeof(CidadeDto), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(void), 409)]
        public IEnumerable<CidadeDto> GetCidades()
        {
            return _cidadeService.GetCidades();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("frete/v1/Nomecidades")]
        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(void), 409)]
        public IEnumerable<CidadeDto> GetNomeCidades([FromBody] IEnumerable<string> idCidades)
        {
            return _cidadeService.GetCidades(idCidades);
        }
    }
}