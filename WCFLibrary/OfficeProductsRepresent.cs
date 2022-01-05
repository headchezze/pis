using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WCFLibrary
{
    [DataContractAttribute]
    public class OfficeProductsRepresent
    {
        [DataMemberAttribute]
        public decimal Cost { get; private set; }
        [DataMemberAttribute]
        public string Product { get; private set; }
        [DataMemberAttribute]
        public int Count { get; private set; }
        [DataMemberAttribute]
        public OfficeRepresent Office { get; private set; }
        public OfficeProductsRepresent(string product, decimal cost, int count)
        {
            Product = product;
            Cost = cost;
            Count = count;
        }
        public override string ToString()
        {
            return $"{Product} {Count} {Cost} {Office.ToString()}";
        }
    }
}
