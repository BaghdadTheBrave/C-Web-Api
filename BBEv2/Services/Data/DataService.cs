namespace BBEv2.Services.Data;
using BBEv2.DbData;
using BBEv2.Context;

public class RecordService : IRecordService
{

    private readonly BBEl2Context context = new BBEl2Context();

    public void CreateRecord(Record record)
    {
        
        context.Records.Add(record);
        context.SaveChanges();
    }
    public List<Record> GetRecordsByUserId(int id)
    {
        var _records = context.Records;
        List<Record> response = new();
        foreach (var record in _records)
        {
            if (record.IdUser == id)
            {
                response.Add(record);
            }
        }
        return response;
    }
    public List<Record> GetRecordsByUserAndCategory(int userId, int categoryId)
    {
        var _records = context.Records;
        List<Record> response = new();
        foreach (var record in _records)
        {
            if (record.IdUser == userId && record.IdCategory == categoryId)
            {
                response.Add(record);
            }
        }
        return response;
    }
}




public class CategoryService : ICategoryService
{

    private readonly BBEl2Context context = new BBEl2Context();

    public void CreateCategory(Category category)
    {
        context.Categories.Add(category);
        context.SaveChanges();
    }
    public List<Category> GetCategories()
    {
        var _categories = context.Categories;
        List<Category> response = new();
        foreach (var category in _categories)
        {
            response.Add(category);
        }
        return response;
    }

}

public class UserService : IUserService
{

    private readonly BBEl2Context context = new BBEl2Context();

    public void CreateUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }

}

public class BalanceService : IBalanceService
{

    private readonly BBEl2Context context = new BBEl2Context();

    public void CreateBalance(Balance balance)
    {
        context.Balances.Add(balance);
        context.SaveChanges();
    }
    public Balance UpdateBalance(int id, int income)
    {
        var _balances = context.Balances;
        foreach (var balance in (_balances)){
            if (balance.Id == id)
            {
                balance.Balance1 += income;
                return balance;
            }
        }
        return null;
    }
    public Balance GetBalance(int id)
    {
        var _balances = context.Balances;
        foreach (var balance in (_balances))
        {
            if (balance.Id == id)
            {
                return balance;
            }
        }
        return null;
    }

}