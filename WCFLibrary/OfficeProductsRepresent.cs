using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLibrary
{
    public class OfficeProductsRepresent
    {
        public decimal Cost { get; private set; }
        public string Product { get; private set; }
        public int Count { get; private set; }
        public OfficeRepresent Office { get; private set; }
        public override string ToString()
        {
            return $"{Product} {Count} {Cost} {Office.ToString()}";
        }
    }
}
