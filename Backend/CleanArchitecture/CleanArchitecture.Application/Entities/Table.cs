using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities
{
    public class Table: AuditableBaseEntity
    {
        public string Description { get; set; }
        public string Active { get; set; }

        //public Order Order { get; set; }
    }
}
