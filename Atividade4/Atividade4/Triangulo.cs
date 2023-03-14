using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade4
{
    internal class Triangulo
    {
        private double a;
        private double b;
        private double c;
        
        public Triangulo () { }

        public Triangulo (double lado_a, double lado_b, double lado_c)
        {
            this.a = lado_a;
            this.b = lado_b;
            this.c = lado_c;
        }

        public double A { 
            set { a = value; }
            get { return a; }
        }

        public double B { 
            set { b = value; } 
            get { return b; } 
        }

        public double C
        {
            set { c = value; }
            get { return c; }
        }

        public string checkTriangle()
        {
            if (this.a >= (this.b + this.c))
            {
                return "Não é um triangulo";
            }

            return checkTriangleType();
        }

        private string checkTriangleType()
        {
            if (this.a == this.b && this.b == this.c && this.c == this.a)
            {
                return "É um triângulo equilátero";
            }
            if (Math.Pow(this.a, 2.00) == (Math.Pow(this.b, 2.00) + Math.Pow(this.c, 2.00)))
            {
                return "É um triângulo retangulo";
            }
            if (Math.Pow(this.a, 2.00) > (Math.Pow(this.b, 2.00) + Math.Pow(this.c, 2.00)))
            {
                return "É um triângulo obtusangulo";
            }
            if (Math.Pow(this.a, 2.00) < (Math.Pow(this.b, 2.00) + Math.Pow(this.c, 2.00)))
            {
                return "É um triângulo acutangulo";
            }
            if (this.a == this.b || this.b == this.c || this.c == this.a)
            {
                return "É um triângulo isóceles";
            }   

            return "";
        }
    }
}
