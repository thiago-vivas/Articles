using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DesignPatternSOLID._1.S
{
    class Solution
    {
        public int Sum(int numberOne, int numberTwo)
        {
            int result = numberOne + numberTwo;
            Logging.LogCalculations("Sum Operation. Number one: " + numberOne + ", Number two: " + numberTwo + ". Result: " + result);
            return result;
        }
    }
    public static class Logging
    {
        public static void LogCalculations(string message)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\log.txt";
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(message);
            }
        }
    }
}
