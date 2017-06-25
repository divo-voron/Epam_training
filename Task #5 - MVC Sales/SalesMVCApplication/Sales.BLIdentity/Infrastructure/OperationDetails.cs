using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BLIdentity.Infrastructure
{
    // класс об успешности операции
    public class OperationDetails
    {
        public OperationDetails(bool succedeed, string message, string prop)
        {
            Succedeed = succedeed;
            Message = message;
            Property = prop;
        }

        // флаг операции
        public bool Succedeed { get; private set; }
        public string Message { get; private set; }
        public string Property { get; private set; }
    }
}
