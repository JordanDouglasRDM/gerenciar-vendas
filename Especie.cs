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
            private set { }
        }

        public Especie(double total, double quant) : base(total)
        {
            this.Quantia = quant;
        }
        public override void ExibeDadosPagamento()
        {
            base.ExibeDadosPagamento();
            Console.WriteLine($"Valor da quantia recebida: {this.Quantia:C2}");
            Console.WriteLine($"Valor do troco: {this.Troco:C2}");
        }
    }
}