//1.Hər biri 2 parametr qəbul edib və riyazi əməlləri yerinə yetiren method yazin.
//class Program 
//{
//    public static void Main(string[] args) 
//    {
//        int a=Convert.ToInt32(Console.ReadLine());
//        int b=Convert.ToInt32(Console.ReadLine());

//        Console.WriteLine($"Ededlerin cemi:  {Topla(a,b)}");
//        Console.WriteLine($"Ededlerin ferqi:  {Cix(a,b)}");
//        Console.WriteLine($"Ededlerin hasili:  {Hasil(a,b)}");
//        Console.WriteLine($"Ededlerin bolunme:  {Bol(a,b)}");
//    }

//    public static int Topla(int num, int num1)
//    {
//        int cem = num + num1;
//        return cem;
//    }

//    public static int Cix(int num, int num1)
//    {
//        int ferq = num - num1;
//        return ferq;
//    }

//    public static int Hasil(int num, int num1)
//    {
//        int hasil = num * num1;
//        return hasil;
//    }

//    public static double Bol(double num, double num1)
//    {
//        if (num1 == 0)
//        {
//            Console.WriteLine("0-a bolmek olmaz");
//            return double.NaN;
//        }
//        else
//        {
//            return num / num1;
//        }
//    }
//}



//2.Verilen arqumentlere uygun tek ve cut edeleri tapan method yazin.(14, 20, 35, 40, 57, 60, 100)

//class Program
//{
//    public static void Main(string[] args)
//    {
//        int[] numbers = [14, 20, 35, 40, 57, 60, 100];
//        for (int i = 0; i < numbers.Length; i++)
//        {
//            if (Even(numbers[i])) 
//            {
//                Console.WriteLine($"Cut ededdir : {numbers[i]}");
//            }
//            if (Odd(numbers[i])) 
//            {
//                Console.WriteLine($"Tek ededdir : {numbers[i]}");
//            }
//        }
//    }

//    public static bool Even(int num)
//    {
//        return num % 2 == 0;
//    }

//    public static bool Odd(int num)
//    {
//        return num % 2 != 0;
//    }
//}

//3.Verilmis arreyde elementlerin həm 4-ə, həm də 5-ə bölününen elementlerin cemini tapin.[14, 20, 35, 40, 57, 60, 100]

//class Program
//{
//    public static void Main(string[] args)
//    {
//        int[] numbers = [14, 20, 35, 40, 57, 60, 100];
//        int sum = 0;
//        for (int i = 0; i < numbers.Length; i++)
//        {
//            if (Divide(numbers[i]))
//            {
//                sum += numbers[i];
//            }
//        }
//        Console.WriteLine(sum);
//    }
//    public static bool Divide(int num)
//    {
//        return (num % 4 == 0 && num % 5 == 0);
//    }
//}

//4.Daxil edilmiş cümlədə daxil edilmis simvoldan nece eded olduğunu tapan Proqramın alqoritmini yazin.(Cumle serbestdir)


class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Soz: ");
        Console.WriteLine(Text(Console.ReadLine()));
    }
    public static int Text(string text)
    {
        int count = 0;
        Console.Write("Tapilmali herf sayi: ");
        char symbol = Convert.ToChar(Console.ReadLine());
        for (int i = 0; i < text.Length; i++)
        {

            if (text[i] == symbol)
            {
                count++;
            }
        }
        return count;
    }
}
