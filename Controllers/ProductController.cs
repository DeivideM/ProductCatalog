using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Entities;
using ProductCatalog.Repositories;
using ProductCatalog.ViewModels;
using ProductCatalog.ViewModels.ProductViewModels;
using System;
using System.Collections.Generic;

namespace ProductCatalog.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _repository;
        public ProductController(ProductRepository repository)
        {
            _repository = repository;
        }

        [Route("v1/products")]
        [HttpGet]
        public IEnumerable<ListProductViewModel> Get()
        {
            return _repository.Get();
        }

        [Route("v1/products/{id}")]
        [HttpGet]
        public Product Get(int id)
        {
            return _repository.Get(id);
        }

        [Route("v1/products")]
        [HttpPost]
        public ActionResult Post([FromBody]EditorProductViewModel model)
        {
            //if (!ModelState.IsValid)
            //    return;

            var product = new Product();
            product.ProductName = model.ProductName;
            product.CategoryId = model.CategoryId;
            product.CreateDate = DateTime.Now; //Never receive this info
            product.Description = model.Description;
            product.Image = model.Image;
            product.LastUpdateDate = DateTime.Now; //Never receive this info
            product.Price = model.Price;
            product.Quantity = model.Quantity;

            _repository.Save(product);

            return Ok(product);
        }

        [Route("v1/products")]
        [HttpPut]
        public ActionResult Put([FromBody]EditorProductViewModel model)
        {
            var product = _repository.Get(model.ProductId);
            product.ProductName = model.ProductName;
            product.CategoryId = model.CategoryId;
            //product.CreateDate = DateTime.Now; //Never receive this info
            product.Description = model.Description;
            product.Image = model.Image;
            product.LastUpdateDate = DateTime.Now; //Never receive this info
            product.Price = model.Price;
            product.Quantity = model.Quantity;

            _repository.Update(product);

            return Ok(product);
        }
    }
}
