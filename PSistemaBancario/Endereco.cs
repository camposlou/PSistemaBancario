using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSistemaBancario
{
    internal class Endereco
    {
        protected string Logradouro { get; set; }
        protected string Numero { get; set; }
        protected string Complemento { get; set; }
        protected string Bairro { get; set; }
        protected string CEP { get; set; }
        protected string Cidade { get; set; }
        protected string Estado { get; set; }
        protected int IDPessoa { get; set; }

        public Endereco()
        {

        }
        public Endereco(string logradouro, string numero, string complemento, string bairro, string cep, string cidade, string estado)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            CEP = cep;
            Cidade = cidade;
            Estado = estado;
        }
        public override string ToString()
        {
            return "IdPessoa: " + IDPessoa + ";Logradouro: " + Logradouro + ";Numero: " + Numero + ";Complemento: " + Complemento + ";Bairro: " + Bairro +
                ";CEP: " + CEP + ";Cidade: " + Cidade + ";Estado: " + Estado+ ";";

        }
       public string DadosEnd()
        {
            return $" {Logradouro};{Numero};{Complemento};{Bairro};{CEP};{Cidade};{Estado};";
        }
        public string CadastrarEndereco(int id)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("                                            >>>CADASTRE SEU ENDEREÇO<<<");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine(" * Digite a quantidade de endereço que deseja cadastrar: ");
            int qtd_endereco = int.Parse(Console.ReadLine());
            Endereco[] endereco = new Endereco[qtd_endereco];
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < qtd_endereco; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("\nEndereço: "+(i + 1)+ ";");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.Write(" * Informe o nome da Avenida/Rua: ");
                Logradouro = Console.ReadLine();
                Console.Write(" * Informe o Número: ");
                Numero = Console.ReadLine();
                Console.Write(" * Informe o Complemento: ");
                Complemento = Console.ReadLine();
                Console.Write(" * Informe o Bairro: ");
                Bairro = Console.ReadLine();
                Console.Write(" * Informe o Cep: ");
                CEP = Console.ReadLine();
                Console.Write(" * Informe a Cidade: ");
                Cidade = Console.ReadLine();
                Console.Write(" * Informe o Estado: ");
                Estado = Console.ReadLine();
                
            }
            return DadosEnd();
        }
    }
}
