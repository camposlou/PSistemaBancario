using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSistemaBancario
{
    internal class ContaVIP : ContaCorrente
    {
        public ContaVIP(string cpfCnpj)
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
        public void SacarCVip(float valor)
        {
            if (this.Saldo - valor < -5000)
            {
                Console.WriteLine("Você não possui limite para realizar essa transação!");
                return;
            }
            else
            {
                Sacar(valor, this.DadoCliente);
                Console.WriteLine("Débito/Pagamento realizado com sucesso!");
                Console.WriteLine("Saldo atual " + (this.Saldo - valor));
            }
            Console.WriteLine("Tecle ENTER para continuar ");
            Console.ReadKey();
        }
        public void Transferir(string cpfCnpjDestino, float valorSolicitado)
        {
            SacarCVip(valorSolicitado);
            Depositar(valorSolicitado, cpfCnpjDestino);
        }
        public void RealizaPagamento(float valor)
        {
            SacarCVip(valor);
        }
        public void OperacoesCaixaEletr()
        {

            int operacao = MenuCaixaEletronico();
            switch (operacao)
            {
                case 1:

                    Console.WriteLine("Digite o valor do saque desejado: ");
                    float saque = float.Parse(Console.ReadLine());
                    SacarCVip(saque);
                    break;
                case 2:
                    Console.WriteLine("digite o valor que deseja depositar: ");
                    float deposito = float.Parse(Console.ReadLine());
                    Depositar(deposito, DadoCliente);
                    break;
                case 3:
                    Console.WriteLine("Digite o CPF do Destinatário: ");
                    string cpf = Console.ReadLine();
                    Console.WriteLine("Digite o valor que deseja transferir: ");
                    float transfere = float.Parse(Console.ReadLine());
                    Transferir(cpf, transfere);
                    break;
                case 4:
                    Console.WriteLine("Digite o valor do Boleto para pagamento: ");
                    float pagamento = float.Parse(Console.ReadLine());
                    RealizaPagamento(pagamento);
                    break;
                case 5:
                    //Extrato
                    break;
                case 6:

                    SolicitarEmprestimo(DadoCliente);
                    break;

            }
        }
    }
}
