using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSistemaBancario
{
    internal class CCUniversitaria : ContaCorrente
    {
        public CCUniversitaria(string cpfCnpj)
        {
            //Busca o arquivo que tem o CPF/CNPJ recebido como parâmetro
            DirectoryInfo dir = new DirectoryInfo("C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\ContasBanco");
            var arq = dir.GetFiles($"{cpfCnpj}.*");
            string[] solicita = System.IO.File.ReadAllLines($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\ContasBanco\\{cpfCnpj}.txt");
            string[] dados = new string[18];
            foreach (string dado in solicita)
                dados = dado.Split(';');

            //Verifica se o arquivo é do tipo PF, caso seja ela cria um objeto PF com os dados do arquivo
            if (solicita[0].Contains("Física"))
                if (solicita[0].Contains("Física"))
            {
                ClientePF pessoa = new(int.Parse(dados[0]), dados[2], dados[3], dados[4], DateTime.Parse(dados[5]), dados[6], float.Parse(dados[7]), (dados[8]));
                Pessoa = pessoa;
                NumConta = int.Parse(dados[0]);
                DadoCliente = dados[6];
            }
            else
            {
                ClientePJ empresa = new(int.Parse(dados[0]), dados[2], dados[3], dados[4], DateTime.Parse(dados[5]), dados[6], dados[7], float.Parse((dados[8])));
                Empresa = empresa;
                NumConta = int.Parse(dados[0]);
                DadoCliente = dados[6];
            }
            //Cria o objeto do tipo endereço com os dados do arquivo
            Endereco end = new(dados[9], dados[10], dados[11], dados[12], dados[13], dados[14], dados[15]);
            Saldo = float.Parse(dados[17]);
            Endereco = end;
        }
        public override string ToString()
        {
            return $"{Pessoa.ToString()}{Endereco.ToString()}Saldo = {Saldo};";
        }
        public bool SacarCUniver(float valor)
        {
            //Verifica se o saldo ficar mais que R$ -1000,00 não permite efetuar o método
            if (this.Saldo - valor < -1000)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Não foi possível realizar o saque! SALDO INSUFICIENTE.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                return false;
            }
            else
            {
                Sacar(valor, this.DadoCliente);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Transação realizada com sucesso!");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Saldo atual " + (this.Saldo - valor));
                Console.ReadKey();
                return true;
            }
        }
        public void Transferir(string cpfCnpjDestino, float valorSolicitado)
        {
            if (SacarCUniver(valorSolicitado))
            {
                Console.WriteLine(cpfCnpjDestino);
                Depositar(valorSolicitado, cpfCnpjDestino);
                AddExtrato(DadoCliente, $"Tranferência para o CPF / CNPJ {cpfCnpjDestino}: {DateTime.Now} -------- R$ {valorSolicitado:N2}");
                Console.ReadKey();
            }
        }
        public void RealizarPagamento(float valor)
        {
            if(SacarCUniver(valor))
            AddExtrato(DadoCliente, $"Pagamento de boleto: {DateTime.Now} -------- R$ {valor:N2}");
            Console.ReadKey();

        }
        public void OperarCaixaEletro()
        {
            int operacao;
            do
            {
                operacao = MenuCaixaEletronico();
                switch (operacao)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(" * Digite o valor do saque desejado: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        float saque;
                        while (!float.TryParse(Console.ReadLine(), out saque))
                            Console.WriteLine(" * Digite somente números!");
                        if (SacarCUniver(saque))
                            AddExtrato(DadoCliente, $"SAQUE REALIZADO: {DateTime.Now} ---------- R${saque:N2}");
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(" * Digite o valor que deseja depositar: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        float deposito;
                        while (!float.TryParse(Console.ReadLine(), out deposito))
                            Console.WriteLine(" * Digite somente números!");
                        try
                        {
                            Depositar(deposito, DadoCliente);
                            AddExtrato(DadoCliente, $"DEPÓSITO EM CONTA: {DateTime.Now} ---------- R${deposito:N2}");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Não foi possível realizar o depósito na conta CPF/CNPJ: {DadoCliente}");
                        }
                        break;

                    case 3:
                        Console.WriteLine(" * Digite [1] - CPF ou [2]- CNPJ do Destinatário: ");
                        int opc = int.Parse(Console.ReadLine());
                        if (opc == 1)
                        {


                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(" * CPF: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            string cpf = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(" * Digite o valor que deseja transferir: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            float transfere;
                            while (!float.TryParse(Console.ReadLine(), out transfere))
                                Console.WriteLine(" * Digite somente números!");
                            Transferir(cpf, transfere);
                        }
                        if (opc == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(" * CNPJ: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            string cnpj = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(" * Digite o valor que deseja transferir: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            float transfere;
                            while (!float.TryParse(Console.ReadLine(), out transfere))
                                Console.WriteLine(" * Digite somente números!");
                            Transferir(cnpj, transfere);
                        }
                        break;

                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(" * Digite o valor do Boleto para pagamento: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        float pagamento;
                        while (!float.TryParse(Console.ReadLine(), out pagamento))
                            Console.WriteLine(" * Digite somente números!");
                        RealizarPagamento(pagamento);
                        break;

                    case 5:
                        GetExtrato(DadoCliente);
                        Console.ReadKey();
                        break;

                    case 6:
                        SolicitarEmprestimo(DadoCliente);
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
            } while (operacao != 0);

        }
    }
}
