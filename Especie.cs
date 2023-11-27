using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoHerancaComposicaoVenda
{
    public class Especie : Pagamento
    {
        private double quantia;
        private double troco;
        public Especie(double total) : base(total)
        {
        }
        public double Quantia
        {
            get { return quantia; }
            set
            {
                if (value >= base.Total)
                    quantia = value;
                else
                    throw new Exception("A quantia informada deve ser maior ou igual o Total da venda.");
            }
        }
        public double Troco
        {
            get
            {
                troco = this.Quantia - base.Total;
                return troco;
            }
        }
        public Especie AdicionarPagamento()
        {
            Console.Write("Informe a quantia recebida: ");
            this.Quantia = Convert.ToDouble(Console.ReadLine());
            return this;
        }
        public override void ExibeDadosPagamento()
        {
            base.ExibeDadosPagamento();
            Console.WriteLine($"Valor da quantia recebida: {this.Quantia:C2} \tValor do troco: {this.Troco:C2}");
        }
    }
}