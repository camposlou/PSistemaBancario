using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSistemaBancario
{
    internal class ClientePF : Pessoa
    {
        protected string CPF { get; set; }
        protected float Renda { get; set; }
        protected char Estudante { get; set; }
        protected string RA { get; set; }  


        public ClientePF()
        {

        }
        public override string ToString()
        {
            return "ID: " + IdPessoa + ";Nome: " + Nome + ";Telefone: " + Telefone + ";Data: "+Data+
                ";CPF: " + CPF + ";Renda: " + Renda+ ";RA: " + RA + ";";
        }

        public string CadastrarPF(int id)
        {
            IdPessoa = id;

            Console.WriteLine("Informe seu Nome completo:  ");
            Nome = Console.ReadLine();

            Console.WriteLine("Informe seu número de Telefone: ");
            Telefone = Console.ReadLine();

            Console.WriteLine("Informe a Data de nascimento [dd/mm/aa]: ");
            Data = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Informe o CPF: ");
            CPF = (Console.ReadLine());

            Console.WriteLine("Informe sua Renda: ");
            Renda = float.Parse(Console.ReadLine());

            Console.WriteLine("O cliente é Estudante s/n: ");
            Estudante = char.Parse(Console.ReadLine());

            if (Estudante == 's')
            {
                Console.WriteLine("Digite seu RA: ");
                RA = Console.ReadLine();

                 Estudante = 's';
            }
            else
            {
                Estudante = 'n';
            }
            
            return ToString();
        }

        public void SolicitarAberturaPF()
        {

            int id = getID();

            
            string pessoafisica = CadastrarPF(id);
            Console.WriteLine();

            Endereco end = new Endereco();
            string endereco = end.CadastrarEndereco(id);
            Console.ReadKey();
            Console.WriteLine();
            
            
            
            

            try
            {
                StreamWriter arqPessoa = new StreamWriter($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\DBClientes\\Solicitacao\\{CPF}.txt");
                arqPessoa.WriteLine(pessoafisica.ToString() + endereco.ToString());
                arqPessoa.Close();
                id++;
                SaveID(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: "+ ex.Message);
            }
            Console.WriteLine("Cadastro enviado para análise de aprovação");


        }

    }
}
