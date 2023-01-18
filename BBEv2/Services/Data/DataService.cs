namespace BBEv2.Services.Data;
using BBEv2.Data;

public class RecordService : IRecordService
{

    private readonly List<Record> _records = new();

    public void CreateRecord(Record record)
    {
        _records.Add(record);
    }
    public List<Record> GetRecordsByUserId(int id)
    {
        List<Record> response = new();
        foreach (var record in _records)
        {
            if (record.idUser == id)
            {
                response.Add(record);
            }
        }
        return response;
    }
    public List<Record> GetRecordsByUserAndCategory(int userId, int categoryId)
    {
        List<Record> response = new();
        foreach (var record in _records)
        {
            if (record.idUser == userId && record.idCategory == categoryId)
            {
                response.Add(record);
            }
        }
        return response;
    }
}




public class CategoryService : ICategoryService
{

    private readonly List<Category> _categories = new();

    public void CreateCategory(Category category)
    {

        _categories.Add(category);
    }
    public List<Category> GetCategories()
    {
        return _categories;
    }

}

public class UserService : IUserService
{

    private readonly List<User> _users = new();

    public void CreateUser(User user)
    {
        _users.Add(user);
    }

}

public class BalanceService : IBalanceService
{

    private readonly List<Balance> _balances = new();

    public void CreateBalance(Balance balance)
    {
        _balances.Add(balance);
    }
    public Balance UpdateBalance(int id, int income)
    {
        foreach (var balance in (_balances)){
            if (balance.id == id)
            {
                balance.balance += income;
                return balance;
            }
        }
        return null;
    }
    public Balance GetBalance(int id)
    {
        foreach (var balance in (_balances))
        {
            if (balance.id == id)
            {
                return balance;
            }
        }
        return null;
    }

}