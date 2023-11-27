using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace TrabalhoHerancaComposicaoVenda
{
    public class Produto
    {
        private static long AutoIncrementoCodigo { get; set; }
        public long Codigo { get; private set; }
        public string Nome { get; set; } 
        private double preco;        
        public double Preco
        {
            get 
            {
                if (preco > 0)
                return preco;
                else
                    throw new Exception("O preço deve ser maior que 0.");
            }
            set { preco = value; }
        }
        
        public int Estoque { get; set; }
        public Produto()
        {
            AutoIncrementoCodigo++;
            this.Codigo = AutoIncrementoCodigo;
        }
        public Produto AdicionarProduto()
        {   
            Console.Write("Informe o nome: ");
            this.Nome = Console.ReadLine();
            
            Console.Write("Informe o preço: ");
            this.Preco = Convert.ToDouble(Console.ReadLine());
            
            Console.Write("Informe o estoque: ");
            this.Estoque = Convert.ToInt32(Console.ReadLine());
            return this; //representa o próprio objeto após a digitação.
        }
        public void ExibeProduto()
        {
            Console.WriteLine($"Código produto: {Codigo} \tNome: {this.Nome} \tPreco: {this.Preco:C2} \tEstoque atual: {this.Estoque}");
        }
    }
}