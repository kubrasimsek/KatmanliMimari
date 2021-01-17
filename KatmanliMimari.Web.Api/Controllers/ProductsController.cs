using AutoMapper;
using KatmanliMimari.Web.Api.ApiService;
using KatmanliMimari.Web.Api.Dtos;
//using KatmanliMimari.Web.Dtos;
using KatmanliMimari.Web.Api.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KatmanliMimari.Web.Api.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductApiService _productApiService;
        private readonly IMapper _mapper;

        public ProductsController(ProductApiService productApiService, IMapper mapper)
        {
            _productApiService = productApiService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productApiService.GetAllAsync();

            return View(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        public IActionResult Create()
        {


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            await _productApiService.AddAsync(productDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var product = await _productApiService.GetByIdAsync(id);
            return View(_mapper.Map<ProductDto>(product));

        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            await _productApiService.Update(productDto);
            return RedirectToAction("Index");

        }

        [ServiceFilter(typeof(NotFoundFilterProduct))]
        public async Task<IActionResult> Delete(int id)
        {
            //var product = _productService.GetByIdAsync(id).Result;
            await _productApiService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
