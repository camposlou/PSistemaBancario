using System;
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
                            opc = 's';
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
                            MenuCaixaEletronico();
                            opc = 's';
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
                    default: break;
                }
               
            } while (opcMenu != 0);
            Console.WriteLine(">>>FIM<<<");


        }
        static void MenuCaixaEletronico()
        {
            int opc;
            do
            {
                Console.Clear();
                Console.WriteLine(">>> MENU <<<");
                Console.WriteLine("1 - Realizar Saque ");
                Console.WriteLine("2 - Realizar Depósito");
                Console.WriteLine("3 - Realizar Tranferência");
                Console.WriteLine("4 - Realizar Pagamentos");
                Console.WriteLine("5 - Consultar Saldo");
                Console.WriteLine("6 - Consultar Extrato");
                Console.WriteLine("7 - Solicitar Empréstimo");
                Console.WriteLine("0 - Sair");
                Console.Write("Opção: ");
                opc = int.Parse(Console.ReadLine());


            } while (opc != 0);
            {
                Console.WriteLine(">>>FIM<<<");
            }
        }
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

        static void Main(string[] args)
        {
            MenuPrincipal();

        }
    }
}








