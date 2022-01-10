using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFLibrary
{
    [DataContractAttribute]
    public class OfficeRepresent
    {
        [DataMemberAttribute]
        public string Location { get; private set; }
        [DataMemberAttribute]
        public string Organization {  get; private set; }
        [DataMemberAttribute]
        public string OrgType { get; private set; }
        [DataMemberAttribute]
        public List<OfficeProductsRepresent> ProductsRepresents { get; private set; }

        public override string ToString()
        {
            return $"{Organization} {Location}";
        }

        public OfficeRepresent(string location, string org, string orgType)
        {
            Location = location;
            Organization = org;
            OrgType = orgType;
        }

        public OfficeRepresent(string location, string org, List<OfficeProductsRepresent> products)
        {
            Location = location;
            Organization = org;
            ProductsRepresents = products;
        }

        public OfficeRepresent(string location, string org, IQueryable<OfficeProducts> products)
        {
            Location = location;
            Organization = org;
            ProductsRepresents = new List<OfficeProductsRepresent>();
            foreach (OfficeProducts product in products)
            {
                ProductsRepresents.Add(new OfficeProductsRepresent(product.Product, product.Cost, product.CountProduct));
            }
        }
    }
}
