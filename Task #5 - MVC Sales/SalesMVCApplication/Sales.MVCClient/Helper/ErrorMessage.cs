using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sales.MVCClient.Helper
{
    public class ErrorMessage
    {
        public string Get(Exception e)
        {
            Exception error = e;
            while (error.InnerException != null)
                error = error.InnerException;
            return error.Message;
        }
    }
}