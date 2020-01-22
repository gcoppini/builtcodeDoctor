using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Dapper;
using Builtcode.Doctor.Domain;
using Microsoft.Extensions.Logging;
 

namespace Builtcode.Doctor.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly ILogger<MedicoController> _logger;

        public MedicoController(ILogger<MedicoController> logger)
        {
            _logger = logger;
        }



        // GET api/values
        [HttpGet]
        public IEnumerable<Medico> Get(
            [FromServices]IConfiguration configuration)
        {
            using (SqlConnection conexao = new SqlConnection(
                configuration.GetConnectionString("BaseBuiltcodeDoctor")))
            {
                return conexao.Query<Medico>("SELECT * FROM dbo.MEDICO");
            }
        }

        [Route("medico")]
        [HttpPut]
        public bool Put([FromBody]Medico medico)
        {
            _logger.LogInformation(2,"[Put] Getting item {Id}", medico.Id.ToString());
            return true;
        }

        [Route("medico")]
        [HttpPost]
        public bool Post([FromBody]Medico medico)
        {
            _logger.LogInformation(2,"[Post] Getting item {Id}", medico.Id.ToString());
            return true;
        }

        


    }
}