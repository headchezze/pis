using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace WCFLibrary
{
    public static class DBSetExtesion
    {
        public static Offices GetOffice(this DbSet<Offices> offices, string orgName, string address)
        {
            return offices.Where(i => i.Adress == address && i.OrgName == orgName).First();
        }

        public static IQueryable<OfficeProducts> GetProducts(this DbSet<OfficeProducts> products, string address, string org)
        {
            return products.Where(i => i.Offices.Adress == address && i.Offices.OrgName == org);
        }

        public static Workers GetWorker(this DbSet<Workers> workers, string login, string password)
        {
            return workers.Where(i => i.Login == login && i.Password == password).FirstOrDefault();
        }

        public static IQueryable<Offices> GetOffices(this DbSet<Offices> offices, string orgName = "", string orgType = "")
        {
            if (orgName == "" && orgType == "")
                return offices;
            
            return offices.Where(i => i.Orgs.Type == orgType || i.Orgs.OrgName == orgName);
        }

        public static List<OfficeRepresent> AddOffices(this List<OfficeRepresent> represents, IQueryable<Offices> offices)
        {
            foreach (Offices office in offices)
            {
                represents.Add(new OfficeRepresent(office.Adress, office.OrgName, office.Orgs.Type));
            }

            return represents;
        }

        public static List<ProductRepresent> AddProducts(this List<ProductRepresent> products, IQueryable<Products> systemProducts)
        {
            foreach(Products product in systemProducts)
            {
                products.Add(new ProductRepresent(product.ProductName, product.Desription));
            }

            return products;
        }

        public static List<string> GetProductsNames(this ProductRepresent[] products)
        {
            List<string> names = new List<string>();

            foreach(ProductRepresent product in products)
            {
                names.Add(product.Name);
            }

            return names;
        }

        public static OfficeProducts GetProduct(this DbSet<OfficeProducts> products, string address, string org, string productName)
        {
            return products.Where(i => i.Product == productName && i.Offices.Adress == address && i.Offices.OrgName == org).First();
        }
    }
}
