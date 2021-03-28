using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DesignPatternSOLID._1.S
{
    //here we have a class with a method to sum two number and also a method to log those operations. Two different responsabilities
    class Problem
    {
        public int Sum(int numberOne, int numberTwo)
        {
            int result = numberOne + numberTwo;
            LogCalculations("Sum Operation. Number one: " + numberOne + ", Number two: " + numberTwo + ". Result: " + result);
            return result;
        }

        private void LogCalculations(string message)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\log.txt";
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(message);
            }
        }
    }
}
