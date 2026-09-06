using lababa3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lababa3
{
    internal class Mathh
    {

        const int HUNDRED = 100;
        static double[] distancesSave = new double[10];
        static string[] vehicleTypes = new string[10];
        static string[] seasonsSave = new string[10];
        static double[] totalCosts_orPrice = new double[10];
        static string seasonStr = "0";
        double distanceForArray = 0;
        static double priceForArray = 0;
        static string transportS = "0";

        public static void ReadDouble(out double value)
        {
            while (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Введите число!!!");
            }

        }
        public static void CalculateFuelConsumption(ref double consumption)
        {

            while (true)
            {
                Console.WriteLine("Выберите транспорт:" + "\n" + "(написав номер нужного пункта)" + "\n" + "1.Легковой" + "\n" + "2.Грузовик" + "\n" + "3.Мотоцикл");
                Mathh.ReadDouble(out double transport);
                if (transport == 1)
                {
                    transportS = "Легковой";
                    ForArray.AddValueS(transportS, vehicleTypes);
                    break;
                }

                else if (transport == 2)
                {
                    transportS = "Грузовик";
                    consumption = consumption + consumption * 0.2;
                    ForArray.AddValueS(transportS, vehicleTypes);
                    break;
                }
                else if (transport == 3)
                {
                    transportS = "Мотоцикл";
                    consumption = consumption - consumption * 0.15;
                    ForArray.AddValueS(transportS, vehicleTypes);
                    break;
                }
                else Console.WriteLine("Число должо быть от 1 до 3");
            }
        }

        public static void ApplySeasonalCoefficient(ref double consumption)
        {
            while (true)
            {
                Console.WriteLine("Выберите сезон:" + "\n" + "(написав номер нужного пункта)" + "\n" + "1.Лето" + "\n" + "2.Зима");

                Mathh.ReadDouble(out double season);
                if (season == 1)
                {
                    seasonStr = "ЛЕТО";
                    ForArray.AddValueS(seasonStr, seasonsSave);
                    break;
                }
                else if (season == 2)
                {
                    seasonStr = "ЗИМА";
                    consumption = consumption + consumption * 0.1;
                    ForArray.AddValueS(seasonStr, seasonsSave);
                    break;
                }
                else Console.WriteLine("Число должо быть 1 или 2");
            }
        }


        public static void SaveTripToHistory(double distance, double totalPrice)
        {
            ForArray.AddValueD(distance, distancesSave);
            ForArray.AddValueD(totalPrice, totalCosts_orPrice);
        }
        public static double[] GetDistances() => distancesSave;
        public static string[] GetSeasons() => seasonsSave;
        public static string[] GetVehicleTypes() => vehicleTypes;
        public static double[] GetTotalCosts() => totalCosts_orPrice;

    }
}
