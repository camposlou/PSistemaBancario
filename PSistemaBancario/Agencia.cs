using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSistemaBancario
{
    internal class Agencia
    {
        protected  string Numero { get; set; }
        protected string Cidade { get; set; }

        public void NumAgencia()
        {
            int agencia = 0;
            Console.WriteLine(">>>AGÊNCIA<<<");
            do
            {
                Console.WriteLine(" ♦ Selecione Agência: [ 1 - Araraquara ], [ 2 - Taquaritinga ] OU [ 3 - Mococa ]: ");
                agencia = int.Parse(Console.ReadLine());
                Console.WriteLine();
                if (agencia == 1)
                {
                    Console.WriteLine(Numero = "Numero da Agência: 0000  ");
                    Console.WriteLine(Cidade = "Cidade: Araraquara ");
                    Console.WriteLine();

                }
                else if (agencia == 2)
                {
                    Console.WriteLine(Numero = "Numero da Agência: 0001  ");
                    Console.WriteLine(Cidade = "Cidade: Taquaritinga ");
                    Console.WriteLine();
                }
                else if (agencia == 3)
                {
                    Console.WriteLine(Numero = "Numero da Agência: 0002  ");
                    Console.WriteLine(Cidade = "Cidade: Mococa ");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Agência Inválida. Tente Novamente!");
                }
            } while (agencia != 1 && agencia != 2 && agencia != 3);

        }


    }
}
