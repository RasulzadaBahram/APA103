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
//        int[] numbers = { 14, 20, 35, 40, 57, 60, 100 };
//        Even(numbers);
//        Odd(numbers);
//    }

//    public static void Even(int[] num)
//    {
//        for (int i = 0; i < num.Length; i++)
//        {
//            if (num[i] % 2 == 0)
//            {
//                Console.WriteLine($"Cut ededdir: {num[i]}");
//            }
//        }
//    }

//    public static void Odd(int[] num)
//    {
//        for (int i = 0; i < num.Length; i++)
//        {
//            if (num[i] % 2 != 0)
//            {
//                Console.WriteLine($"Tek ededdir: {num[i]}");
//            }
//        }
//    }
//}

//3.Verilmis arreyde elementlerin həm 4-ə, həm də 5-ə bölününen elementlerin cemini tapin.[14, 20, 35, 40, 57, 60, 100]

//class Program
//{
//    public static void Main(string[] args)
//    {
//        int[] list = { 14, 20, 35, 40, 57, 60, 100 };
//        Divide(list);
//    }
//    public static void Divide(int[] num)
//    {
//        for (int i = 0; i < num.Length; i++)
//        {
//            if (num[i] % 4 == 0 && num[i] % 5 == 0)
//            {
//                Console.WriteLine(num[i]);
//            }
//        }
//    }
//}


//4.Daxil edilmiş cümlədə daxil edilmis simvoldan nece eded olduğunu tapan Proqramın alqoritmini yazin.(Cumle serbestdir)


//class Program
//{
//    public static void Main(string[] args)
//    {
//        Console.Write("Soz: ");
//        Console.WriteLine(Text(Console.ReadLine()));
//    }
//    public static int Text(string text)
//    {
//        int count = 0;
//        Console.Write("Tapilmali herf sayi: ");
//        char symbol = Convert.ToChar(Console.ReadLine());
//        for (int i = 0; i < text.Length; i++)
//        {

//            if (text[i] == symbol)
//            {
//                count++;
//            }
//        }
//        return count;
//    }
//}

