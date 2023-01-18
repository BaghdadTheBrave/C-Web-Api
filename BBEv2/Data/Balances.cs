namespace BBEv2.Data;

public class Balance
{
    public int id { get; }
    public int balance { get; set; }

    public Balance(int id)
    {
        this.id = id;
        this.balance = 0;
    }
}
