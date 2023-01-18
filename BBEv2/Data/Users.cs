namespace BBEv2.Data;

public class User
{
    public int id { get; }
    public string name { get; }

    public User(string name)
    {
        this.id = Guid.NewGuid().GetHashCode();
        this.name = name;
    }
}
