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
        private string RazaoSocial { get; set; }
        private string CNPJ { get; set; }
        private float Renda { get; set; }


        public ClientePJ()
        {

        }
        public ClientePJ(int id, string agencia, string nome, string telefone, DateTime data, string razao, string cnpj, float renda)
        {
            IDPessoa = id;
            Agencia = agencia; 
            Nome = nome;
            Telefone = telefone;
            Data = data;
            RazaoSocial = razao;
            CNPJ = cnpj;
            Renda = renda;
        }
        public override string ToString()
        {
            return IDPessoa + ";Conta Jurídica;Agência: " + Agencia + ";Nome: " + Nome + ";Telefone: " + Telefone + ";Data de Abertura CNPJ: " + Data.ToShortDateString() + 
                ";Razão Social: " + RazaoSocial + ";CNPJ: " + CNPJ + ";Renda: " + Renda + ";";
        }
        private string DadosClientePJ()
        {
            return $"{IDPessoa};Conta Jurídica;{Agencia};{Nome};{Telefone};{Data.ToShortDateString()};{CNPJ};{RazaoSocial};{Renda};";
        }

        public string CadastrarPJ(int id)
        {
            IDPessoa = id;
            Console.Write(" * Digite o Número da agência[1 - Mococa / 2 - Araraquara / 3 - Muzambinho]: ");
            Agencia = Console.ReadLine();

            Console.Write(" * Digite o nome fantasia da sua empresa: ");
            Nome = Console.ReadLine();

            Console.Write(" * Digite o numero de telefone: ");
            Telefone = Console.ReadLine();

            Console.Write(" * Digite a data de abertura do CNPJ: ");
            Data = DateTime.Parse(Console.ReadLine());

            Console.Write(" * Digite a Razão Social: ");
            RazaoSocial = Console.ReadLine();

            Console.Write(" * Digite o CNPJ da empresa: ");
            CNPJ = Console.ReadLine();

            return DadosClientePJ();
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
            

        }
    }
}

