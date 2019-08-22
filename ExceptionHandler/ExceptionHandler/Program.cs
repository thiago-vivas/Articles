using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Runtime.CompilerServices;

namespace ExceptionHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public static void CustomException()
        {
            try
            {
                throw new CustomException();
            }
            catch (CustomException ex) //must comes first
            {

                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        public static void ArithmeticException()
        {
            int division = 0;

            try
            {
                var throwException = 15 / division;
            }
            catch (ArithmeticException ex) //must comes first
            {

                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        public static void NullReferenceException()
        {
            List<int> nullIntegerList = null;
            try
            {
                var throwException = nullIntegerList.Count;
            }
            catch (NullReferenceException ex) //must comes first
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static void FileNotFoundException()
        {
            try
            {
                var throwException = File.Open(@"C:\notExistentFile.jpg", FileMode.Open);
            }
            catch (FileNotFoundException ex) //must comes first
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static void IndexOutOfRangeException()
        {
            int[] sampleArray = new int[3] { 1, 2, 3 };
            try
            {
                var throwException = sampleArray[3];
            }
            catch (IndexOutOfRangeException ex) //must comes first
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
