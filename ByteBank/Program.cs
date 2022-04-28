using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            CarregarContas();
            Console.ReadLine();
        }

        private static void CarregarContas()
        {
            LeitorDeArquivo leitor = null;
            
            try
            {
                leitor = new LeitorDeArquivo("contas.txt");

                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
            }
            catch (IOException)
            {
                Console.WriteLine("Exceção do tipo IOException capturada e tratada!");
            }
            finally // Sempre é executado, seja depois do try ou do catch
            {
                if (leitor != null)
                {
                    leitor.Fechar();
                }
            }
        }

        private static void TestaInnerException()
        {
            try
            {
                ContaCorrente conta1 = new ContaCorrente(1234, 4567899);
                ContaCorrente conta2 = new ContaCorrente(2434, 4567855);

                // conta1.Transferir(10000, conta2);
                conta1.Sacar(1000);
            }
            catch (OperacaoFinanceiraException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                //Console.WriteLine("Informações da Inner Exception:");
                //Console.WriteLine(e.InnerException.Message);
                //Console.WriteLine(e.InnerException.StackTrace);
            }
        }

        // Teste com a cadeia de chamada:
        // Metodo -> TestaDivisao -> Dividir
        private static void Metodo()
        {
            TestaDivisao(0);
        }

        private static void TestaDivisao(int divisor)
        {
            int resultado = Dividir(10, divisor);
            Console.WriteLine("Resultado da divisão de 10 por " + divisor + " é " + resultado);
        }

        private static int Dividir(int numero, int divisor)
        {
            try
            {
                return numero / divisor;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Exceção com número=" + numero + " e divisor=" + divisor);
                throw;
            }
        }
    }
}