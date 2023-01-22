using System;
using System.Collections.Generic;

namespace BBEv2.DbData
{
    public partial class User
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public User(string name)
        {
            this.Id = Guid.NewGuid().GetHashCode()%1000000;
            this.Name = name;
        }
        public User()
        {
            this.Id = 123;
            this.Name = "123";
        }
    }
}
