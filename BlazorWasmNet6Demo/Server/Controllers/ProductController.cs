﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWasmNet6Demo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {


            private static List<Product> Products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Title = "The Hitchhiker's Guide to the Galaxy",
                Description = "The various versions follow the same basic plot but they are in many places mutually contradictory, as Adams rewrote the story substantially for each new adaptation. The various versions follow the same basic plot but they are in many places mutually contradictory, as Adams rewrote the story substantially for each new adaptation. The various versions follow the same basic plot but they are in many places mutually contradictory, as Adams rewrote the story substantially for each new adaptation. The various versions follow the same basic plot but they are in many places mutually contradictory, as Adams rewrote the story substantially for each new adaptation.",
                ImageUrl ="https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg",
                Price = 9.99m
            },
            new Product
            {
                Id = 2,
                Title = "Ready Player One",
                Description = "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The various versions follow the same basic plot but they are in many places mutually contradictory, as Adams rewrote the story substantially for each new adaptation. The various versions follow the same basic plot but they are in many places mutually contradictory, as Adams rewrote the story substantially for each new adaptation.",
                ImageUrl ="https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg",
                Price = 7.99m
            },
            new Product
            {
                Id = 3,
                Title = "Ready Player Two",
                Description = "Ready Player Two is a 2020 science fiction novel by American author Ernest Cline. The various versions follow the same basic plot but they are in many places mutually contradictory, as Adams rewrote the story substantially for each new adaptation. The various versions follow the same basic plot but they are in many places mutually contradictory, as Adams rewrote the story substantially for each new adaptation. The various versions follow the same basic plot but they are in many places mutually contradictory, as Adams rewrote the story substantially for each new adaptation.",
                ImageUrl ="https://upload.wikimedia.org/wikipedia/en/c/cd/Ready_Player_Two_-_book_cover.jpg",
                Price = 8.99m
            }

        };


        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProduct()
        {
              return Ok(Products); 
        }
    }
}
