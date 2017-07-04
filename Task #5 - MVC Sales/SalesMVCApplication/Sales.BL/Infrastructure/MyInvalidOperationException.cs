using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BL.Infrastructure
{
    public class MyInvalidOperationException : InvalidOperationException
    {
        public string ErrorMessage { get; private set; }
        public MyInvalidOperationException(string error)
        {
            ErrorMessage = error;
        }
    }
}
