public class Program
{
    public static void Main(string[] args)
    {

        Console.Write("Hansi olcude olsun array: ");
        int olcu = Convert.ToInt32(Console.ReadLine());
        int[] arr = new int[olcu];
        Console.WriteLine("Yeni uzvleri daxil edin: ");

        for (int i = 0; i < arr.Length; i++)
        {

            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        int[] newMem = [12, 15, 13];

        CustomArrayResize(arr, newMem);
    }

    public static void CustomArrayResize(int[] numbers, params int[] newNumbers)
    {

        int[] newArr = new int[numbers.Length + newNumbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            newArr[i] = numbers[i];
        }

        for (int i = 0; i < newNumbers.Length; i++)
        {
            newArr[numbers.Length + i] = newNumbers[i];
        }

        for (int i = 0; i < newArr.Length; i++)
        {
            Console.WriteLine($"\n {newArr[i]}");
        }



    }




}