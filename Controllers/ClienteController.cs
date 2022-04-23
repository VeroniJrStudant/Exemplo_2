using Exemplo_2.Context;
using Exemplo_2.DTOs;
using Exemplo_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exemplo_2.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly SqlContext _sqlContext;

        public ClienteController(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }
        [HttpGet]
        public IEnumerable<ClienteDTO> Get()

        {
            return _sqlContext.Clientes.Include(x => x.Endereco).Select(x => (ClienteDTO)x).ToList();
            
            //Exemplo de metodo para simplificar
            //var clientes = _sqlContext.Clientes.Include(x => x.Endereco).ToList();

            //var clientesDTO = new List<ClienteDTO>();

            //foreach (var cliente in clientes)
            //{
            //    clientesDTO.Add((ClienteDTO)cliente);
            //}
            //return clientesDTO;
        }

    
        [HttpPost]
        public void Post([FromBody] Cliente cliente)
        {
            _sqlContext.Clientes.Add(cliente);
            _sqlContext.SaveChanges();
        }

        [HttpPut]
        public void Put([FromBody] Cliente cliente)
        {
            var clienteDTO = _sqlContext.Clientes.FirstOrDefault(x => x.Id ==cliente.Id);

            if (clienteDTO != null)
            {
                _sqlContext.Clientes.Update(cliente);
                _sqlContext.SaveChanges();
            }
        }
    }
}
