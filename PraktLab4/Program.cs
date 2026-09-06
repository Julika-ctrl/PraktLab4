using Lababa3;
using System;
using System.Diagnostics;
namespace lababa3
{
    class Program
    {
        static void Main(string[] args)
        {
            const int HUNDRED = 100;

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
                        Console.WriteLine("Калькулятор рассчета стоимости поездки");
                        bool ex = true;

                        while (ex)
                        {
                            Console.WriteLine("1. новая поездка  \n2. Анализ поездок \n3. Выход \nВведите число от 1 до 3 ");
                            int number1;
                            while (!int.TryParse(Console.ReadLine(), out number1))
                            {
                                Console.WriteLine("введите число от 1 до 3!");
                            }
                            switch (number1)
                            {
                                case 1:
                                    try
                                    {
                                        Console.WriteLine("Введите расстояние в км");

                                        Mathh.ReadDouble(out double distance);

                                        if (distance <= 0)
                                            throw new ArgumentException();
                                        Console.WriteLine("Введите средний расход топлива на 100 км");

                                        Mathh.ReadDouble(out double averageСonsumption);
                                        if (averageСonsumption <= 0)
                                            throw new ArgumentException();

                                        Console.WriteLine("Введите цену топлива за литр");

                                        Mathh.ReadDouble(out double pricePerLiter);
                                        if (pricePerLiter <= 0)
                                            throw new ArgumentException();

                                        double consumption = distance * (averageСonsumption / HUNDRED);
                                        Mathh.CalculateFuelConsumption(ref consumption);
                                        Mathh.ApplySeasonalCoefficient(ref consumption);

                                        double price = pricePerLiter * consumption;
                                        if (price > 1000000000)
                                            throw new Exception();
                                        string answer = string.Format("{0:f2}", price);

                                        string answerСonsumption = string.Format("{0:f2}", consumption);

                                        Console.WriteLine("Итог:" + "\n" + "расход: " + answerСonsumption + "\n" + "Цена: " + answer);
                                        Mathh.SaveTripToHistory(distance, price);

                                    }
                                    catch (ArgumentException)
                                    {
                                        Console.WriteLine("Числа не могут быть отрицательными :(");
                                        break;
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Слишком большое число :(");
                                        break;
                                    }
                                    break;
                                case 2:
                                    while (ex)
                                    {
                                        Console.WriteLine("1. Список Растояний \n2. Список Сезонов\n3.Список Транспорта \n4. Список Итоговых Сумм \n5. Выход");
                                        int n1;
                                        while (!int.TryParse(Console.ReadLine(), out n1))
                                        {
                                            Console.WriteLine("введите число от 1 до 5!");
                                        }
                                        switch (n1)
                                        {
                                            case 1:
                                                ForArray.WriteAr(Mathh.GetDistances());
                                                break;
                                            case 2:
                                                ForArray.WriteArStr(Mathh.GetSeasons());
                                                break;
                                            case 3:
                                                ForArray.WriteArStr(Mathh.GetVehicleTypes());
                                                break;
                                            case 4:
                                                ForArray.WriteAr(Mathh.GetTotalCosts());
                                                break;
                                            case 5:
                                                Console.WriteLine("Вы действительно хотите выйти? \n Введите \"д\"-если да или \"н\"- если нет");
                                                string yeNo = Console.ReadLine();
                                                while (yeNo != "д" && yeNo != "н")
                                                {
                                                    Console.WriteLine("Ошибка!Повторите ввод");
                                                    yeNo = Console.ReadLine();
                                                }
                                                if (yeNo == "д")
                                                {
                                                    ex = false;
                                                }
                                                break;
                                        }
                                    }
                                    break;


                                case 3:
                                    Console.WriteLine("Вы действительно хотите выйти? \n Введите \"д\"-если да или \"н\"- если нет");
                                    string yNo = Console.ReadLine();
                                    while (yNo != "д" && yNo != "н")
                                    {
                                        Console.WriteLine("Ошибка!Повторите ввод");
                                        yNo = Console.ReadLine();
                                    }
                                    if (yNo == "д")
                                    {
                                        Environment.Exit(0);
                                    }
                                    break;
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Вы действительно хотите выйти? \n Введите \"д\"-если да или \"н\"- если нет");
                        string yesNo = Console.ReadLine();
                        while (yesNo != "д" && yesNo != "н")
                        {
                            Console.WriteLine("Ошибка!Повторите ввод");
                            yesNo = Console.ReadLine();
                        }
                        if (yesNo == "д")
                        {
                            Environment.Exit(0);
                        }
                        break;


                }

            }

        }
    }
}

