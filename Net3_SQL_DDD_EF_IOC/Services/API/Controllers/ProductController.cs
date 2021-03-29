using System;
using System.Collections;
using System.Collections.Generic;
using Application.API.Application.Dtos;
using Application.API.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Services.API.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductServiceApplication _productApplicationService;
        
        public ProductController(IProductServiceApplication ApplicationService)
        {
            _productApplicationService = ApplicationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_productApplicationService.GetAll());
        }

        [HttpPost]
        public ActionResult Post(
            [FromBody] ProductDto productDto
            )
        {
            try
            {
                if(productDto == null)
                return NotFound();
                
                _productApplicationService.Add(productDto);
                return Ok("Product registred successfully!");
            }

            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        
        [HttpPut]
        public ActionResult Put(
            [FromBody] ProductDto productDto
            )
        {
            try
            {
                if(productDto == null)
                return NotFound();
                
                _productApplicationService.Update(productDto);
                return Ok("Product updated sucessfully!");
            }

            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        [HttpDelete]
        public ActionResult Delete(
            [FromBody] ProductDto productDto
            )
        {
            try
            {
                if(productDto == null)
                return NotFound();
                
                _productApplicationService.Remove(productDto);
                return Ok("Product removed Successfully!");
            }

            catch (Exception ex)
            {
                
                throw ex;
            
        }

       }   }
}