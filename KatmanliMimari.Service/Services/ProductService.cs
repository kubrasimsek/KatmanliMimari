using KatmanliMimari.Core.Entity;
using KatmanliMimari.Core.Repository;
using KatmanliMimari.Core.Service;
using KatmanliMimari.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliMimari.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
          return await _unitOfWork.Product.GetWithCategoryByIdAsync(productId);
        }
    }
}
