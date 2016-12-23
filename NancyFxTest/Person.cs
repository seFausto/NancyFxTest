using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyFxTest
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public string Twitter { get; set; }
        public string Occupation { get; set; }
    }
}
