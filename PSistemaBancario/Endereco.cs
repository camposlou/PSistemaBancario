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
        protected string UF { get; set; }
        protected int IdPessoa { get; set; }

        public Endereco()
        {

        }


        public override string ToString()
        {
            return "IdPessoa: " + IdPessoa + ";Logradouro: " + Logradouro + ";Numero: " + Numero + ";Complemento: " + Complemento + ";Bairro: " + Bairro +
                ";CEP: " + CEP + ";Cidade: " + Cidade + ";Estado: " + UF+ ";";

        }
        public string CadastrarEndereco(int id)
        {
            Console.WriteLine("CADASTRE SEU ENDEREÇO");
            Console.WriteLine();
            Console.WriteLine("Digite a quantidade de endereço que deseja cadastrar: ");
            int qtd_endereco = int.Parse(Console.ReadLine());
            Endereco[] endereco = new Endereco[qtd_endereco];

            for (int i = 0; i < qtd_endereco; i++)
            {
                Console.WriteLine("\nEndereço: "+(i + 1)+ " ; ");

                Console.WriteLine("Informe o nome da Rua/Avenida: ");
                Logradouro = Console.ReadLine();

                Console.WriteLine("Informe o Número");
                Numero = Console.ReadLine();

                Console.WriteLine("Informe o Complemento");
                Complemento = Console.ReadLine();

                Console.WriteLine("Informe o Bairro");
                Bairro = Console.ReadLine();

                Console.WriteLine("Informe o Cep");
                CEP = Console.ReadLine();

                Console.WriteLine("Informe a Cidade");
                Cidade = Console.ReadLine();

                Console.WriteLine("Informe o Estado");
                UF = Console.ReadLine();
                
            }
            return ToString();

            

                
        }
    }
}
