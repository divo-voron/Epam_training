using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataAccess.Components
{
    class Session
    {
        public DateTime? DateOfOperation { get; set; }
        public int? Name { get; set; }

        public Session(DateTime? dateOfOperation, int? name)
        {
            DateOfOperation = dateOfOperation;
            Name = name;
        }
    }
}
