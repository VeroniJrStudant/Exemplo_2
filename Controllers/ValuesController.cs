using Exemplo_2.Context;
using Exemplo_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exemplo_2.Controllers
{
    [Route("api/[cliente]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly SqlContext _sqlContext;

        public ValuesController(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }
        [HttpGet]
        public  IEnumerable<Cliente> Get()
        {
            return _sqlContext.Clientes.ToList();
        }
    }
}
