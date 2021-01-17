using KatmanliMimari.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliMimari.Core.Service
{
    public interface IProductService:IService<Product>
    {
        //bool ControlInnerBarcode(Product product);

        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
