using Exemplo_2.Context;
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
        public IEnumerable<Conta> GetContas() 
        {
            return _sqlContext.Contas.Include(x=> x.Cliente).ThenInclude(x=> x.Endereco).ToList();
        }

        [HttpPost]
        public void Post([FromBody] Conta conta)
        {
            _sqlContext.Contas.Add(conta);
            _sqlContext.SaveChanges();
        } 
    }
}
