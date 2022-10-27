using Entities;
using FinalApp.Areas.Admin.DTos;
using RepositoryServices.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FinalApp.Areas.Admin.Controllers.ApiControllers
{
    public class ProductApiController : BaseClassController
    {


        [HttpGet]
        public ActionResult GetAllProductsChart(int count, string sortOrder)
        {
            var products = unit.Products.GetAll()
                .Select(x => new ProductDto { Id = x.Id, Name = x.Onoma, Quantity = x.Quantity, Price = x.Price })
                .Take(count);

            switch (sortOrder)
            {
                case "ASC": products = products.OrderBy(x => x.Quantity).ToList(); break;
                case "DESC": products = products.OrderByDescending(x => x.Quantity).ToList(); break;
                default: products = products.OrderBy(x => x.Quantity).ToList(); break;
            }

            return Json(products, JsonRequestBehavior.AllowGet);  //Onoma, Price, Quantity
        }




        [HttpGet]
        public ActionResult GetAllProducts()
        {
            var products = unit.Products.GetAll()
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Onoma,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Shop = new { Title = x.Shop?.Title }
                });
            return Json(products, JsonRequestBehavior.AllowGet);  //Onoma, Price, Quantity
        }





        [HttpGet]
        public ActionResult GetProductById(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = unit.Products.GetById(id);

            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            ProductDto productDto = new ProductDto()
            {
                Id = product.Id,
                Name = product.Onoma,
                Quantity = product.Quantity,
                Price = product.Price
            };
            return Json(productDto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateProduct(ProductDto dto,int? shopId)   //Name,Price, Quantity
        {
            //Mapping
            Product product = new Product();
            product.Onoma = dto.Name;
            product.Price = dto.Price;
            product.Quantity = dto.Quantity;
            product.Shop = unit.Shops.GetById(shopId);

            if (ModelState.IsValid)
            {
                unit.Products.Insert(product);
                unit.Complete();

                //Mapping
                ProductDto productDto = new ProductDto();
                productDto.Id = product.Id;
                productDto.Name = product.Onoma;
                productDto.Quantity = product.Quantity;
                productDto.Price = product.Price;
                productDto.Shop = new {product.Shop?.Title, product.Shop?.Id};                

                return Json(productDto, JsonRequestBehavior.AllowGet);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        public ActionResult GetAllShops()
        {
            var shops = unit.Shops.GetAll().Select(x => new { x.Title, x.Id });
            return Json(shops, JsonRequestBehavior.AllowGet);
        }




        [HttpPut]
        public ActionResult UpdateProduct(int? id, ProductDto dto)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = unit.Products.GetById(id);

            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            //Mapping
            product.Onoma = dto.Name;
            product.Price = dto.Price;
            product.Quantity = dto.Quantity;

            if (ModelState.IsValid)
            {
                unit.Products.Update(product);
                unit.Complete();
                return Json(product, JsonRequestBehavior.AllowGet);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        public ActionResult DeleteProduct(int? id)
        {
            if (id is null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = unit.Products.GetById(id);

            if (product is null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            unit.Products.Delete(id);
            unit.Complete();

            //Mapping
            ProductDto productDto = new ProductDto()
            {
                Id = product.Id,
                Name = product.Onoma,
                Price = product.Price,
                Quantity = product.Quantity
            };


            return Json(productDto, JsonRequestBehavior.AllowGet);
        }







    }
}