namespace _09.Upcasting_and_Downcasting__Explicit_and_Implicit.Models
{
    internal class Dollar
    {
        public decimal USD { get; set; }

        public Dollar(decimal usd)
        {
            USD = usd;
        }

        public static implicit operator Dollar(Manat manat)
        {
            return new Dollar(manat.AZN/1.7m);
        }
    }
}
