namespace _05_Abstract_class__Polymorphism__ForEach.Models
{
    class Motorcycle : Vehicle
    {
        public int EngineCapacity { get; set; }
        public bool HasSidecar { get; set; }
        public int MaxSpeed { get; set; }
        public string Type { get; set; }


        public Motorcycle()
        {

        }
        public Motorcycle(int enginecapacity) : this()
        {
            EngineCapacity = enginecapacity;
        }
        public Motorcycle(int enginecapacity, bool hassidecar) : this(enginecapacity)
        {
            HasSidecar = hassidecar;
        }
        public Motorcycle(int enginecapacity, bool hassidecar, int maxspeed) : this(enginecapacity, hassidecar)
        {
            MaxSpeed = maxspeed;
        }
        public Motorcycle(int enginecapacity, bool hassidecar, int maxspeed, string type) : this(enginecapacity, hassidecar, maxspeed)
        {
            Type = type;
        }




        public Motorcycle(string brand) : base(brand)
        {

        }
        public Motorcycle(string brand, string model) : base(brand, model)
        {

        }
        public Motorcycle(string brand, string model, int year) : base(brand, model, year)
        {

        }
        public Motorcycle(string brand, string model, int year, string platenumber) : base(brand, model, year, platenumber)
        {

        }

        public Motorcycle(string brand, string model, int year, string platenumber, double fuellevel) : base(brand, model, year, platenumber, fuellevel)
        {

        }

        public override double CalculateFuelCost(double distance)
        {
            return (distance / 100) * 4 * 1.5;
        }

        public override string GetVehicleInfo()
        {
            return $"Brand: {Brand}, Model: {Model}, Year: {Year}, Plate Number: {PlateNumber}, Fuel Level: {FuelLevel}% Max Speed: {MaxSpeed}";
        }

        public override void ShowBasicInfo()
        {
            Console.WriteLine($"Brand: {Brand}, Model: {Model}, Year: {Year}");
        }
    }
}
