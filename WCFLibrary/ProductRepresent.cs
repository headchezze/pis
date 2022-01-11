using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WCFLibrary
{
    [DataContractAttribute]
    public class ProductRepresent
    {
        [DataMemberAttribute]
        public string Name { get; private set; }
        [DataMemberAttribute]
        public string Description { get; private set; }
        public override string ToString()
        {
            return $"{Name} {Description}";
        }

        public ProductRepresent(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
