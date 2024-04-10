using Notes.Domain.Entities;
using Notes.Domain.Ports;
using Notes.Domain.Services.Base;

namespace Notes.Domain.Services;

[DomainService]
public class CategoryService
{
    private readonly IGenericRepository<Category> _categoryRepository;
    public CategoryService(IGenericRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository), "No repository available");
    }

    public async Task<IEnumerable<Category>> GetCategoriesByUserIdAsync(Guid userId)
    {
        return await _categoryRepository.GetAsync(x => x.UserId == userId);
    }

    public async Task<IEnumerable<Category>> GetCategoriesByIdAsync(Guid Id)
    {
        return await _categoryRepository.GetAsync(x => x.Id == Id);
    }

    public async Task<Category> AddCategoryAsync(Category category)
    {
        return await _categoryRepository.AddAsync(category);
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        await _categoryRepository.UpdateAsync(category);
    }

    public async Task DeleteCategoryAsync(Category category)
    {
        await _categoryRepository.DeleteAsync(category);
    }
}
