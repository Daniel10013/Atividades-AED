using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vendedor vendedor = new Vendedor();
            Console.WriteLine("Digite seu nome:");
            string nome = Console.ReadLine();
            if (nome == "") {
                Console.WriteLine("Digite o nome corretamente!");
                return;
            }
            vendedor.setNome(nome);
            Console.WriteLine("Digite o valor do salário:");
            double salario = double.Parse(Console.ReadLine());
            vendedor.setSalario(salario);
            
            Console.WriteLine("Digite o valor de vendas:");
            double valorVendas = double.Parse(Console.ReadLine());
            vendedor.setQuantidadeVendas(valorVendas);

            double total = vendedor.getValorSalarioTotal();
            Console.WriteLine(total);
        }
    }
}
