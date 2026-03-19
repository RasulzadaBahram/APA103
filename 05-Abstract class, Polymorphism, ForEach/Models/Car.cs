namespace _05_Abstract_class__Polymorphism__ForEach.Models
{
    class Car : Vehicle
    {
        public int DoorsCount { get; set; }
        public int TruckCapacity { get; set; }
        public bool IsAutomatic { get; set; }
        public int MaxSpeed { get; set; }

        public Car()
        {

        }
        public Car(int doorscount) : this()
        {
            DoorsCount = doorscount;
        }
        public Car(int doorscount, int truckcapacity) : this(doorscount)
        {
            TruckCapacity = truckcapacity;
        }
        public Car(int doorscount, int truckcapacity, bool isautomatic) : this(doorscount, truckcapacity)
        {
            IsAutomatic = isautomatic;
        }
        public Car(int doorscount, int truckcapacity, bool isautomatic, int maxspeed) : this(doorscount, truckcapacity, isautomatic)
        {
            MaxSpeed = maxspeed;
        }



        public Car(string brand) : base(brand)
        {

        }
        public Car(string brand, string model) : base(brand, model)
        {

        }
        public Car(string brand, string model, int year) : base(brand, model, year)
        {

        }
        public Car(string brand, string model, int year, string platenumber) : base(brand, model, year, platenumber)
        {

        }

        public Car(string brand, string model, int year, string platenumber, double fuellevel) : base(brand, model, year, platenumber, fuellevel)
        {

        }



        public override double CalculateFuelCost(double distance)
        {
            return (distance / 100) * 8 * 1.5;
        }

        public override string GetVehicleInfo()
        {
            return $"Brand: {Brand}, Model: {Model}, Year: {Year}, Plate Number: {PlateNumber}, Fuel Level: {FuelLevel}%";
        }

        public override void ShowBasicInfo()
        {
            Console.WriteLine($"Brand: {Brand}, Model: {Model}, Year: {Year}");
        }
    }
}
