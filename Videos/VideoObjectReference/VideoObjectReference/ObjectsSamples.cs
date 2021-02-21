using System;
using System.Collections.Generic;
using System.Text;

namespace VideoObjectReference
{
    public class SampleObj
    {
        public SampleObj()
        {
            this.MyList = new List<string>();
            this.ChildObj = new SampleChildObj();
        }
        public string Item1 { get; set; }
        public SampleChildObj ChildObj { get; set; }
        public List<string> MyList { get; set; }
        public string Process()
        { return "Processed"; }
    }
    public class SampleChildObj
    {
        public string Item2 { get; set; }
    }
}
