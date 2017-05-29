using System;

namespace TelephoneExchange.StationCompoment
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
                throw new ArgumentException("No more six numbers in number");

            _operatorCode = operatorCode;
            _number = number;
        }

        public static bool operator ==(PhoneNumber p1, PhoneNumber p2)
        {
            return p1.OperatorCode == p2.OperatorCode && p1.Number == p2.Number;
        }

        public static bool operator !=(PhoneNumber p1, PhoneNumber p2)
        {
            return !(p1 == p2);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
