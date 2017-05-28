using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public struct PhoneNumber
    {
        private ushort _operatorCode;
        private uint _number;
        public ushort OperatorCode
        {
            get { return _operatorCode; }
        }
        public uint Number
        {
            get { return _number; }
        }
        public PhoneNumber(ushort operatorCode, uint number)
        {
            if (operatorCode > 999)
                throw new ArgumentException("No more three numbers in operator code");
            if (number > 999999)
                throw new ArgumentException("No more six numbers in operator code");

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
                return _operatorCode == ((PhoneNumber)obj).OperatorCode && _number == ((PhoneNumber)obj).Number;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
