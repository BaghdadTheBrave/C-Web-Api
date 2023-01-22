 using BBEv2.RAPI.user;
using BBEv2.RAPI.Category;
using BBEv2.RAPI.Record;
using BBEv2.DbData;
using Microsoft.AspNetCore.Mvc;
using BBEv2.Services.Data;
using BBEv2.RAPI.Balance;

namespace BBEv2.Controllers;

[ApiController]
public class BBEv2Controller : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IRecordService _recordService;
    private readonly ICategoryService _categoryService;
    private readonly IBalanceService _balanceService;

    [ActivatorUtilitiesConstructor]
    public BBEv2Controller(IUserService userService, IRecordService recordService, ICategoryService categoryService, IBalanceService balanceService)
    {
        _userService = userService;
        _recordService = recordService;
        _categoryService = categoryService;
        _balanceService = balanceService;
    }



    [HttpPost("/User")]
    public IActionResult CreateUser(CreateUserRequest request)
    {
        var user = new User(request.name);
        _userService.CreateUser(user);
        var balance = new Balance((int)user.Id);
        _balanceService.CreateBalance(balance);

        return Ok(user);
    }
    [HttpPost("/Category")]
    public IActionResult CreateCategory(CreateCategoryRequest request)
    {
        var Category = new Category(request.name);
        _categoryService.CreateCategory(Category);
        return Ok(Category);
    }
    [HttpPost("/Record")]
    public IActionResult CreateRecord(CreateRecordRequest request)
    {
        var record = new Record(request.idUser, request.idCategory, request.spent);
        _recordService.CreateRecord(record);
        _balanceService.UpdateBalance((int)record.IdUser, -(int)record.Spent);
        return Ok(record);
    }



    private static GetCategoriesResponse MapCategories(List<Category> categoriesList)
    {
        var response = new GetCategoriesResponse(new List<GetCategoryResponse>());

        foreach (var category in categoriesList)
        {
            response.categories.Add(new GetCategoryResponse((int)category.Id, category.Name));
        }
        return response;
    }

    [HttpGet("/Category")]
    public IActionResult GetCategories()
    {

        return Ok(MapCategories(_categoryService.GetCategories()));
    }




    private static GetRecordsResponse MapRecords(List<Record> recordsList)
    {
        var response = new GetRecordsResponse(new List<GetRecordResponse>());

        foreach (var record in recordsList)
        {
            response.records.Add(new GetRecordResponse((int)record.Id, (int)record.IdUser, (int)record.IdCategory,
                record.DateTimeOfRecord, (int)record.Spent));
        }
        return response;
    }
    [HttpGet("/Record/{idUser:int}")]
    public IActionResult GetRecordsByUserId(int idUser)
    {
        return Ok(MapRecords(_recordService.GetRecordsByUserId(idUser)));
    }
    [HttpGet("/Record/{idUser:int}/{idCategory:int}")]
    public IActionResult GetRecordsByUserIdAndByCategoryId(int idUser, int idCategory)
    {
        return Ok(MapRecords(_recordService.GetRecordsByUserAndCategory(idUser, idCategory)));
    }
    [HttpPut("/Balance")]
    public IActionResult UpdateBalance(UpdateBalanceRequest request)
    {
        var balance = _balanceService.UpdateBalance(request.id, request.income);
        var response = new UpdateBalanceResponse((int)balance.Id, (int)balance.Balance1);

        return Ok(response);
    }
    [HttpGet("/Balance/{idBalance:int}")]
    public IActionResult GetBalance(int idBalance)
    {
        var balance = _balanceService.GetBalance(idBalance);
        var response = new GetBalanceResponse((int)balance.Id, (int)balance.Balance1);

        return Ok(response);
    }
}