using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiWithSwagger.Models
{
    public static class ValueSamples
    {
        public static Dictionary<int, string> MyValue;

        public static void Initialize()
        {
            MyValue = new Dictionary<int, string>();
            MyValue.Add( 0, "Value 0" );
            MyValue.Add( 1, "Value 1" );
            MyValue.Add( 2, "Value 2" );
        }
    }
}