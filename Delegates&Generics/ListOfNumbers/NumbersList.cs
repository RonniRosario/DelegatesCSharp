using System;
using System.Collections.Generic;

namespace ListOfNumbers
{
    public class NumbersList<T> where T : struct, IConvertible
    {
        private List<T> listaNumeros = new List<T>();

   
        public delegate T Operations(List<T> items);

        public void Set(T item)
        {
            listaNumeros.Add(item);
        }

        public T PerformOperation(Operations operation)
        {
            if (listaNumeros.Count == 0)
            {
                throw new InvalidOperationException("La lista está vacía, no se puede realizar la operación.");
            }
            return operation(listaNumeros);
        }

     
        public static T Add(List<T> items)
        {
            if (items.Count == 0) return default(T);

            dynamic result = default(T);
            foreach (T item in items)
            {
                result += item;
            }
            return (T)result;
        }

        public static T Substract(List<T> items)
        {
            if (items.Count == 0) return default(T);

            dynamic result = items[0];
            for (int i = 1; i < items.Count; i++)
            {
                result -= items[i];
            }
            return (T)result;
        }

        public static T Multiply(List<T> items)
        {
            if (items.Count == 0) return default(T);

            dynamic result = (T)Convert.ChangeType(1, typeof(T));
            foreach (T item in items)
            {
                result *= item;
            }
            return (T)result;
        }

        public static T Divide(List<T> items)
        {
            if (items.Count == 0) return default(T);

            dynamic result = items[0];
            for (int i = 1; i < items.Count; i++)
            {
                if (items[i].Equals((T)Convert.ChangeType(0, typeof(T))))
                {
                    throw new DivideByZeroException("No se puede dividir por cero.");
                }
                result /= items[i];
            }
            return (T)result;
        }
    }
}
