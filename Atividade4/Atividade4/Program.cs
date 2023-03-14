using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Triangulo t = new Triangulo();

            Console.WriteLine("Digite o valor dos lados A, B, C do triangulo!");
            Console.WriteLine("Digite o valor do primeiro lado:");
            double a_value = double.Parse(Console.ReadLine());

            while(!(a_value > 0))
            {
                Console.WriteLine("Digite corretamente o valor para A!");
                a_value = double.Parse(Console.ReadLine());
            }

            t.A = a_value;

            Console.WriteLine("Digite o valor do segundo lado:");
            double b_value = double.Parse(Console.ReadLine());

            while (!(b_value > 0))
            {
                Console.WriteLine("Digite corretamente o valor para B!");
                b_value = double.Parse(Console.ReadLine());
            }
            t.B = b_value;

            Console.WriteLine("Digite o valor do segundo lado:");
            double c_value = double.Parse(Console.ReadLine());

            while (!(c_value > 0))
            {
                Console.WriteLine("Digite corretamente o valor para C!");
                c_value = double.Parse(Console.ReadLine());
            }
            t.C = c_value;

            Console.WriteLine(t.checkTriangle());
        }
    }
}
