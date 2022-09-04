using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSistemaBancario
{
    internal class ClientePJ : Pessoa
    {

        protected string RazaoSocial { get; set; }
        protected string CNPJ { get; set; }


        public ClientePJ()
        {

        }
        public override string ToString()
        {
            return "ID: " + IdPessoa + ";Nome: " + Nome + ";Telefone: " + Telefone + ";Data:" + Data + ";RazaoSocial: " + RazaoSocial +
                ";CNPJ: " + CNPJ + ";";
        }
        public string CadastrarPJ(int id)
        {
            IdPessoa = id;

            Console.WriteLine("Digite o nome fantasia da sua empresa");
            Nome = Console.ReadLine();

            Console.WriteLine("Digite o numero de telefone");
            Telefone = Console.ReadLine();

            Console.WriteLine("Digite a data de abertura do CNPJ");
            Data = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Razão Social");
            RazaoSocial = Console.ReadLine();

            Console.WriteLine("Digite o CNPJ da empresa");
            CNPJ = Console.ReadLine();

            return ToString();
        }
        public void SolicitarAberturaPJ()
        {

            int id = getID();

            string pessoajuridica = CadastrarPJ(id);
            Console.WriteLine();

            Endereco end = new Endereco();
            string endereco = end.CadastrarEndereco(id);
            Console.ReadKey();
            Console.WriteLine();

            try
            {
                StreamWriter arqPessoa = new StreamWriter($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\DBClientes\\Solicitacao\\{CNPJ}.txt");
                arqPessoa.WriteLine(pessoajuridica.ToString() + endereco.ToString());
                arqPessoa.Close();
                id++;
                SaveID(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            Console.WriteLine("Cadastro enviado para análise de aprovação");

        }
    }
}

