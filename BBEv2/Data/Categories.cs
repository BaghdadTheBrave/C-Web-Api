namespace BBEv2.Data;

public class Category
{
    public int id { get; }
    public string name { get; }

    public Category(string name)
    {
        this.id = Guid.NewGuid().GetHashCode();
        this.name = name;
    }
}