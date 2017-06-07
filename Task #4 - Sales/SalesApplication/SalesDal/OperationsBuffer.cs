namespace SalesDal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OperationsBuffer")]
    public partial class OperationsBuffer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public DateTime? DateOfOperation { get; set; }

        public int? Manager_ID { get; set; }

        public int? Client_ID { get; set; }

        public int? Product_ID { get; set; }

        public int? Price { get; set; }

        public virtual Client Client { get; set; }

        public virtual Manager Manager { get; set; }

        public virtual Product Product { get; set; }
    }
}
