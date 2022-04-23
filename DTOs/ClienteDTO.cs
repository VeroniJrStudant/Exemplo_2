using Exemplo_2.Models;

namespace Exemplo_2.DTOs
{
    public class ClienteDTO
    {
        public string Estado { get; set; }
        public string Nome { get; private set; }

        public static explicit operator ClienteDTO (Cliente cliente)
        {
            if( cliente == null )
                return null;

            return new ClienteDTO()
            {
                Nome = cliente.Nome,
                Estado = cliente.Endereco?.Estado == null ? "Sem Estado" : cliente.Endereco.Estado,
            };
        }
    }
}
