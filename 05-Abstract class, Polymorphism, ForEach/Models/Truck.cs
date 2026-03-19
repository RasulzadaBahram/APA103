namespace _05_Abstract_class__Polymorphism__ForEach.Models
{
    class Truck : Vehicle
    {
        public double CargoCapacity;
        public int AxleCount;
        public double CurrentLoad;
        public int MaxSpeed;


        public Truck()
        {

        }
        public Truck(double cargocapacity) : this()
        {
            CargoCapacity = cargocapacity;
        }
        public Truck(double cargocapacity, int axlecount) : this(cargocapacity)
        {
            AxleCount = axlecount;
        }
        public Truck(double cargocapacity, int axlecount, double currentload) : this(cargocapacity, axlecount)
        {
            CurrentLoad = currentload;
        }
        public Truck(double cargocapacity, int axlecount, double currentload, int maxspeed) : this(cargocapacity, axlecount, currentload)
        {
            MaxSpeed = maxspeed;
        }



        public Truck(string brand) : base(brand)
        {

        }
        public Truck(string brand, string model) : base(brand, model)
        {

        }
        public Truck(string brand, string model, int year) : base(brand, model, year)
        {

        }
        public Truck(string brand, string model, int year, string platenumber) : base(brand, model, year, platenumber)
        {

        }

        public Truck(string brand, string model, int year, string platenumber, double fuellevel) : base(brand, model, year, platenumber, fuellevel)
        {

        }



        public void LoadCargo(double weight)
        {
            if ((CurrentLoad + weight) > CargoCapacity)
                Console.WriteLine("");
            else
                Console.WriteLine($"");
        }
        public override double CalculateFuelCost(double distance)
        {
            return (distance / 100) * (25 + CurrentLoad * 2) * 1.8;
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
