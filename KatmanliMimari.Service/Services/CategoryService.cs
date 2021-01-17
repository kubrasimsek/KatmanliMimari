using KatmanliMimari.Core.Entity;
using KatmanliMimari.Core.Repository;
using KatmanliMimari.Core.Service;
using KatmanliMimari.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliMimari.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await _unitOfWork.Category.GetWithProductsByIdAsync(categoryId);
        }
    }
}
