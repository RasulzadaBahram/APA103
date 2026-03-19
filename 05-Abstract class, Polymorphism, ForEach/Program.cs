using _05_Abstract_class__Polymorphism__ForEach.Models;

public class Program
{
    public static void Main(string[] args)
    {
        Car car1 = new()
        {
            Brand = "Mercedes",
            Model = "E200",
            Year = 2023,

            DoorsCount = 4,
            TruckCapacity = 500,
            IsAutomatic = true,
            MaxSpeed = 220
        };
        Car car2 = new()
        {
            Brand = "BMW",
            Model = "320I",
            Year = 2022,

            DoorsCount = 4,
            TruckCapacity = 480,
            IsAutomatic = true,
            MaxSpeed = 235
        };
        Car car3 = new()
        {
            Brand = "Toyota",
            Model = "Camry",
            Year = 2021,

            DoorsCount = 4,
            TruckCapacity = 524,
            IsAutomatic = true,
            MaxSpeed = 210
        };

        Motorcycle motorcycle1 = new()
        {
            Brand = "Yamaha R1",
            Year = 2023,

            EngineCapacity = 998,
            Type = "Sport",
            HasSidecar = false,
            MaxSpeed = 299
        };
        Motorcycle motorcycle2 = new()
        {
            Brand = "Harley-Davidson",
            Year = 2022,

            EngineCapacity = 1868,
            Type = "Cruiser",
            HasSidecar = true,
            MaxSpeed = 180
        };

        Truck truck1 = new()
        {
            Brand = "MAN TGX",
            Year = 2020,

            CargoCapacity = 18,
            AxleCount = 3,
            CurrentLoad = 12,
            MaxSpeed = 120
        };
        Truck truck2 = new()
        {
            Brand = "Volvo FH16",
            Year = 2021,

            CargoCapacity = 25,
            AxleCount = 4,
            CurrentLoad = 18,
            MaxSpeed = 110
        };


        Console.WriteLine(car1.CalculateFuelCost(500));
        car1.ShowBasicInfo();
        Console.WriteLine(car1.GetVehicleInfo());


        Console.WriteLine(car2.CalculateFuelCost(500));
        car2.ShowBasicInfo();
        Console.WriteLine(car2.GetVehicleInfo());


        Console.WriteLine(car3.CalculateFuelCost(500));
        car3.ShowBasicInfo();
        Console.WriteLine(car3.GetVehicleInfo());


        Console.WriteLine(motorcycle1.CalculateFuelCost(300));
        motorcycle1.ShowBasicInfo();
        Console.WriteLine(motorcycle1.GetVehicleInfo());


        Console.WriteLine(motorcycle2.CalculateFuelCost(300));
        motorcycle2.ShowBasicInfo();
        Console.WriteLine(motorcycle2.GetVehicleInfo());


        Console.WriteLine(truck1.CalculateFuelCost(800));
        truck1.ShowBasicInfo();
        Console.WriteLine(truck1.GetVehicleInfo());


        Console.WriteLine(truck2.CalculateFuelCost(800));
        truck2.ShowBasicInfo();
        Console.WriteLine(truck2.GetVehicleInfo());


        truck1.LoadCargo(5);

        Vehicle[] vehicles = { car1, car2, car3, motorcycle1, motorcycle2, truck1, truck2 };
        Console.WriteLine($"neqliyyat sayi {vehicles.Length}");

        int Sum = 0;
        for (int i=0; i < vehicles.Length; i++)
        {
            if (vehicles[i] is Car c)
            {
                Sum += c.MaxSpeed;
            }
            else if (vehicles[i] is Motorcycle m)
            {
                Sum += m.MaxSpeed;
            }
            else if (vehicles[i] is Truck t)
            {
                Sum += t.MaxSpeed;
            }
        }
        Console.WriteLine($"Ortalama suret {Sum / 7}");

        Vehicle maxVehicle = null;
        double maxCost = 0;

        Console.Write("Vehicle bahali yanacaq ");
        foreach (var item in vehicles)
        {
            double distance = 0;

            if (item is Car)
                distance = 500;
            else if (item is Motorcycle)
                distance = 300;
            else if (item is Truck)
                distance = 800;

            double cost = item.CalculateFuelCost(distance);

            if (cost > maxCost)
            {
                maxCost = cost;
                maxVehicle = item;
            }
        }
        Console.WriteLine($"Brand {maxVehicle.Brand}");

    }










}