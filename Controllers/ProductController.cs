using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CoffeeMug.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CoffeeMug.Persistence;
using CoffeeMug.Core;

namespace CoffeeMug.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IProductRepository context, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._repository = context;
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        // GET: api/product
        [HttpGet]
        public async Task<List<Product>> Get()
        {
            return await _repository.GetProducts();
        }

        // GET: api/product/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await _repository.GetProduct(id);

            if (product == null)
                return NotFound();
            else
                return Ok(product);
        }

        // POST: api/Todo
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProductCreateInputModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _repository.GetProduct(model.Id) != null)
                return BadRequest("Id not unique");    
            var product = _mapper.Map<ProductCreateInputModel, Product>(model);
            _repository.Add(product);

            await _unitOfWork.CompleteAsync();

            return Ok(product.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody]ProductUpdateInputModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _repository.GetProduct((Guid)model.Id);

            if (product == null)
                return NotFound();

           var result = _mapper.Map<ProductUpdateInputModel, Product>(model, product);

            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await _repository.GetProduct(id);

            if (product == null)
                return NotFound();

            _repository.Remove(product);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}