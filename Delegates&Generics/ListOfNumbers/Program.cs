using System.Runtime.CompilerServices;

namespace ListOfNumbers
{
    public class Program
    {

        
        public static void Main(string[] args)
        {
            SelectOperations operations = new();
            Console.WriteLine("Selecciona el tipo de los datos:\n1. Enteros\n2. Decimales\n3. Doubles");
            string value=Console.ReadLine();

            switch (value)
            {
                case "1":
                    operations.Operations<int>();
                    break;

                case "2":
                    operations.Operations<decimal>();
                    break;

                case "3":
                    operations.Operations<double>();
                    break;
            }


        }


        
    }
}
