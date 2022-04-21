using Exemplo_2.Enums;

namespace Exemplo_2.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public TipoContaEnum TipoConta { get; set; }
        public double Saldo { get; set; }
        public AgenciaEnum Agencia { get; set; }
        public int NumeroConta { get; set; }
        public Cliente Cliente { get; set; }
    }
}
