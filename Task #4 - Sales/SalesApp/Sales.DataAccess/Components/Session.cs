using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataAccess.Components
{
    public class Session
    {
        public int Id { get; private set; }
        public DateTime? Date { get; set; }
        public string Name { get; set; }

        public Session() { }
        public Session(int id, DateTime? date, string name)
        {
            Id = id;
            Date = date;
            Name = name;
        }
    }
}
