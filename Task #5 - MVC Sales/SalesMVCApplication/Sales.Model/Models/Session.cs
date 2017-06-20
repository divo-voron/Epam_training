using System;
using System.Collections.Generic;

namespace Sales.Model.Models
{
    public partial class Session
    {
        public Session()
        {
            this.Operations = new List<Operation>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public System.DateTime Date { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
