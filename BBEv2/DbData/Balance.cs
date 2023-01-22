using System;
using System.Collections.Generic;

namespace BBEv2.DbData
{
    public partial class Balance
    {
        public long Id { get; set; }
        public long Balance1 { get; set; }
        public Balance(int id)
        {
            this.Id = id;
            this.Balance1 = 0;
        }
        public Balance()
        {
            this.Id = 123;
            this.Balance1 = 0;
        }
    }
}
