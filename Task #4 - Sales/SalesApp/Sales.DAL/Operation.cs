namespace Sales.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Operation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public DateTime? DateOfOperation { get; set; }

        public int? Manager_ID { get; set; }

        public int? Client_ID { get; set; }

        public int? Product_ID { get; set; }

        public int? Price { get; set; }

        public int? Session_ID { get; set; }

        public virtual Client Client { get; set; }

        public virtual Manager Manager { get; set; }

        public virtual Product Product { get; set; }

        public virtual Session Session { get; set; }
    }
}
