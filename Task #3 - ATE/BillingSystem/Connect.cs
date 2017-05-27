using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    public class Connect
    {
        private Client _sourceClient;
        private Tariff _sourceClientTariff;
        private Client _targetClient;
        private DateTime _start;
        private DateTime _end;
        public Client SourceClient
        {
            get { return _sourceClient; }
        }
        public Tariff SourceClientTariff
        {
            get { return _sourceClientTariff; }
        }
        public Client TargetClient
        {
            get { return _targetClient; }
        }
        public DateTime Start
        {
            get { return _start; }
        }
        public DateTime End
        {
            get { return _end; }
        }
        public TimeSpan Duration
        {
            get { return _end - _start; }
        }

        public Connect(Client sourceClient,Tariff sourceClientTariff, Client targetClient, DateTime start, DateTime end)
        {
            _sourceClient = sourceClient;
            _sourceClientTariff = sourceClientTariff;
            _targetClient = targetClient;
            _start = start;
            _end = end;
        }
    }
}
