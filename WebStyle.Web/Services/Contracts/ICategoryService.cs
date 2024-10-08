using WebStyle.Web.Models;

namespace WebStyle.Web.Services.Contracts;

public interface ICategoryService
{
    Task<IEnumerable<CategoryViewModel>> GetAllCategories(string token);
}
