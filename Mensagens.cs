using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoHerancaComposicaoVenda
{
    public class Mensagens
    {
        public void Sucesso(string texto)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(texto);
            Console.ResetColor();
        }
        public void Amarelo(string texto)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(texto);
            Console.ResetColor();
        }
        public void Erro(string texto)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(texto);
            Console.ResetColor();
        }
        public void Primaria(string texto)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(texto);
            Console.ResetColor();
        }
        public void Secondaria(string texto)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(texto);
            Console.ResetColor();
        }
        public void Rosa(string texto)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(texto);
            Console.ResetColor();
        }
        public void MensagemDinamica(bool statusOpcao, string texto)
        {
            if (statusOpcao)
                this.Sucesso(texto);
            else
                this.Erro(texto);
        }

    }
}