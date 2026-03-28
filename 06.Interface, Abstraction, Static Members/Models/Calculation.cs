using _06.Interface__Abstraction__Static_Members.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Interface__Abstraction__Static_Members.Models
{
    public class Calculation:ICalculation
    {
        public void Calculate(int num1, int num2)
        {
            Console.WriteLine($"2 ededin cemi: {num1+num2}");
            Console.WriteLine($"2 ededin ferqi: {num1-num2}");
            Console.WriteLine($"2 ededin hasili: {num1*num2}");
            Console.WriteLine($"2 ededin nisbeti: {Convert.ToDouble(num1/num2)}");
        }
    }
}
