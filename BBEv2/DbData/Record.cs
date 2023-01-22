using System;
using System.Collections.Generic;

namespace BBEv2.DbData
{
    public partial class Record
    {
        public long Id { get; set; }
        public long IdUser { get; set; }
        public long IdCategory { get; set; }
        public DateTime DateTimeOfRecord { get; set; }
        public long Spent { get; set; }
        public Record(int idUser, int idCategory, int spent)
        {
            this.Id = Guid.NewGuid().GetHashCode()%1000000;
            this.IdUser = idUser;
            this.IdCategory = idCategory;
            DateTimeOfRecord = DateTime.Now;
            this.Spent = spent;
        }
        public Record()
        {
            this.Id = 123;
            this.IdUser = 123;
            this.IdCategory = 123;
            DateTimeOfRecord = DateTime.Now;
            this.Spent = 123;
        }
    }
}
