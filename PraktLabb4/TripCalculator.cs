using lababa3;
using Lababa3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lababa4
{
    internal class TripCalculator
    {
        private TripData[] trips;
        private int currentIndex;
        private int tripCount;

        const int HUNDRED = 100;
        static double[] distancesSave = new double[10];
        static string[] vehicleTypes = new string[10];
        static string[] seasonsSave = new string[10];
        static double[] totalCosts_orPrice = new double[10];
        //double distanceForArray = 0;
        //static double priceForArray = 0;   
        static string transportS = "Неизвестно";
        static string seasonStr = "Неизвестно";

        public TripCalculator()
        {
            trips = new TripData[10];
            currentIndex = 0;
            tripCount = 0;
        }


        //currentIndex = (currentIndex + 1) % trips.Length;
        public void AddTrip(TripData trip)
        {

            if (tripCount >= 10)
            {

                for (int i = 1; i < trips.Length; i++)
                {
                    trips[i - 1] = trips[i];
                }

                currentIndex = trips.Length - 1;
            }
            else
            {
                tripCount++;
            }
            trips[currentIndex] = trip;

            if (tripCount < 10)
            {
                currentIndex++;
            }
            Console.WriteLine("Поездка успешно добавлена");
        }





        public void ShowTripHistory()
        {
            Console.Clear();
            if (tripCount == 0)
            {
                Console.WriteLine("История поездок пуста");
                return;
            }

            Console.WriteLine("=== История поездок ===");
            for (int i = 0; i < tripCount; i++)
            {
                if (trips[i] != null)
                {
                    Console.WriteLine($"{i + 1}. {trips[i].VehicleType} - {trips[i].Distance} км - {trips[i].TotalCost} руб");
                }
            }
            Console.WriteLine();
        }

        public void AnalyzeTrips()
        {
            Console.Clear();

            if (tripCount == 0)
            {
                Console.WriteLine("Нет данных для анализа! Сначала добавьте поездки.");
                return;
            }

            double totalCost = 0;
            int actualTrips = 0;

            for (int i = 0; i < trips.Length; i++)
            {
                if (trips[i] != null)
                {
                    totalCost = totalCost + trips[i].TotalCost;
                    actualTrips++;
                }
            }

            double averageCost = totalCost / actualTrips;
            TripData cheapestTrip = null;
            double minCost = double.MaxValue; // Лучше использовать double.MaxValue

            double[] vehT = new double[3];
            double countCar = 0;
            double countTruck = 0;
            double countMoto = 0;

            for (int i = 0; i < trips.Length; i++)
            {
                if (trips[i] != null)
                {
                    switch (trips[i].VehicleType)
                    {
                        case "Легковой":
                            vehT[0] += trips[i].TotalCost;
                            countCar++;
                            break;
                        case "Грузовик":
                            vehT[1] += trips[i].TotalCost;
                            countTruck++;
                            break;
                        case "Мотоцикл":
                            vehT[2] += trips[i].TotalCost;
                            countMoto++;
                            break;
                    }
                }
            }

            double[] vehTypeAverageCost = new double[3];

            if (countCar > 0) vehTypeAverageCost[0] = vehT[0] / countCar;
            if (countTruck > 0) vehTypeAverageCost[1] = vehT[1] / countTruck;
            if (countMoto > 0) vehTypeAverageCost[2] = vehT[2] / countMoto;
            //  самый экономичный транспорт
            for (int i = 0; i < trips.Length; i++)
            {
                if (trips[i] != null && trips[i].Distance > 0)
                {
                    double cost = trips[i].TotalCost / trips[i].Distance;

                    if (cost < minCost)
                    {
                        minCost = cost;
                        cheapestTrip = trips[i];
                    }
                }
            }
            double minVeh = 0;
            bool flag = false;

            for (int i = 0; i < vehTypeAverageCost.Length; i++)
            {
                if (vehTypeAverageCost[i] > 0)
                {
                    if (!flag)
                    {
                        minVeh = vehTypeAverageCost[i];
                        flag = true;
                    }
                    else if (vehTypeAverageCost[i] < minVeh)
                    {
                        minVeh = vehTypeAverageCost[i];
                    }
                }
            }


            Console.WriteLine("    Анализ расходов    ");
            Console.WriteLine($"Всего поездок: {actualTrips}");
            Console.WriteLine($"Общая стоимость: {totalCost:F2} руб");
            Console.WriteLine($"Средняя стоимость: {averageCost:F2} руб");
            if (cheapestTrip != null)
            {
                Console.WriteLine($"Стоимость 1 км: {minCost:F2} руб");
                Console.WriteLine($"Самый экономичный транспорт: {cheapestTrip.VehicleType}");
            }
            else
            {
                Console.WriteLine($"Стоимость 1 км: Нет данных");
                Console.WriteLine($"Самый экономичный транспорт: Нет данных");
            }

            if (flag)
            {
                Console.WriteLine($"Самый эффективный транспорт (средняя стоимость): {minVeh:F2} руб");
            }
            else
            {
                Console.WriteLine($"Самый эффективный транспорт: Нет данных");
            }
            Console.WriteLine();
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


