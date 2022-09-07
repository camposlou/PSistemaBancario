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
            DirectoryInfo dir = new DirectoryInfo("C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\ContasBanco");
            var arq = dir.GetFiles($"{cpfCnpj}.*");
            string[] solicita = System.IO.File.ReadAllLines($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\ContasBanco\\{cpfCnpj}.txt");
            string[] dados = new string[18];
            foreach (string dado in solicita)
                dados = dado.Split(';');

            if (solicita[0].Contains("Física"))
            {
                ClientePF pessoa = new(int.Parse(dados[0]), dados[2], dados[3], dados[4], DateTime.Parse(dados[5]), dados[6], float.Parse(dados[7]), (dados[8]));
                Pessoa = pessoa;
                Numconta = int.Parse(dados[0]);
                DadoCliente = dados[6];
            }
            else
            {
                ClientePJ empresa = new(int.Parse(dados[0]), dados[2], dados[3], dados[4], DateTime.Parse(dados[5]), dados[6], dados[7], float.Parse((dados[8])));
                Empresa = empresa;
                Numconta = int.Parse(dados[0]);
                DadoCliente = dados[6];
            }
            Endereco end = new(dados[9], dados[10], dados[11], dados[12], dados[13], dados[14], dados[15]);
            Saldo = float.Parse(dados[17]);
            Endereco = end;
        }
        public override string ToString()
        {
            return $"{Pessoa.ToString()}{Endereco.ToString()}Saldo = {Saldo};";
        }
        public void SacarCUniver(float valor)
        {
            if (this.Saldo - valor < -1000)
                Console.WriteLine("Não foi possível. Saldo Insufuciente! ");
            else
            {
                Sacar(valor, this.DadoCliente);
                Console.WriteLine("Transação realizada com sucesso!");

                Console.WriteLine("Saldo atual " + (this.Saldo - valor));
            }
            Console.WriteLine("Tecle ENTER para continuar ");
            Console.ReadKey();
        }
        public void Transferir(string cpfCnpjDestino, float valorSolicitado)
        {
            SacarCUniver(valorSolicitado);
            Depositar(valorSolicitado, cpfCnpjDestino);
        }
        public void RealizaPagamento(float valor)
        {
            SacarCUniver(valor);
        }
        public void OperacoesCaixaEletr()
        {
            
            int operacao = MenuCaixaEletronico();
            switch(operacao)
            {
                case 1:

                    Console.WriteLine("Digite o valor de saque desejado: ");
                    float saque = float.Parse(Console.ReadLine());
                    SacarCUniver(saque);
                    break;
                case 2:
                    Console.WriteLine("Digite o valor do depósito: ");
                    float deposito = float.Parse(Console.ReadLine());
                    Depositar(deposito, DadoCliente);
                    break;
                case 3:
                    Console.WriteLine("Digite [1] - CPF ou [2]- CNPJ do Destinatário: ");
                    int opc = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    if (opc == 1)
                    {
                        Console.WriteLine("\nCPF: ");
                        string cpf = Console.ReadLine();
                        Console.WriteLine("Digite o valor que deseja transferir: ");
                        float transfere = float.Parse(Console.ReadLine());
                        Transferir(cpf, transfere);
                    }
                    if (opc == 2)
                    {
                        Console.WriteLine("\nCNPJ: ");
                        string cnpj = Console.ReadLine();

                        Console.WriteLine("Digite o valor que deseja transferir: ");
                        float transfere = float.Parse(Console.ReadLine());
                        Transferir(cnpj, transfere);
                    }
                    break;
                case 4:
                    Console.WriteLine("Digite o valor do Boleto para pagamento: ");
                    float pagamento = float.Parse(Console.ReadLine());
                    RealizaPagamento(pagamento);
                    break;
                case 5:

                    GetExtrato(DadoCliente);
                    break;
                case 6:
                    
                    SolicitarEmprestimo(DadoCliente);
                    break;
            }
        }
    }
}
