
using CarShop.Data;
using CarShop.Models;
using CarShop.Services.Car;
CarService car = new CarService();

while (true)
{
    Console.WriteLine("1. Create Car");
    Console.WriteLine("2. Remove Car");
    Console.WriteLine("3. Show Cars");
    Console.WriteLine("4. update car");
    Console.WriteLine("5. Search Car");
    Console.WriteLine("x. Exit");
    Console.Write("Select an option: ");
    var input = Console.ReadLine();
    switch (input)
    {
        case "1":
            car.CreateCar();
            break;
        case "2":
            car.RemoveCar();
            break;
        case "3":
            car.ShowCars();
            break;
        case "4":
            car.UpdateCar();
            break;

        case "5":
            car.SearchCar();
            break;


            case "x":
                return;

        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}