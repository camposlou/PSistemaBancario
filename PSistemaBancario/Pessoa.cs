using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSistemaBancario
{
    internal class Pessoa
    {
        public string Nome { get; set; }
        protected string Telefone { get; set; }
        protected DateTime Data { get; set; }
        protected int IDPessoa { get; set; }
        public string Agencia { get; set; } 

        public Pessoa() 
        { 

        }

        protected int getID()
        {
            string[] contador = System.IO.File.ReadAllLines($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\DBClientes\\Contador\\Contador.txt");
            string[] num = new string[1];

            foreach (string cont in contador)
                num[0] = cont;
            int id = int.Parse(num[0]);
            return id;
        }
        protected void SaveID(int id)
        {
            StreamWriter CodPessoa = new StreamWriter($"C:\\Users\\Louise Campos\\source\\repos\\PSistemaBancario\\DBClientes\\Contador\\Contador.txt");
            CodPessoa.WriteLine(id);
            CodPessoa.Close();
        }
    }
}

