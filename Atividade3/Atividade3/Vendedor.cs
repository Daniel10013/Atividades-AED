using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade3
{
    internal class Vendedor
    {
        private string nome;
        private double salario;
        private double quantidade_vendas;

        public Vendedor() { }

        public Vendedor(string nome, double salario, double quantidade_vendas)
        {
            this.nome = nome;
            this.salario = salario;
            this.quantidade_vendas = quantidade_vendas;
        }

        public void setNome(string nome)
        {
            this.nome = nome;
        }

        public string getNome()
        {
            return this.nome;
        }

        public void setSalario(double salario)
        {
            this.salario = salario;
        }

        public double getSalario()
        {
            return this.salario;
        }

        public void setQuantidadeVendas(double quantidade_vendas)
        {
            this.quantidade_vendas = quantidade_vendas;
        }

        public double getQuantidadeVendas()
        {
            return this.quantidade_vendas;
        }

        public double getValorSalarioTotal()
        {
            double total = this.salario + (this.quantidade_vendas * 0.15);
            return total;
        }
    }
}
