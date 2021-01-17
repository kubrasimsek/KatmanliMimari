using KatmanliMimari.Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KatmanliMimari.Web.Controllers.Dtos;

namespace KatmanliMimari.Web.Filters
{
    public class NotFoundFilterProduct : ActionFilterAttribute
    {
        private readonly IProductService _productService;
        public NotFoundFilterProduct(IProductService productService)
        {
            _productService = productService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var product = await _productService.GetByIdAsync(id);
            if (product != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();

                errorDto.Errors.Add($"id si {id} olan ürün veritabında bulunamadı.");
                context.Result = new RedirectToActionResult("Error", "Home", errorDto);
            }
        }
    }
}
