﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneExchange;

namespace BillingSystem
{
    public class Connect
    {
        private Client _sourceClient;
        private Client _targetClient;
        private DateTime _start;
        private DateTime _end;
        private ConnectInfoState _state;
        public Client SourceClient
        {
            get { return _sourceClient; }
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
        public ConnectInfoState State
        {
            get { return _state; }
        }
        public Connect(Client sourceClient, Client targetClient, DateTime start, DateTime end, ConnectInfoState state)
        {
            _sourceClient = sourceClient;
            _targetClient = targetClient;
            _start = start;
            _end = end;
            _state = state;
        }
    }
}
