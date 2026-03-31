using _07.Nullable__Enum__Struct.Enums;
using System.Drawing;

namespace _07.Nullable__Enum__Struct.Models
{
    internal class DrinkOrder
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public DrinkType Drink { get; set; }
        public DrinkSize Size { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.New;
        public decimal Price { get; set; }


        public DrinkOrder(int orderNumber, string customerName, DrinkType drink, DrinkSize size)
        {
            OrderNumber = orderNumber;
            CustomerName = customerName;
            Drink = drink;
            Size = size;
        }


        public void CalculatePrice()
        {

            switch (Drink)
            {
                case DrinkType.Coffee:
                    switch (Size)
                    {
                        case DrinkSize.Small:
                            Price = 3;
                            Console.WriteLine($"Qiymeti {Price} \n");
                            break;

                        case DrinkSize.Medium:
                            Price = 4;
                            Console.WriteLine($"Qiymeti {Price} \n");
                            break;

                        case DrinkSize.Large:
                            Price = 5;
                            Console.WriteLine($"Qiymeti {Price} \n");
                            break;
                    }
                    break;

                case DrinkType.Tea:
                    switch (Size)
                    {
                        case DrinkSize.Small:
                            Price = 2;
                            Console.WriteLine($"Qiymeti {Price} \n");
                            break;

                        case DrinkSize.Medium:
                            Price = 3;
                            Console.WriteLine($"Qiymeti {Price} \n");
                            break;

                        case DrinkSize.Large:
                            Price = 4;
                            Console.WriteLine($"Qiymeti {Price} \n");
                            break;
                    }
                    break;

                case DrinkType.Juice:
                    switch (Size)
                    {
                        case DrinkSize.Small:
                            Price = 4;
                            Console.WriteLine($"Qiymeti {Price}\n");
                            break;

                        case DrinkSize.Medium:
                            Price = 5;
                            Console.WriteLine($"Qiymeti {Price}\n");
                            break;

                        case DrinkSize.Large:
                            Price = 6;
                            Console.WriteLine($"Qiymeti {Price}\n");
                            break;
                    }
                    break;

                case DrinkType.Water:
                    switch (Size)
                    {
                        case DrinkSize.Small:
                            Price = 1;
                            Console.WriteLine($"Qiymeti {Price} \n");
                            break;

                        case DrinkSize.Medium:
                            Price = 1.5M;
                            Console.WriteLine($"Qiymeti {Price} \n");
                            break;

                        case DrinkSize.Large:
                            Price = 2;
                            Console.WriteLine($"Qiymeti {Price} \n");
                            break;
                    }
                    break;
            }
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
            Console.WriteLine($"Sifariş: {OrderNumber} statusu: {newStatus}");
        }
        public void DisplayOrder()
        {
            Console.WriteLine($"\nOrderNumber: {OrderNumber}, CustomerName: {CustomerName}, Drink: {Drink}, Size: {Size} ");
        }
        public static void GetValues()
        {
            foreach (var type in Enum.GetValues(typeof(DrinkType)))
            {
                Console.WriteLine($"{type}");

            }

            foreach (var size in Enum.GetValues(typeof(DrinkSize)))
            {
                Console.WriteLine($"{size}");

            }

            foreach (var status in Enum.GetValues(typeof(OrderStatus)))
            {
                Console.WriteLine($"{status}");

            }



        }

    }
}
