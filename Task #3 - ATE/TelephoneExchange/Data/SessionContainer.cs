using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    class SessionContainer : ICollection<Session>
    {
        private ICollection<Session> _sessions;
        public SessionContainer()
        {
            _sessions = new List<Session>();
        }

        public Session GetBySource(IPort port)
        {
            return _sessions.FirstOrDefault(x => x.Source == port);
        }
        public Session GetBySource(IPort port, SessionState state)
        {
            return _sessions.FirstOrDefault(x => x.Source == port && x.State == state);
        }
        public Session GetByTarget(IPort port)
        {
            return _sessions.FirstOrDefault(x => x.Target == port);
        }
        public Session GetByTarget(IPort port, SessionState state)
        {
            return _sessions.FirstOrDefault(x => x.Target == port && x.State == state);
        }
        public Session GetByAny(IPort port)
        {
            return _sessions.FirstOrDefault(x => x.Source == port || x.Target == port);
        }
        public Session GetByAny(IPort port, SessionState state)
        {
            return _sessions.FirstOrDefault(x => x.State == state && (x.Source == port || x.Target == port));
        }

        public bool IsOpenedSession(IPort sourcePort, IPort targetPort)
        {
            return this.GetBySource(sourcePort) == null && this.GetByTarget(targetPort) == null;
        }

        public void Add(Session item)
        {
            _sessions.Add(item);
        }

        public void Clear()
        {
            _sessions.Clear();
        }

        public bool Contains(Session item)
        {
            return _sessions.Contains(item);
        }

        public void CopyTo(Session[] array, int arrayIndex)
        {
            _sessions.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _sessions.Count; }
        }

        public bool IsReadOnly
        {
            get { return _sessions.IsReadOnly; }
        }

        public bool Remove(Session item)
        {
            return _sessions.Remove(item);
        }

        public IEnumerator<Session> GetEnumerator()
        {
            return _sessions.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _sessions.GetEnumerator();
        }
    }
}
