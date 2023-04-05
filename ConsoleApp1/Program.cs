using Calculator;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{


    public static class Program
    {
        private static CalculatorSoapClient _calculator = new CalculatorSoapClient(CalculatorSoapClient.EndpointConfiguration.CalculatorSoap);

        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando as operações");
            Console.WriteLine("");

            // Divisão
            var numbers = GetNumbers("divisão");
            var res = DoDivid(numbers[0], numbers[1]);
            Console.WriteLine("Resultado da divisão é: " + res.ToString());
            Console.WriteLine("");

            // Multiplicação
            numbers = GetNumbers("multiplicação");
            res = DoMultiply(numbers[0], numbers[1]);
            Console.WriteLine("Resultado da multiplicação é: " + res.ToString());
            Console.WriteLine("");

            // Subtração
            numbers = GetNumbers("subtração");
            res = DoSubtract(numbers[0], numbers[1]);
            Console.WriteLine("Resultado da subtração é: " + res.ToString());

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Fim das operações");
            Console.ReadLine();
        }

        private static int DoDivid(int a, int b)
        {
            try
            {
                
                var res = _calculator.DivideAsync(a, b).Result;
                return res;
            }
            catch
            {
                Console.WriteLine("Não é possivel dividir por zero");
            }
            return 0;
        }

        private static int DoMultiply(int a, int b)
        {
           var res = _calculator.MultiplyAsync(a, b).Result;
            return res;
        }

        private static int DoSubtract(int a, int b)
        {
            var res = _calculator.SubtractAsync(a, b).Result;
            return res;
        }

        private static bool IsValidNumber(string number)
        {
            return int.TryParse(number, out int i);
        }

        private static List<int> GetNumbers(string operation)
        {
            Console.WriteLine("Iniciando a " + operation);
            var numbers = new List<int>();
            numbers.Add(GetNumber("primeiro"));
            numbers.Add(GetNumber("segundo"));

            return numbers;
        }

        private static int GetNumber(string sequence)
        {
            Console.Write("Digite o " + sequence + " numero: ");
            var num = Console.ReadLine();
            var isValid = false;
            while (!isValid)
            {   
                isValid = IsValidNumber(num);
                if (!isValid)
                {
                    Console.WriteLine("O valor precisa ser numérico. Por favor, digite novamente!");
                    num = Console.ReadLine();
                }                
            }

            return int.Parse(num);
        }

    }
}
