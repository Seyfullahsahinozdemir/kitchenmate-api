using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Table.Queries.GetAllTables
{
    public class GetAllTablesViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Order Order { get; set; }
        public string Active { get; set; }
    }
}
