using Lababa3;
using lababa4;
using System;
using System.Diagnostics;
namespace lababa3
{
    class Program
    {
        static void Main(string[] args)
        {
            TripCalculator calculator = new TripCalculator();

            while (true)
            {
                Console.WriteLine("1. Калькулятор рассчета стоимости поездки \n2. Выход");
                int number = 0;
                while (!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.WriteLine("введите число 1 или 2!");
                }
                switch (number)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Калькулятор рассчета стоимости поездки");
                        bool ex = true;

                        while (ex)
                        {
                            Console.WriteLine("1. новая поездка  \n2. Показать историю \n3. Анализ расходов\n4. Выход \nВведите число от 1 до 4 ");
                            int number1;
                            while (!int.TryParse(Console.ReadLine(), out number1))
                            {
                                Console.WriteLine("введите число от 1 до 4!");
                            }
                            switch (number1)
                            {
                                case 1:
                                    Cases.Case1(calculator);
                                    break;
                                case 2:
                                    calculator.ShowTripHistory();
                                    break;
                                case 3:
                                    calculator.AnalyzeTrips();
                                    break;
                                case 4:
                                    Cases.Case4();
                                    break;
                            }
                        }
                        break;
                    case 2:
                        Cases.Case4();
                        break;


                }

            }

        }
    }
}
