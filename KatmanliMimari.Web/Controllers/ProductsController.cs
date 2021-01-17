using AutoMapper;
using KatmanliMimari.Core.Entity;
using KatmanliMimari.Core.Service;
using KatmanliMimari.Web.Controllers.Dtos;
//using KatmanliMimari.Web.Dtos;
using KatmanliMimari.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KatmanliMimari.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();

            return View(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        public IActionResult Create()
        {


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            await _productService.AddAsync(_mapper.Map<Product>(productDto));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return View(_mapper.Map<ProductDto>(product));

        }
        [HttpPost]
        public IActionResult Update(ProductDto productDto)
        {
            _productService.Update(_mapper.Map<Product>(productDto));
            return RedirectToAction("Index");

        }

        [ServiceFilter(typeof(NotFoundFilterProduct))]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetByIdAsync(id).Result;
            _productService.Remove(product);
            return RedirectToAction("Index");
        }
    }
}
