﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSistemaBancario
{
    internal abstract class ContaCorrente
    {
        public int Numconta { get; set; }
        public float Saldo { get; set; }
        public ClientePF Pessoa { get; set; }
        public ClientePJ Empresa { get; set; }
        public Endereco Endereco { get; set; }
        public string DadoCliente { get; set; }

        public ContaCorrente()
        {

        }
        public virtual void Sacar(float valor, string cpfCnpj)
        {
            DirectoryInfo dir = new DirectoryInfo("C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\ContasBanco");
            var arq = dir.GetFiles($"{cpfCnpj}.*");
            string[] conta = System.IO.File.ReadAllLines($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\ContasBanco\\{cpfCnpj}.txt");
            string[] dados = new string[18];
            foreach (string dado in conta)
                dados = dado.Split(';');

            //Altera o saldo conforme o valor de saque
            float saldoContaDestino = float.Parse(dados[17]);
            saldoContaDestino -= valor;
            dados[17] = saldoContaDestino.ToString();

            //Sobrescreve o mesmo arquivo com o saldo atualizado
            System.IO.StreamWriter arqPessoa = new StreamWriter($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\ContasBanco\\{cpfCnpj}.txt");
            arqPessoa.WriteLine($"{dados[0]};{dados[1]};{dados[2]};{dados[3]};{dados[4]};{dados[5]};{dados[6]};{dados[7]};{dados[8]};{dados[9]};{dados[10]};" +
                $"{dados[11]};{dados[12]};{dados[13]};{dados[14]};{dados[15]};{dados[16]};{dados[17]};");
            arqPessoa.Close();
            Console.WriteLine();
        }
        public void Depositar(float valor, string cpfCnpj)
        {
            DirectoryInfo dir = new DirectoryInfo("C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\ContasBanco");
            var arq = dir.GetFiles($"{cpfCnpj}.*");
            string[] conta = System.IO.File.ReadAllLines($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\ContasBanco\\{cpfCnpj}.txt");
            string[] dados = new string[18];
            foreach (string dado in conta)
                dados = dado.Split(';');

            //Altera o saldo conforme o valor de depósito
            float saldoContaDestino = float.Parse(dados[17]);
            saldoContaDestino += valor;
            dados[17] = saldoContaDestino.ToString();
            Console.WriteLine(dados[17]);

            //Sobrescreve o mesmo arquivo com o saldo atualizado
            System.IO.StreamWriter arqPessoa = new StreamWriter($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\ContasBanco\\{cpfCnpj}.txt");
            arqPessoa.WriteLine($"{dados[0]};{dados[1]};{dados[2]};{dados[3]};{dados[4]};{dados[5]};{dados[6]};{dados[7]};{dados[8]};{dados[9]};{dados[10]};" +
                $"{dados[11]};{dados[12]};{dados[13]};{dados[14]};{dados[15]};{dados[16]};{dados[17]};");
            arqPessoa.Close();
        }
        public void SolicitarEmprestimo(string cpfCnpj)
        {
            float valorParcela;

            Console.Write("Digite o valor do empréstimo: R$");
            float valor = float.Parse(Console.ReadLine());

            Console.Write("Digite a quantidade de parcelas (máximo 36x): ");
            int parcelas = int.Parse(Console.ReadLine());

            if (parcelas > 10)
                valorParcela = valor * 1.1f / parcelas;

            else if (parcelas > 20)
                valorParcela = valor * 1.2f / parcelas;

            else if (parcelas > 30)
                valorParcela = valor * 1.3f / parcelas;

            else
                valorParcela = valor * 1.4f / parcelas;

            //Aguarda a confimação do usuário
            Console.WriteLine($"\nO valor do empréstimo será {parcelas} parcelas de R${valorParcela:N2}");
            Console.WriteLine("\nDESEJA ENVIAR A SOLICITAÇÃO?[S/N]: ");
            string envia = Console.ReadLine().ToLower();

            if (envia == "s")
            {
                //Envia os dados do solicitante e o valor para o diretório SolicitaçõesEmpréstimos para ser aprovado pelo cliente
                string[] solicitante = System.IO.File.ReadAllLines($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\ContasBanco\\{cpfCnpj}.txt");
                System.IO.StreamWriter arqPessoa = new StreamWriter($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\SolicitacoesEmprestimo\\{cpfCnpj}.txt");
                arqPessoa.WriteLine($"{solicitante[0]}{valor};");
                arqPessoa.Close();
            }
            else
            {
                Console.WriteLine("Solicitação cancelada!!!!");
            }
        }
        protected void AddExtrato(string cpfCnpj, string extrato)
        {
            try
            {
                string caminho = $"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\ImprimeExtratos\\{cpfCnpj}.txt";

                string texto = $"{extrato}\n";

                File.AppendAllText(caminho, texto);

            }
            catch(Exception ex)
            {
                Console.WriteLine($"Não foi possível salvar o extrato!! Contate o Suporte: Erro: {ex.Message}");
            }
            
        }
        public void GetExtrato(string cpfCnpj)
        {
            try
            {
                FileStream fs = File.OpenRead($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\ImprimeExtratos\\{cpfCnpj}.txt");

                byte[] b = new byte[1024];
                UTF8Encoding temp = new(true);

                Console.WriteLine("****************************** EXTRATO DA CONTA ***********************************");
                Console.WriteLine($"CPF/CNPJ: {DadoCliente}");

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(b));
                }
                Console.WriteLine("***********************************************************************************");
                Console.WriteLine($"\nSALDO ATUAL DA CONTA: R${Saldo:N2}");
                Console.WriteLine("***********************************************************************************");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Não há impressões disponíveis!! Erro: {ex.Message}");
                return;
            }
        }
        protected int MenuCaixaEletronico()
        {
            int opc;
            do
            {
                Console.Clear();
                Console.WriteLine("                                           >>> MENU CAIXA ELETRÔNICO <<<");
                Console.WriteLine("                                               1 - Realizar Saque ");
                Console.WriteLine("                                               2 - Realizar Depósito");
                Console.WriteLine("                                               3 - Realizar Tranferência");
                Console.WriteLine("                                               4 - Realizar Pagamentos");
                Console.WriteLine("                                               5 - Consultar Extrato");
                Console.WriteLine("                                               6 - Solicitar Empréstimo");
                Console.WriteLine("                                               0 - Sair");
                Console.Write("                                                   Opção: ");
                opc = int.Parse(Console.ReadLine());
                return opc;

            } while (opc != 0);
            Console.WriteLine("                                                          >>>FIM<<<");
            return 0;
        }
    }
}
