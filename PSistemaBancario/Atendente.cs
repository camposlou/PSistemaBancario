using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSistemaBancario
{
    internal class Atendente : Funcionario
    {
        public void AcessoAtendente()
        {
            int agencia = 0;
           

            Console.WriteLine(">>>ACESSO ADMINISTRATIVO RESPONSÁVEL<<<");
            Console.WriteLine(" ♦ Digite o número da agência operante: [1], [2] OU [3]: ");
            agencia = int.Parse(Console.ReadLine());
            Console.WriteLine();
            if (agencia == 1)
            {
                Console.WriteLine(Nome = "Nome do funcionário: Louise");
                Console.WriteLine(Cargo = "Cargo: Atendente");
                Console.WriteLine();

            }
            else if (agencia == 2)
            {
                Console.WriteLine(Nome = "Nome do funcionário: Talia ");
                Console.WriteLine(Cargo = "Cargo: Atendente ");
                Console.WriteLine();
            }
            else if (agencia == 3)
            {
                Console.WriteLine(Nome = "Nome do funcionário: Weslen ");
                Console.WriteLine(Cargo = "Cargo: Atendente ");
                Console.WriteLine();
            }
            //else if (agencia != 1 && agencia != 2 && agencia != 3)
            //{
               // Console.WriteLine("AGÊNCIA INVÁLIDA. TENTE NOVAMENTE");
            //}
        }

        public void AbreConta()
        {
            //Verifica a quantidade de solicitações
            List<string> listasol = new List<string>();
            DirectoryInfo dir = new DirectoryInfo("C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\DBClientes\\Solicitacao");
            foreach (var file in dir.GetFiles())
            {
                listasol.Add(file.Name);
            }

            //Verifica caso não tenha solicitação no diretório ele sai do método
            if (listasol.Count == 0)
            {
                Console.WriteLine(" ♦ Não há solicitações no momento!!!");
                Console.WriteLine();
                return;
            }
            else
                Console.WriteLine($" ♦ Há [{listasol.Count}] solicitações pendentes!");
                Console.WriteLine();
            
            //Busca o arquivo no caminho definido
            string[] solicita = System.IO.File.ReadAllLines($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\DBClientes\\Solicitacao\\{listasol.First()}");
            string[] solicitacao;

            List<string> solicitacaoList = new List<string>();

            Console.WriteLine($"\n ♦ Dados da Solicitação: ");

            //Laço para mostrar na tela e inserir os dados do cliente na lista
            foreach (string cont in solicita)
            {
                solicitacao = cont.Split(';');

                for (int i = 0; i < solicitacao.Length; i++)
                {
                    Console.WriteLine(solicitacao[i]);
                    solicitacaoList.Add(solicitacao[i]);
                }

            }
            Console.WriteLine(" ♦ Criar conta para o cliente?[S/N]: ");
            string ler = Console.ReadLine().ToLower().Trim();

            if (ler.Contains("s"))
            {
                Console.WriteLine(" ♦ Digite o tipo de conta:\n\n1 - Para Conta Universitária\n2 - Para Conta Normal\n3 - Para conta VIP");
                int tipo = int.Parse(Console.ReadLine());

                //Swith pra inserir o tipo de conta que o atendente escolher e depois envia o arquivo para o diretório AguardAprv para ser aprovado pelo Gerente
                switch (tipo)
                {
                    case 1:
                        System.IO.StreamWriter arqPessoa = new StreamWriter($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\DBClientes\\Solicitacao\\{listasol.First()}");
                        arqPessoa.WriteLine($"{solicita[0]}Tipo de conta: Conta Universitária;");
                        arqPessoa.Close();
                        File.Move($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\DBClientes\\Solicitacao\\{listasol.First()}",
                                    $"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\DBClientes\\Analise\\{listasol.First()}");
                        break;

                    case 2:
                        System.IO.StreamWriter arqPessoa1 = new StreamWriter($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\DBClientes\\Solicitacao\\{listasol.First()}");
                        arqPessoa1.WriteLine($"{solicita[0]}Tipo de conta: Conta Normal;");
                        arqPessoa1.Close();
                        File.Move($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\DBClientes\\Solicitacao\\{listasol.First()}",
                                    $"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\DBClientes\\Analise\\{listasol.First()}");
                        break;

                    case 3:
                        System.IO.StreamWriter arqPessoa2 = new StreamWriter($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\DBClientes\\Solicitacao\\{listasol.First()}");
                        arqPessoa2.WriteLine($"{solicita[0]}Tipo de conta: Conta VIP;");
                        arqPessoa2.Close();
                        File.Move($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\DBClientes\\Solicitacao\\{listasol.First()}",
                                    $"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\DBClientes\\Analise\\{listasol.First()}");
                        break;



                }
                Console.WriteLine(" ♦ Cadastro enviado para análise de aprovação");
                Console.WriteLine("Pressione ENTER para retornar ao Menu Principal");



            }



        }
    }
}

