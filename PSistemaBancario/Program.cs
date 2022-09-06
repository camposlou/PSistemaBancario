using System;
using System.IO;
using PSistemaBancario;

namespace PSistemaBancario
{
    internal class Program
    {
        static void MenuPrincipal()
        {
            int opcMenu;

            do
            {
                Console.Clear();
                Console.WriteLine("\n♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ BEM VINDO AO BANCO MORANGÃO ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥  ");
                Console.WriteLine();
                Console.WriteLine(">>> MENU PRINCIPAL <<<");
                Console.WriteLine("1 - Não sou cliente ");
                Console.WriteLine("2 - Já sou cliente ");
                Console.WriteLine("3 - Acesso somente para funcionários ");
                Console.WriteLine("0 - Sair");
                Console.Write("Opção: ");
                opcMenu = int.Parse(Console.ReadLine());
                switch (opcMenu)
                {
                    case 1:
                        char opc;
                        Console.WriteLine(" ♦ Deseja se Cadastrar? Digite [s/n]");
                        opc = char.Parse(Console.ReadLine());
                        if (opc == 's')
                        {
                            ClienteNovo();
                        }
                        else
                        {
                            MenuPrincipal();
                        }
                        break;
                    case 2:
                        Console.WriteLine(" ♦ Digite [s] - Operações da Conta / [n] - Retornar para o Menu Principal");
                        opc = char.Parse(Console.ReadLine());

                        if (opc == 's')
                        {
                            Conta();
                            
                        }
                        else 
                        {
                            MenuPrincipal();
                        }
                        break;
                    case 3:
                        int funcopc;
                        Console.WriteLine(" ♦ Digite [1] - Atendente / [2] - Gerente");
                        funcopc = int.Parse(Console.ReadLine());
                        Console.Clear();
                        if (funcopc == 1)
                        {
                            Atendente atendente = new Atendente();
                            atendente.AcessoAtendente();
                            Console.ReadKey();

                            atendente.AbreConta();
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else if (funcopc == 2)
                        {
                            Gerente gerente;
                            bool senha;
                            do
                            {
                                Console.WriteLine(">>>ACESSO ADMINISTRATIVO RESPONSÁVEL<<<");
                                Console.WriteLine(" ♦ Digite sua senha de acesso: ");
                                int acesso = int.Parse(Console.ReadLine());
                                gerente = new Gerente();
                                senha = gerente.Autentica(acesso);

                            } while (!senha);

                            gerente.AprovaConta();
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                }
            } while (opcMenu != 0);
            Console.WriteLine(">>>FIM<<<");

            static void ClienteNovo()
            {
                int opc = 0;


                Console.WriteLine();
                Console.Write("\nQUE BOM QUE VOCÊ ESTÁ AQUI! ENVIE SUA SOLICITAÇÃO DE CADASTRO ABAIXO:");
                Console.WriteLine();
                Console.Write("\n ♦ Escolha a opção: [Pessoa fisica: 1]  [Pessoa Juridica: 2]: ");
                opc = int.Parse(Console.ReadLine());
                Console.WriteLine();
                if (opc == 1)
                {
                    Console.WriteLine(">>>CADASTRO PESSOA FÍSICA: DADOS PESSOAIS<<< ");
                    ClientePF pf1 = new ClientePF();
                    pf1.SolicitarAberturaPF();
                    Console.WriteLine("CADASTRO REALIZADO COM SUCESSO! AGUARDANDO ANÁLISE DE APROVAÇÃO!");
                    Console.WriteLine("Pressione ENTER para retornar ao Menu Principal");
                    Console.WriteLine();
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine(">>>CADASTRO PESSOA JURIDICA: DADOS DA EMPRESA<<< ");
                    ClientePJ pj1 = new ClientePJ();
                    pj1.SolicitarAberturaPJ();
                    Console.WriteLine("CADASTRO REALIZADO COM SUCESSO! AGUARDE ANÁLISE DE APROVAÇÃO");
                    Console.WriteLine("Pressione ENTER para retornar ao Menu Principal");
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.Clear();

                    MenuPrincipal();
                }
            }
            static void Conta()
            {
                Console.WriteLine("Digite seu CPF ou CNPJ");
                string cpfCnpj = Console.ReadLine();
                DirectoryInfo dir = new DirectoryInfo("C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\ContasBanco");
                var arq = dir.GetFiles($"{cpfCnpj}.*");
                string[] solicita = System.IO.File.ReadAllLines($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\ContasBanco\\{cpfCnpj}.txt");
                string[] dados = new string[18];
                foreach (string dado in solicita)
                    dados = dado.Split(';');
                if (dados[16].Contains("Conta Normal;"))
                {

                    ContaNormal conta = new ContaNormal(cpfCnpj);
                    conta.OperacoesCaixaEletr();
                }
                else if (dados[16].Contains("Conta VIP;"))
                {
                    ContaVIP conta = new ContaVIP(cpfCnpj);
                    conta.OperacoesCaixaEletr();
                }
                else
                {
                    CCUniversitaria conta = new CCUniversitaria(cpfCnpj);
                    conta.OperacoesCaixaEletr();
                    return;

                }
                
            }
            
        }
        static void Main(string[] args)
        {
           MenuPrincipal();
           
        }
    }
}







