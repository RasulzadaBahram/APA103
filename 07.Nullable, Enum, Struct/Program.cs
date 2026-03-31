using _07.Nullable__Enum__Struct.Enums;
using _07.Nullable__Enum__Struct.Models;

public class Program
{
    public static void Main(string[] args)
    {
        DrinkOrder order1 = new(101, "Ali", DrinkType.Coffee, DrinkSize.Medium);
        order1.DisplayOrder();
        order1.UpdateStatus(OrderStatus.Preparing);
        order1.UpdateStatus(OrderStatus.Ready);
        order1.UpdateStatus(OrderStatus.Delivered);
        order1.CalculatePrice();

        DrinkOrder order2 = new(102, "Leyla", DrinkType.Tea, DrinkSize.Large);
        order2.DisplayOrder();
        order2.UpdateStatus(OrderStatus.Ready);
        order2.CalculatePrice();

        DrinkOrder order3 = new(103, "Vuqar", DrinkType.Juice, DrinkSize.Small);
        order3.DisplayOrder();
        order3.CalculatePrice();

        DrinkOrder.GetValues();


        string strCoffee = DrinkType.Coffee.ToString();
        string strLarge = DrinkSize.Large.ToString();

        Console.WriteLine($"\n{strCoffee}");
        Console.WriteLine(strLarge);


        decimal total = order1.Price + order2.Price + order3.Price;
        Console.WriteLine($" \nÜmumi sifariş sayı: 3  ");
        Console.WriteLine($"Order1 {order1.Price} ");
        Console.WriteLine($"Order2 {order2.Price} ");
        Console.WriteLine($"Order3 {order3.Price} ");
        Console.WriteLine(total);





    }


}
