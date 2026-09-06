using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lababa4
{
    internal class TripData
    {
        const int HUNDRED = 100;
        public double Distance { get; set; }
        public string VehicleType { get; set; }
        public string Season { get; set; }
        public double FuelPrice { get; set; }
        public double TotalCost { get; set; }
        public DateTime CalculationDate { get; set; }

        public TripData(double distance, string vehicleType, string season,
                       double fuelPrice, double totalCost)
        {
            Distance = distance;
            VehicleType = vehicleType;
            Season = season;
            FuelPrice = fuelPrice;
            TotalCost = totalCost;
            CalculationDate = DateTime.Now;
        }
        public static double CalculateCost(double distance, double averageСonsumption, double pricePerLiter)
        {
            double consumption = distance * (averageСonsumption / HUNDRED);
            TripCalculator.CalculateFuelConsumption(ref consumption);
            TripCalculator.ApplySeasonalCoefficient(ref consumption);

            double price = pricePerLiter * consumption;
            return price;
        }
        public static void PrintInfo(double price, double pricePerLiter)
        {
            string answer = string.Format("{0:f2}", price);

            string answerСonsumption = string.Format("{0:f2}", price / pricePerLiter);

            Console.WriteLine("Итог:" + "\n" + "расход: " + answerСonsumption + "\n" + "Цена: " + answer);
        }
        public void PrintInfo()
        {
            Console.WriteLine("=== Информация о поездке ===");
            Console.WriteLine($"Расстояние: {Distance} км");
            Console.WriteLine($"Транспорт: {VehicleType}");
            Console.WriteLine($"Сезон: {Season}");
            Console.WriteLine($"Цена топлива: {FuelPrice} руб/л");
            Console.WriteLine($"Общая стоимость: {TotalCost:F2} руб");
            Console.WriteLine($"Дата расчета: {CalculationDate:dd.MM.yyyy}");
            Console.WriteLine("==============");
        }


    }

}
