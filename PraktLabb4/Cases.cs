using Lababa3;
using lababa4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lababa4
{
    internal class Cases
    {
        public static void Case1(TripCalculator calculator)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Введите расстояние в км");
                Mathh.ReadDouble(out double distance);
                if (distance <= 0)
                    throw new ArgumentException();
                Console.Clear();
                Console.WriteLine("Введите средний расход топлива на 100 км");
                Mathh.ReadDouble(out double averageСonsumption);
                if (averageСonsumption <= 0)
                    throw new ArgumentException();
                Console.Clear();
                Console.WriteLine("Введите цену топлива за литр");
                Mathh.ReadDouble(out double pricePerLiter);
                if (pricePerLiter <= 0)
                    throw new ArgumentException();
                Console.Clear();

                double consumption = distance * (averageСonsumption / 100);

                TripCalculator.CalculateFuelConsumption(ref consumption);
                TripCalculator.ApplySeasonalCoefficient(ref consumption);

                double price = pricePerLiter * consumption;
                if (price > 1000000000)
                    throw new Exception();
                Console.Clear();
                TripData.PrintInfo(price, pricePerLiter);

                TripCalculator.SaveTripToHistory(distance, price);

                string[] vehicleTypes = TripCalculator.GetVehicleTypes();
                string[] seasons = TripCalculator.GetSeasons();
                string vehicleType = "Неизвестно";
                for (int i = vehicleTypes.Length - 1; i >= 0; i--)
                {
                    if (!string.IsNullOrEmpty(vehicleTypes[i]))
                    {
                        vehicleType = vehicleTypes[i];
                        break;
                    }
                }

                string season = "Неизвестно";
                for (int i = seasons.Length - 1; i >= 0; i--)
                {
                    if (!string.IsNullOrEmpty(seasons[i]))
                    {
                        season = seasons[i];
                        break;
                    }
                }
                TripData trip = new TripData(distance, vehicleType, season, pricePerLiter, price);
                calculator.AddTrip(trip);

            }
            catch (ArgumentException)
            {
                Console.WriteLine("Числа не могут быть отрицательными :(");
            }
            catch (Exception)
            {
                Console.WriteLine("Слишком большое число :(");
            }
        }
        public static void Case4()
        {
            Console.Clear();
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
        }

    }
}
