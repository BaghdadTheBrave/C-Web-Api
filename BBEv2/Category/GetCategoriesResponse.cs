namespace BBE_1.RAPI.Category;

public record GetCategoryResponse(
    int id,
    string name
);
public record GetCategoriesResponse(
    List<GetCategoryResponse> categories
);