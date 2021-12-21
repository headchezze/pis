using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLibrary
{
    public class OfficeRepresent
    {
        public string Location { get; private set; }
        public string Organization {  get; private set; }

        public override string ToString()
        {
            return $"{Organization} {Location}";
        }
    }
}
