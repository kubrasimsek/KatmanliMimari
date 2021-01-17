using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KatmanliMimari.Web.Api.Dtos;
using KatmanliMimari.Web.Api.ApiService;

namespace KatmanliMimari.Web.Api.Filters
{
    public class NotFoundFilterProduct : ActionFilterAttribute
    {
        private readonly ProductApiService _productApiService;
        public NotFoundFilterProduct(ProductApiService productApiService)
        {
            _productApiService = productApiService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var product = await _productApiService.GetByIdAsync(id);
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
