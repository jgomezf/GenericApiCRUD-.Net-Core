using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.BulkOperation
{
    public class ChildAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
