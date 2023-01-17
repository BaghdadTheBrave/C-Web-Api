namespace BBEv2.RAPI.Category;

public record GetCategoryResponse(
    int id,
    string name
);
public record GetCategoriesResponse(
    List<GetCategoryResponse> categories
);