using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataAccess.Components
{
    public class Operation
    {
        public int Id { get; private set; }
        public DateTime? DateOfOperation { get; set; }
        public Manager Manager { get; set; }
        public Client Client { get; set; }
        public Product Product { get; set; }
        public Session Session { get; set; }
        public int? Price { get; set; }

        public Operation() { }
        public Operation(int id, DateTime? dateOfOperation, Manager manager, Client client, Product product, Session session, int? price)
        {
            Id = id;
            DateOfOperation = dateOfOperation;
            Manager = manager;
            Client = client;
            Product = product;
            Session = session;
            Price = price;
        }
    }
}
