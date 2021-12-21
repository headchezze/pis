using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLibrary
{
    public class ProductRepresent
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public override string ToString()
        {
            return $"{Name} {Description}";
        }
    }
}
