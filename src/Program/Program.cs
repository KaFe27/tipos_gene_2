//------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System;

namespace Ucu.Poo.Repositories
{
    /// <summary>
    /// Programa principal.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main()
        {
            Car jimny = new Car("Jimny", "Suzuki", 2024);
            Car focus = new Car("Focus", "Ford", 2018);
            Database<Car> database = new Database<Car>();
            database.Add(jimny);
            database.Add(focus);
            database.SaveToFile("cars.json");
            Console.WriteLine("Database saved:");
            foreach (Car car in restoredDatabase.Items)
            {
                Console.WriteLine($"Model: {car.Model}, Maker: {car.Maker}, Year: {car.Year}");
            }

            Database<Car> restoredDatabase = new Database<Car>();
            restoredDatabase.LoadFromFile("cars.json");
            Console.WriteLine("Restored database:");
            foreach (Car car in database.Cars)
            {
                Console.WriteLine($"Model: {car.Model}, Maker: {car.Maker}, Year: {car.Year}");
            }
        }
    }
}