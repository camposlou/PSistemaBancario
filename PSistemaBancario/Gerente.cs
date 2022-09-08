using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSistemaBancario
{
    internal class Gerente : Funcionario
    {
        public int Senha { get; set; }

        public Gerente()
        {
            
        }
        public bool Autentica(int senha)
        {
            if (this.Senha == senha)
            {
                return true;
            }
            else
            {
                Console.WriteLine("\nSenha Inválida! Tente novamente");
                return false;
            }
        }
        public void AprovarConta()
        {
            //Verifica a quantidade de solicitações
            List<string> listasol = new List<string>();
            System.IO.DirectoryInfo dir = new DirectoryInfo("C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\DBClientes\\Analise");

            foreach (var file in dir.GetFiles())
            {
                listasol.Add(file.Name);
            }

            //Verifica caso não tenha solicitação no diretório ele sai do método
            if (listasol.Count == 0)
            {
                Console.WriteLine("\nNão há solicitações no momento! ");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Pressione ENTER para retornar ao Menu Principal");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            else
            
            Console.WriteLine($"Há {listasol.Count} solicitações pendentes! ");
            // Busca o arquivo no caminho definido
            string[] solicita = System.IO.File.ReadAllLines($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\DBClientes\\Analise\\{listasol.First()}");
            string[] busca;

            List<string> solicitacaoList = new();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\nDados da Solicitação: ");
            Console.ForegroundColor = ConsoleColor.White;

            // Laço para mostrar na tela e inserir os dados do cliente na lista
            foreach (string cont in solicita)
            {
                busca = cont.Split(';');

                for (int i = 0; i < busca.Length; i++)
                {
                    Console.WriteLine(busca[i]);
                    solicitacaoList.Add(busca[i]);
                }
                Console.WriteLine(listasol.First());
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" * Aprovar conta?[S/N]: ");
                Console.ForegroundColor = ConsoleColor.White;
                string ler = Console.ReadLine().ToLower().Trim();

                //Condição para aprovar a conta solicitada pelo atendente
                if (ler.Contains('s'))
                {
                    System.IO.StreamWriter arqPessoa = new StreamWriter($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\DBClientes\\Analise\\{listasol.First()}");
                    arqPessoa.WriteLine($"{solicita[0]}0;");
                    arqPessoa.Close();
                    File.Move($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\DBClientes\\Analise\\{listasol.First()}",
                                $"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\ContasBanco\\{listasol.First()}");

                }
                else
                    return;

            }
        }
        public void AprovarEmprestimo()
        {
            //Verifica a quantidade de solicitações
            List<string> listasol = new List<string>();
            System.IO.DirectoryInfo dir = new DirectoryInfo("C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\SolicitacoesEmprestimo");
            foreach (var file in dir.GetFiles())
            {
                listasol.Add(file.Name);
            }

            //Verifica caso não tenha solicitação no diretório ele sai do método
            if (listasol.Count == 0)
            {
                Console.WriteLine("\nNão há solicitações no momento!");
                return;
            }

            else
                Console.WriteLine($"Há {listasol.Count} solicitações  pendentes!");

            //Busca o arquivo no caminho definido
            string[] solicita = System.IO.File.ReadAllLines($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\SolicitacoesEmprestimo\\{listasol.First()}");
            string[] solicitacao = new string[19];

            List<string> solicitacaoList = new();

            Console.WriteLine($"\nDados da Solicitação: ");

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
            Console.WriteLine(listasol.First());
            Console.WriteLine(" * Aprovar empréstimo?[S/N]: ");
            string ler = Console.ReadLine().ToLower().Trim();

            //Condição para aprovar o empréstimo
            if (ler.Contains('s'))
            {
                //Busca o arquivo com os dados do solicitante
                DirectoryInfo dirEmp = new DirectoryInfo("C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\ContasBanco");
                var arq = dir.GetFiles($"{solicitacao[6]}.*");
                string[] conta = System.IO.File.ReadAllLines($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\SolicitacoesEmprestimo\\{solicitacao[6]}.txt");
                string[] dados = new string[18];
                foreach (string dado in conta)
                    dados = dado.Split(';');

                //Altera o saldo conforme o valor do empréstimo
                float saldoContaDestino = float.Parse(dados[17]);
                Console.WriteLine(dados[17]);
                Console.ReadKey();
                float valor = float.Parse(dados[18]);
                saldoContaDestino += valor;
                dados[17] = saldoContaDestino.ToString();

                //Sobrescreve o mesmo arquivo com o saldo atualizado
                System.IO.StreamWriter arqPessoa = new StreamWriter($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\ContasBanco\\{solicitacao[6]}.txt");
                arqPessoa.WriteLine($"{dados[0]};{dados[1]};{dados[2]};{dados[3]};{dados[4]};{dados[5]};{dados[6]};{dados[7]};{dados[8]};{dados[9]};{dados[10]};" +
                    $"{dados[11]};{dados[12]};{dados[13]};{dados[14]};{dados[15]};{dados[16]};{dados[17]};");
                arqPessoa.Close();

            }
            else
                return;

        }
    }
}
