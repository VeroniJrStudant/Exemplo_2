using Exemplo_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Exemplo_2.Context
{
    public class SqlContext: DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}
