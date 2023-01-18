namespace BBEv2.Data;

public class Record
{
    public int id { get; }
    public int idUser { get; }
    public int idCategory { get; }
    public DateTime DateTimeOfRecord { get; }
    public int spent { get; }

    public Record(int idUser, int idCategory, int spent)
    {
        this.id = Guid.NewGuid().GetHashCode();
        this.idUser = idUser;
        this.idCategory = idCategory;
        DateTimeOfRecord = DateTime.Now;
        this.spent = spent;
    }
}