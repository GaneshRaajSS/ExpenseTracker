using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface ICategory
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(int id);
        Task<bool> PutCategoryAsync(int id, Category category);
        Task<Category> PostCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
