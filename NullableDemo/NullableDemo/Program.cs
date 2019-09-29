using System;

namespace NullableDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Product product = new Product( 1, "Widget" );

            int len = 0;
            if (product.AdditionalInfo != null)
            {
                len = product.AdditionalInfo.Length;
            }
        }
    }
}
