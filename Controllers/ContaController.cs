using Exemplo_2.Context;
using Exemplo_2.DTOs;
using Exemplo_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exemplo_2.Controllers
{
    [Route("api/conta")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly SqlContext _sqlContext;

        public ContaController(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }
        [HttpGet]
        public IEnumerable<ContaDTO> GetContas()
        {
            List<Conta>  contas = _sqlContext
                .Contas
                .Include(x=> x.Cliente)
                    .ThenInclude(x=> x.Endereco)
                .ToList();

            var retorno = new List<ContaDTO>();
            foreach (var unidade_dentro_da_lista in contas)  
            {
                retorno.Add((ContaDTO)unidade_dentro_da_lista);
            }
            return retorno;
        }

        [HttpPost]
        public void Post([FromBody] Conta conta)
        {
            _sqlContext.Contas.Add(conta);
            _sqlContext.SaveChanges();
        } 
    }
}
