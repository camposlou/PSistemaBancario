using System;
using System.IO;
using System.Linq.Expressions;
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
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ BEM VINDO AO BANCO MORANGÃO ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ♥ ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.ForegroundColor= ConsoleColor.DarkYellow;
                Console.WriteLine("                                         >>>>>>>>>>>>   MENU   <<<<<<<<<<<<");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                         1 - Não sou cliente");
                Console.WriteLine("                                         2 - Já sou cliente");
                Console.WriteLine("                                         3 - Acesso RESTRITO para Bancários");
                Console.WriteLine("                                         0 - Sair");
                Console.Write("                                         Opção: ");
                opcMenu = int.Parse(Console.ReadLine());
                
                switch (opcMenu)
                {
                    case 1:
                        int opc;
                        do
                        {
                            Console.WriteLine(" * Deseja se Cadastrar? Digite [1 - SIM] , [2 - NÃO]");
                            opc = int.Parse(Console.ReadLine());
                            if (opc == 0)
                                return;
                        } while (opc != 1 && opc != 2);
                        if (opc == 1)
                        {
                            ClienteNovo();
                        }
                        else 
                            MenuPrincipal();
                        
                        break;
                    case 2:
                        int opcCliente;
                        do
                        {
                            Console.WriteLine(" * Digite [1 - Operações da Conta] ,  [2 - Retornar ao Menu Principal]");
                            opcCliente = int.Parse(Console.ReadLine());
                            if (opcCliente == 0)
                                return;
                        }while (opcCliente != 1 && opcCliente != 2);
                        if (opcCliente == 1)
                        {
                            Conta();
                        }
                        else
                        {
                            MenuPrincipal();
                        }
                        break;
                    case 3:
                        int opcfunc;
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(" * Digite [1] - Atendente , [2] - Gerente e [0 - Retorna ao Menu Pricipal]");
                            Console.ForegroundColor = ConsoleColor.White;
                            opcfunc = int.Parse(Console.ReadLine());
                            
                        }while (opcfunc != 1 && opcfunc != 2);
                        Console.WriteLine();
                        do
                        {
                            Console.Write(" * Digite o Número da agência[1 - Mococa / 2 - Araraquara / 3 - Muzambinho] ");
                            string ag = Console.ReadLine();
                            new Agencia(ag, opcfunc);
                                
                        } while (opcfunc != 1 && opcfunc != 2 && opcfunc !=3);
                        Console.ReadKey();
                        break;
                }
            } while (opcMenu != 0);
            Console.WriteLine();
            Console.WriteLine("                                                    >>>FIM<<<");
           


            static void ClienteNovo()
            {
                int opc;

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("\n                                           QUE BOM QUE VOCÊ ESTÁ AQUI!!!!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nENVIE SUA SOLICITAÇÃO DE CADASTRO ABAIXO:");
                do
                {
                    Console.Write("\n * Escolha a opção: [Pessoa fisica: 1]  [Pessoa Juridica: 2]  [Sair: 0]: ");
                    opc = int.Parse(Console.ReadLine());
                    if(opc != 1 && opc != 2)
                    Console.WriteLine("Opção Inválida");
                    if (opc == 0)
                        return;

                } while(opc != 1 && opc!=2);  
                Console.WriteLine();
                if (opc == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("                                   >>>CADASTRO PESSOA FÍSICA: DADOS PESSOAIS<<< ");
                    Console.ForegroundColor = ConsoleColor.White;
                    ClientePF pf1 = new ClientePF();
                    pf1.SolicitarAberturaPF();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("                          CADASTRO REALIZADO COM SUCESSO! AGUARDANDO ANÁLISE DE APROVAÇÃO!");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("                                    Pressione ENTER para retornar ao Menu Principal");
                    Console.WriteLine();
                    Console.ReadKey();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("                                   >>>CADASTRO PESSOA JURIDICA: DADOS DA EMPRESA<<< ");
                    Console.ForegroundColor = ConsoleColor.White;
                    ClientePJ pj1 = new ClientePJ();
                    pj1.SolicitarAberturaPJ();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("                          CADASTRO REALIZADO COM SUCESSO! AGUARDANDO ANÁLISE DE APROVAÇÃO!");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("                                    Pressione ENTER para retornar ao Menu Principal");
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.Clear();

                    MenuPrincipal();
                }
            }
            static void Conta()
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(" * Digite seu CPF ou CNPJ");
                    Console.ForegroundColor = ConsoleColor.White;
                    string cpfCnpj = Console.ReadLine();
                    DirectoryInfo dir = new DirectoryInfo("C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\ContasBanco");
                    var arq = dir.GetFiles($"{cpfCnpj}.*");
                    string[] solicita = System.IO.File.ReadAllLines($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\ContasBanco\\{cpfCnpj}.txt");
                    string[] dados = new string[18];
                    foreach (string dado in solicita)
                        dados = dado.Split(';');
                    
                    if (dados[16].Contains("Normal"))
                    {
                        ContaNormal conta = new ContaNormal(cpfCnpj);
                        conta.OperarCaixaEletro();
                    }
                    else if (dados[16].Contains("VIP"))
                    {
                        ContaVIP conta = new ContaVIP(cpfCnpj);
                        conta.OperarCaixaEletro();
                    }
                    else if (dados[16].Contains("Universitária"))
                    {
                        CCUniversitaria conta = new CCUniversitaria(cpfCnpj);
                        conta.OperarCaixaEletro();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nConta não encontrada! \nErro: {ex.Message}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Pressione ENTER para retornar ao MENU");
                    Console.ReadKey();
                }
                
            }
        }
        static void Main(string[] args)
        {
           MenuPrincipal();
           
        }
    }
}







