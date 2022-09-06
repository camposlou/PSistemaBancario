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
        protected int IDPessoa { get; set; }
        private int Senha { get; set; }

        public Gerente()
        {
            this.Senha = 2222;
        }
        //Método para Verificar a senha do Gerente
        public bool Autentica(int senha)
        {
            if (this.Senha == senha)
            {
                Console.WriteLine(" ♦ Acesso Permitido");
                return true;
            }
            else
            {
                Console.WriteLine(" ♦ Senha Inválida! Tente novamente");
                return false;
            }
        }
        public void AprovaConta()
        {
            List<string> listasol = new List<string>();
            System.IO.DirectoryInfo dir = new DirectoryInfo("C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\DBClientes\\Analise");

            foreach (var file in dir.GetFiles())

            {
                listasol.Add(file.Name);
            }

            // Verifica caso não tenha pedido no pasta ele sai do método
            if (listasol.Count == 0)
            {
                Console.WriteLine(" ♦ Não há solicitações no momento! ");
                Console.WriteLine("Pressione ENTER para retornar ao Menu Principal");
                return;
            }
            else
                Console.WriteLine($" ♦ Há {listasol.Count} solicitações pendentes! ");


            // Busca o arquivo no caminho definido
            string[] solicita = System.IO.File.ReadAllLines($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\DBClientes\\Analise\\{listasol.First()}");
            string[] busca;

            List<string> solicitacaoList = new();
            Console.WriteLine($"\n ♦ Dados da Solicitação: ");

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
                Console.WriteLine(" ♦ Aprovar conta?[S/N]: ");
                string ler = Console.ReadLine().ToLower().Trim();

                //Condição para abrir o tipo de conta solicitado pelo atendente
                if (ler.Contains('s'))
                {
                    System.IO.StreamWriter arqPessoa = new StreamWriter($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\DBClientes\\Analise\\{listasol.First()}");
                    arqPessoa.WriteLine($"{solicita[0]}0;");
                    arqPessoa.Close();
                    File.Move($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\DBClientes\\Analise\\{listasol.First()}",
                                $"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\ContasBanco\\{listasol.First()}");

                }

            }
        }
    }
}
