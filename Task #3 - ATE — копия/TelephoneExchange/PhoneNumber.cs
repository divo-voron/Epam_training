using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public struct PhoneNumber
    {
        private string _operatorCode;
        private string _number;
        public string OperatorCode
        {
            get { return _operatorCode; }
        }
        public string Number
        {
            get { return _number; }
        }
        public PhoneNumber(string operatorCode, string number)
        {
            _operatorCode = operatorCode;
            _number = number;
        }

        public static bool operator ==(PhoneNumber p1, PhoneNumber p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(PhoneNumber p1, PhoneNumber p2)
        {
            return !p1.Equals(p2);
        }

        public override bool Equals(object obj)
        {
            if (obj is PhoneNumber)
                return _operatorCode.Equals(((PhoneNumber)obj).OperatorCode) && _number.Equals(((PhoneNumber)obj).Number);
            else 
                return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
