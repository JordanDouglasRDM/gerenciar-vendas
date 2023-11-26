using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoHerancaComposicaoVenda
{
    public class ItemVenda
    {
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public double Subtotal { get; set; }
        //ObjProduto é a associação estabelecida
        public Produto ObjProduto { get; set; }

        public ItemVenda(Produto prod, int quant, double prec)
        {
            this.ObjProduto = prod;
            this.Quantidade = quant;
            this.Preco = prec;
            this.Subtotal = quant * prec;
        }

        public void ExibirItem()
        {
            this.ObjProduto.ExibeProduto();
            Console.WriteLine($"\nPreço vendido: {this.Preco}");
            Console.WriteLine($"Quantidade: {this.Quantidade}");
            Console.WriteLine($"SubTotal Item: {this.Subtotal}");
        }
    }
}