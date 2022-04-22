using Exemplo_2.Models;

namespace Exemplo_2.DTOs;

public class ContaDTO
{
    public string Nome { get; set; }
    public double Saldo { get; set; }

    public static explicit operator ContaDTO(Conta conta)
    {
        if (conta == null)
            return null;
        
        return new ContaDTO()
        {
            Nome = conta.Cliente.Nome,
            Saldo = conta.Saldo
        };
    }

    public static ContaDTO ConversorDeObjetos(Conta conta)
    {
        if (conta == null)
            return null;
        
        return new ContaDTO()
        {
            Nome = conta.Cliente.Nome
        };
    }
}