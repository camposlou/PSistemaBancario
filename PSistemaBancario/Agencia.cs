using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSistemaBancario
{
    internal class Agencia
    {
        public string NumAgencia { get; set; }
        public Atendente Atendente { get; set; }
        public Gerente Gerente { get; set; }

        public Agencia(string numAgencia, int funcionario)
        {
            NumAgencia = numAgencia;

            if (numAgencia == "1")
            {
                if (funcionario == 1)
                {
                    Console.WriteLine();
                    Atendente = new();
                    Atendente.Nome = "Henédio";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($" * Agência Mococa > Atendente Responsável: {Atendente.Nome} ");
                    Atendente.AbreConta();
                }
                else
                {
                    Console.WriteLine();
                    Gerente = new();
                    Gerente.Nome = "Newton";
                    Gerente.Senha = 1;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"Agência Mococa > Gerente Responsável: {Gerente.Nome} ");
                    Console.Write($"\n* {Gerente.Nome} Digite sua senha: ");
                    int senha = int.Parse(Console.ReadLine());
                    if (Gerente.Autentica(senha))
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Acesso liberado!!!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Gerente.AprovarConta();
                       
                    }
                }
            }

            if (numAgencia == "2")
            {
                if (funcionario == 1)
                {
                    Console.WriteLine();
                    Atendente = new();
                    Atendente.Nome = "Louise";
                    Console.WriteLine($" * Agência Araraquara > Atendente Responsável: {Atendente.Nome} ");
                    Atendente.AbreConta();
                }
                else
                {
                    Console.WriteLine();
                    Gerente = new();
                    Gerente.Nome = "Pestana";
                    Gerente.Senha = 2;
                    Console.Write($"\nAgência Araraquara > Gerente Responsável: {Gerente.Nome} ");
                    Console.WriteLine($"\n* {Gerente.Nome} Digite sua senha: ");
                    int senha = int.Parse(Console.ReadLine());
                    if (Gerente.Autentica(senha))
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Acesso liberado!!!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Gerente.AprovarConta();
                    }
                }
            }

            if (numAgencia == "3")
            {
                if (funcionario == 1)
                {
                    Console.WriteLine();
                    Atendente = new();
                    Atendente.Nome = "Moranguinho";
                    Console.WriteLine($" * Agência Muzambinho > Atendente Responsável: {Atendente.Nome}!!!");
                    Atendente.AbreConta();
                }
                else
                {
                    Console.WriteLine();
                    Gerente = new();
                    Gerente.Nome = "Papini";
                    Gerente.Senha = 3;
                    Console.Write($"\nAgência Muzambinho > Gerente Responsável: {Gerente.Nome} ");
                    Console.WriteLine($"\n* {Gerente.Nome} Digite sua senha: "); 
                    int senha = int.Parse(Console.ReadLine());
                    if (Gerente.Autentica(senha))
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Acesso liberado!!!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Gerente.AprovarConta();
                    }
                }
            }
        }
    }
}
