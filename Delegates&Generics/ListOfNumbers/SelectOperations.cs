using System;
using System.Collections.Generic;

namespace ListOfNumbers
{
    public class SelectOperations
    {
        Validations validations = new Validations();

        public void Operations<T>() where T : struct, IConvertible
        {
            string value;
            int operacion = 0;

            Console.WriteLine("Elige un número para la operación que deseas realizar\n" +
                "1. Suma\n" +
                "2. Resta\n" +
                "3. Multiplicación\n" +
                "4. División\n");
            value = Console.ReadLine();
            validations.validacionInt(value, out operacion, "error");

          
            NumbersList<T> numbersList = new NumbersList<T>();
            List<T> numbers = validacionLista<T>();

            if (numbers.Count == 0)
            {
                Console.WriteLine("La lista debe contener números.");
                return;
            }

            
            foreach (T num in numbers)
            {
                numbersList.Set(num);
            }

            
            T resultado = default(T);

            try
            {
               
                switch (operacion)
                {
                    case 1:
                        resultado = numbersList.PerformOperation(NumbersList<T>.Add);
                        Console.WriteLine($"Resultado de la suma: {resultado}");
                        break;

                    case 2:
                        resultado = numbersList.PerformOperation(NumbersList<T>.Substract);
                        Console.WriteLine($"Resultado de la resta: {resultado}");
                        break;

                    case 3:
                        resultado = numbersList.PerformOperation(NumbersList<T>.Multiply);
                        Console.WriteLine($"Resultado de la multiplicación: {resultado}");
                        break;

                    case 4:
                        resultado = numbersList.PerformOperation(NumbersList<T>.Divide);
                        Console.WriteLine($"Resultado de la división: {resultado}");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public List<T> validacionLista<T>() where T : struct, IConvertible
        {
            string value;
            int cantidadNumeros = 0;
            List<T> numbers = new List<T>();

            Console.WriteLine("Introduce con cuántos números trabajaremos:");
            value = Console.ReadLine();
            validations.validacionInt(value, out cantidadNumeros, "error");

            for (int i = 1; i <= cantidadNumeros; i++)
            {
                Console.WriteLine($"Introduce el número {i}:");
                value = Console.ReadLine();

                try
                {
                    T numero = (T)Convert.ChangeType(value, typeof(T));
                    numbers.Add(numero);
                }
                catch
                {
                    Console.WriteLine("El valor introducido no es válido, intenta de nuevo.");
                    i--; 
                }
            }

            return numbers;
        }
    }
}
