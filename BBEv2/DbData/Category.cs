using System;
using System.Collections.Generic;

namespace BBEv2.DbData
{
    public partial class Category
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public Category(string name)
        {
            this.Id = Guid.NewGuid().GetHashCode()%1000000;
            this.Name = name;
        }
        public Category()
        {
            this.Id = 123;
            this.Name = "a";
        }
    }
}
