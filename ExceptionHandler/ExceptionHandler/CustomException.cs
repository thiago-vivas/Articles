using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandler
{
    public class CustomException : Exception
    {
        public CustomException(): base("This is a custom exception")
        {

        }
    }
}
