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
                Console.WriteLine("Acesso Permitido");
                return true;
            }
            else
            {
                Console.WriteLine("Senha Inválida! Tente novamente");
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
                Console.WriteLine(" Não há solicitações no momento! ");
                return;
            }

            else
                Console.WriteLine($" Há {listasol.Count} pendentes! ");


            // Busca o arquivo no caminho definido
            string[] solicita = System.IO.File.ReadAllLines($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\DBClientes\\Analise\\{listasol.First()}");
            string[] busca;

            List<string> solicitacaoList = new();
            Console.WriteLine($"\nDados da Solicitação: ");

            // Laço para mostrar na tela e inserir os dados do cliente na lista
            foreach (string cont in solicita)
            {
                busca = cont.Split(';');

                for (int i = 0; i < busca.Length; i++)
                {
                    Console.WriteLine(busca[i]);
                    solicitacaoList.Add(busca[i]);
                }
                Console.WriteLine("Aprovar conta?[S/N]: ");
                string ler = Console.ReadLine().ToLower().Trim();

                //Condição para abrir o tipo de conta solicitado pelo atendente
                if (ler.Contains('s'))
                {
                    if (solicitacaoList.Contains("Tipo de conta: Conta Universitária"))
                    {
                        Console.WriteLine("Conta Universitaria criada con sucesso!!!!!!!");
                    }
                    else if (solicitacaoList.Contains("Tipo de conta: Conta Normal"))
                    {
                        Console.WriteLine("Conta Normal Criada com sucesso!!!!!!!!");
                    }
                    else
                    {
                        Console.WriteLine("Conta VIP Criada com sucesso!!!!!!!!");
                    }

                }

               
            }



        }
    }
}