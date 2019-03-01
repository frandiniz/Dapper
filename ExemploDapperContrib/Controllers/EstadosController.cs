using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Dapper.Contrib.Extensions;

namespace ExemploDapperContrib.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private IConfiguration _config;

        public EstadosController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [HttpGet("todos")]
        public IEnumerable<Estado> GetEstados()
        {
            using (SqlConnection conexao = new SqlConnection(
                _config.GetConnectionString("ExemplosDapper")))
            {
                return conexao.GetAll<Estado>();
            }
        }

        [HttpGet("detalhes/{siglaEstado}")]
        public Estado GetDetalhesEstado(string siglaEstado)
        {
            using (SqlConnection conexao = new SqlConnection(
                _config.GetConnectionString("ExemplosDapper")))
            {
                return conexao.Get<Estado>(siglaEstado);
            }
        }


        [HttpPost("inserir")]
        public bool InsereEstado([FromBody]Estado estado)
        {

            using (SqlConnection conexao = new SqlConnection(
                _config.GetConnectionString("ExemplosDapper")))
            {
                conexao.Insert(estado);
                return true;
                //return conexao.GetAll<Estado>();
            }
        }

        [HttpDelete("deletar/{siglaEstado}")]
        public bool DeletaEstado(string siglaEstado)
        {
            using (SqlConnection conexao = new SqlConnection(
               _config.GetConnectionString("ExemplosDapper")))
            {
                conexao.Delete(new Estado() { SiglaEstado = siglaEstado });
                return true;
            }

        }

        [HttpPut("atualizar")]
        public bool AtualizarEstado([FromBody]Estado estado)
        {
            using (SqlConnection conexao = new SqlConnection(
              _config.GetConnectionString("ExemplosDapper")))
            {
                conexao.Update(estado);
                return true;
            }
        }


    }
}