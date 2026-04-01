namespace _09.Upcasting_and_Downcasting__Explicit_and_Implicit.Models
{
    internal class Manat
    {
        public decimal AZN { get; set; }

        public Manat(decimal azn)
        {
            AZN = azn;
        }

        public static implicit operator Manat(Dollar dollar) 
        {
            
            return new Manat(dollar.USD*1.7m); 
        }



    }
}
