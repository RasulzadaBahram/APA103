namespace _05_Abstract_class__Polymorphism__ForEach.Models
{
    abstract class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string PlateNumber { get; set; }
        public double FuelLevel { get; set; } = 100;

        public Vehicle()
        {

        }

        public Vehicle(string brand) : this()
        {
            Brand = brand;
        }

        public Vehicle(string brand, string model) : this(brand)
        {
            Model = model;
        }
        public Vehicle(string brand, string model, int year) : this(brand, model)
        {
            Year = year;
        }

        public Vehicle(string brand, string model, int year, string platenumber) : this(brand, model, year)
        {
            PlateNumber = platenumber;
        }

        public Vehicle(string brand, string model, int year, string platenumber, double fuellevel) : this(brand, model, year, platenumber)
        {
            FuelLevel = fuellevel;
        }


        public abstract double CalculateFuelCost(double distance);

        public abstract string GetVehicleInfo();



        public abstract void ShowBasicInfo();


    }

}
