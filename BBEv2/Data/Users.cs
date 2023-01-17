namespace BBEv2.Data;

public class User
{
    public int id { get; }
    public string name { get; }

    public User(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
}
