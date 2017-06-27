using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sales.MVCClient.Models.Pagination
{
    public class IndexViewModelPagination
    {
        public IEnumerable<Client> ClientsPerPages { get; set; }
        public IEnumerable<Manager> ManagersPerPages { get; set; }
        public IEnumerable<Operation> OperationsPerPages { get; set; }
        public IEnumerable<Product> ProductsPerPages { get; set; }
        public IEnumerable<PriceHistory> PriceHistoriesPerPages { get; set; }
        public PageInfo PageInfo { get; set; }
        public ItemsList ItemsList { get; set; }

        public Client ClientForLabel { get; set; }
        public Manager ManagerForLabel { get; set; }
        public Operation OperationForLabel { get; set; }
        public Product ProductForLabel { get; set; }
        public PriceHistory PriceHistoryForLabel { get; set; }
    }
}