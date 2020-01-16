using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Dapper;
using Builtcode.Doctor.Domain;

namespace Builtcode.Doctor.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Paciente> Get(
            [FromServices]IConfiguration configuration)
        {
            using (SqlConnection conexao = new SqlConnection(
                configuration.GetConnectionString("BaseBuiltcodeDoctor")))
            {
                return conexao.Query<Paciente>("SELECT * FROM dbo.PACIENTE");
            }
        }
    }
}