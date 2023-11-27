using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoHerancaComposicaoVenda
{
    public class ItemVenda
    {
        private static long AutoIncrementoCodigo { get; set; }
        public long Codigo { get; set; }
        private int quantidade;
        public double Subtotal { get; private set; }
        public Produto ObjProduto { get; set; }
        private double preco;
        public double Preco
        {
            set
            {
                if (value > 0)
                    preco = value;
                else
                    throw new Exception("O preço deve ser maior que 0.");
            }
            get { return preco; }
        }

        public int Quantidade
        {
            set
            {
                int quantidadeEstoqueProduto = ObjProduto.Estoque;
                if (value <= 0)
                    throw new Exception("A quantidade deve ser maior que 0.");
                if (value <= quantidadeEstoqueProduto)
                {
                    ObjProduto.Estoque -= value;
                        quantidade =  value;
                }
                else
                    throw new Exception("O produto não possui estoque disponível para essa quantidade.");
            }
            get { return quantidade; }
        }


        public void AdicionarItem()
        {
            Console.Write("Informe o preço de Venda: ");
            this.Preco = Convert.ToDouble(Console.ReadLine());
            Console.Write("Informe a quantidade: ");
            this.Quantidade = Convert.ToInt32(Console.ReadLine());

            this.Subtotal = this.Quantidade * this.Preco;
        }
        public ItemVenda(Produto prod)
        {
            AutoIncrementoCodigo++;
            this.Codigo = AutoIncrementoCodigo;
            this.ObjProduto = prod;
        }

        public void ExibirItem()
        {
            Console.WriteLine($"Código Item de Venda: {this.Codigo} \tPreço vendido: {this.Preco:C2} \tQuantidade: {this.Quantidade} \tSubTotal Item: {this.Subtotal:C2} \tCódigo Produto: {this.ObjProduto.Codigo}");
        }
    }
}