using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using EventCatalogAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly EventContext _context;
        private readonly IConfiguration _config;
        public EventController(EventContext context,IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventCategories()
        {
            var items= await  _context.EventCategories.ToListAsync();
            return Ok(items);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventLocations()
        {
            var items = await _context.EventLocations.ToListAsync();
            return Ok(items);
        }
        [HttpGet]
        [Route("items/{id}")]
        public async Task<IActionResult> GetItemsById(int id)
        {
            if (id<=0)
            {
                return BadRequest("Invalid Id!");
            }
            var item = await _context.EventItems.FirstOrDefaultAsync(e => e.Id == id);
            if (item!=null)
            {
                item.EventImageUrl = item.EventImageUrl.Replace("http://externalcatalogbaseurltobereplaced"
                    , _config["ExternalEventBaseUrl"]);
                return Ok(item);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Items(
            [FromQuery]int pageSize=6,
            [FromQuery]int pageIndex=0)
        {
            var itemsCount=await _context.EventItems.LongCountAsync();
            var items = await _context.EventItems
                .OrderBy(e => e.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();
            items = ChangePictureUrl(items);
            //var model=new PaginatedItemsViewModel<EventItem>()
            //{
            //    PageIndex = pageIndex,
            //    PageSize = pageSize,
            //    Count = itemsCount,
            //    Data = items
            //};

            var model = new PaginatedItemsViewModel<EventItem>(pageIndex, pageSize, itemsCount, items);
            return Ok(model);
        }

        //GET api/Catalog/items/withname/Wonder?pageSize=2&pageIndex=0

        [HttpGet]

        [Route("[action]/withname/{name:minlength(1)}")]

        public async Task<IActionResult> Items(string name,

            [FromQuery] int pageSize = 6,

            [FromQuery] int pageIndex = 0)

        {

            var totalItems = await _context.EventItems

                               .Where(c => c.Name.StartsWith(name))

                              .LongCountAsync();

            var itemsOnPage = await _context.EventItems

                              .Where(c => c.Name.StartsWith(name))

                              .OrderBy(c => c.Name)

                              .Skip(pageSize * pageIndex)

                              .Take(pageSize)

                              .ToListAsync();

            itemsOnPage = ChangePictureUrl(itemsOnPage);

            var model = new PaginatedItemsViewModel<EventItem>(pageIndex, pageSize, totalItems, itemsOnPage);



            return Ok(model);



        }



        // GET api/Catalog/Items/type/1/brand/null[?pageSize=4&pageIndex=0]

        [HttpGet]

        [Route("[action]/Category/{eventCategoryId}/Location/{eventLocationId}")]

        public async Task<IActionResult> Items(int? eventCategoryId,

            int? eventLocationId,

            [FromQuery] int pageSize = 6,

            [FromQuery] int pageIndex = 0)

        {

            var root = (IQueryable<EventItem>)_context.EventItems;



            if (eventCategoryId.HasValue)

            {

                root = root.Where(c => c.EventCategoryId == eventCategoryId);

            }

            if (eventLocationId.HasValue)

            {

                root = root.Where(c => c.EventLocationId == eventLocationId);

            }



            var totalItems = await root

                              .LongCountAsync();

            var itemsOnPage = await root



                              .OrderBy(c => c.Name)

                              .Skip(pageSize * pageIndex)

                              .Take(pageSize)

                              .ToListAsync();

            itemsOnPage = ChangePictureUrl(itemsOnPage);

            var model = new PaginatedItemsViewModel<EventItem>(pageIndex, pageSize, totalItems, itemsOnPage);



            return Ok(model);



        }



        [HttpPost]

        [Route("items")]

        public async Task<IActionResult> CreateProduct(

            [FromBody] EventItem product)

        {

            var item = new EventItem

            {

                EventCategoryId = product.EventCategoryId,

                EventLocationId = product.EventLocationId,

                Description = product.Description,

                Name = product.Name,

                //PictureFileName = product.PictureFileName,

                Price = product.Price

            };

            _context.EventItems.Add(item);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItemsById), new { id = item.Id });

        }





        [HttpPut]

        [Route("items")]

        public async Task<IActionResult> UpdateProduct(

            [FromBody] EventItem productToUpdate)

        {

            var catalogItem = await _context.EventItems

                              .SingleOrDefaultAsync

                              (i => i.Id == productToUpdate.Id);

            if (catalogItem == null)

            {

                return NotFound(new { Message = $"Item with id {productToUpdate.Id} not found." });

            }

            catalogItem = productToUpdate;

            _context.EventItems.Update(catalogItem);

            await _context.SaveChangesAsync();



            return CreatedAtAction(nameof(GetItemsById), new { id = productToUpdate.Id });

        }





        [HttpDelete]

        [Route("{id}")]

        public async Task<IActionResult> DeleteProduct(int id)

        {

            var product = await _context.EventItems

                .SingleOrDefaultAsync(p => p.Id == id);

            if (product == null)

            {

                return NotFound();



            }

            _context.EventItems.Remove(product);

            await _context.SaveChangesAsync();

            return NoContent();



        }

        private List<EventItem> ChangePictureUrl(List<EventItem> items)
        {
            items.ForEach(
                e => e.EventImageUrl = e.EventImageUrl.Replace("http://externalcatalogbaseurltobereplaced"
                    , _config["ExternalEventBaseUrl"])
                );
            return items;
        }
    }
}