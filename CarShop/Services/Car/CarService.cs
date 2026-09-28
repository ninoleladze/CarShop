using CarShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Car
{
    internal class CarService : ICarService
    {
        private DataContext _db = new DataContext();
        public void CreateCar()
        {
            Console.WriteLine("Enter a car name:");
            var name = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(name))throw new Exception("Car name cannot be empty.");
            Console.WriteLine("Enter a car description:");
            var description = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(description)) throw new Exception("Car description cannot be empty.");
            Console.WriteLine("Enter a car year:");
            int yearInput = int.Parse(Console.ReadLine());
            if (yearInput <1900) throw new Exception("Car year is not valid.");
            Console.WriteLine("Enter a car price:");
            var priceInput = double.Parse(Console.ReadLine());
            if (priceInput <0) throw new Exception("Car price cannot be negative.");

            var car = new Models.Car
            {
                Name = name,
                Description = description,
                Year = yearInput,
                Price = priceInput
            };
           
            _db.Cars.Add(car);
            _db.SaveChanges();
            Console.WriteLine("Car created successfully.");

        }

        public void RemoveCar()
        {
   
            Console.WriteLine("enter id to delete car:");
            int idInput = int.Parse(Console.ReadLine());
            var car = _db.Cars.Find(idInput);
            if (car == null)throw new Exception("Car not found.");
            _db.Cars.Remove(car);
            _db.SaveChanges();
            Console.WriteLine("Car removed successfully.");
        }

        public void ShowCars()
        {
            var cars = _db.Cars.ToList();
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        public void UpdateCar()
        {
            Console.WriteLine("enter id to update car:");
            int idInput = int.Parse(Console.ReadLine());
            var car = _db.Cars.Find(idInput);
            if (car == null) throw new Exception("Car not found.");
            Console.WriteLine("Enter a new car name:");
            var name =  Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                car.Name = name;
            }
            Console.WriteLine("Enter a new car description:");
            var description = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(description))
            {
                car.Description = description;
            }
            Console.WriteLine("Enter a new car year:");
            var yearStr = Console.ReadLine();
            if (int.TryParse(yearStr, out int yearInput))
            {
                if (yearInput > 1 || yearInput < 1900) throw new Exception("Car year is not valid.");
                car.Year = yearInput;
            }
            Console.WriteLine("Enter a new car price:");
            var priceStr = Console.ReadLine();
            if (double.TryParse(priceStr, out double priceInput))
            {
                if (priceInput < 0) throw new Exception("Car price cannot be negative.");
                car.Price = priceInput;
            }
            _db.SaveChanges();
            Console.WriteLine("Car updated successfully.");

        }

        public void SearchCar()
        {
            Console.WriteLine("Enter search term:");
            var search = Console.ReadLine();
            var cars = _db.Cars
                .Where(c => c.Name.Contains(search) || c.Description.Contains(search))
                .ToList();
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
