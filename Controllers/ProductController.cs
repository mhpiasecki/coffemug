using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CoffeeMug.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CoffeeMug.Persistence;

namespace CoffeeMug.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductController(ProductRepository context, IMapper mapper)
        {
            this._repository = context;
            this._mapper = mapper;
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
            //TODO: check mapping
            var product = _mapper.Map<ProductCreateInputModel, Product>(model);


            // TODO: create repository
            // repository.Add(vehicle);
            // await unitOfWork.CompleteAsync();

            // vehicle = await repository.GetVehicle(vehicle.Id);

            // var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            // return Ok(result);
            // _repository.Products.Add();
            return Ok(model.Id);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody]ProductUpdateInputModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _repository.GetProduct(model);

            if (product == null)
            return NotFound();

            _mapper.Map<ProductUpdateInputModel, Product>(model)
            return Ok();
            throw new NotImplementedException(); //dodać mapper;

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var product = _repository.Products.Find(p => p.Id == id);


            if (product == null)
                return NotFound();

            _repository.Products.Remove(product);

            return Ok(id);
        }
    }
}