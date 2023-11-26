using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoHerancaComposicaoVenda
{
    public class Produto
    {
        public long Codigo { get; set; }
        public string Nome { get; set; } 
        public double Preco { get; set; } 
        public int Estoque { get; set; }
        public Produto CadastrarProdutos()
        {
            Console.WriteLine("Informe o código: ");
            this.Codigo = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Informe o nome: ");
            this.Nome = Console.ReadLine();
            
            Console.WriteLine("Informe o preço: ");
            this.Preco = Convert.ToDouble(Console.ReadLine());
            
            Console.WriteLine("Informe o estoque: ");
            this.Estoque = Convert.ToInt32(Console.ReadLine());
            return this; //representa o próprio objeto após a digitação.
        }
        public void ExibeProduto()
        {
            Console.WriteLine($"Código produto: {this.Codigo}");
            Console.WriteLine($"Nome: {this.Nome}");
            Console.WriteLine($"Preco: {this.Preco:C2}");
            Console.WriteLine($"Estoque: {this.Estoque}");
        }
    }
}