using System;

namespace TelephoneExchange.StationComponent
{
    public struct PhoneNumber
    {
        public ushort OperatorCode { get; }

        public uint Number { get; }

        public PhoneNumber(ushort operatorCode, uint number)
        {
            if (operatorCode > 999)
                throw new ArgumentException("No more three numbers in operator code");
            if (number > 999999)
                throw new ArgumentException("No more six numbers in number");

            OperatorCode = operatorCode;
            Number = number;
        }

        public static bool operator ==(PhoneNumber p1, PhoneNumber p2)
        {
            return p1.OperatorCode == p2.OperatorCode && p1.Number == p2.Number;
        }

        public static bool operator !=(PhoneNumber p1, PhoneNumber p2)
        {
            return !(p1 == p2);
        }

        public bool Equals(PhoneNumber other)
        {
            return OperatorCode == other.OperatorCode && Number == other.Number;
        }

        public override bool Equals(object obj)
        {
            return obj is PhoneNumber other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (OperatorCode.GetHashCode() * 397) ^ (int)Number;
            }
        }
    }
}
