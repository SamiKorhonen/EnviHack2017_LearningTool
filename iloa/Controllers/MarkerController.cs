using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using iloa.Models;
using Microsoft.Azure.Documents;
using Microsoft.Extensions.Options;
using iloa.DocumentDB;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace iloa.Controllers
{
    [Route("api/[controller]")]
    public class MarkerController : Controller
    {
        private DocumentDBRepository<IloaMarker> IloaMarkerRepository = null;

        private string database;
        private string collection;
        private string authKey;
        private string endPoint;


        public MarkerController(IOptions<AppSettings> settings)
        {
            this.database = settings.Value.database;
            this.collection = settings.Value.collection;
            this.authKey = settings.Value.authkey;
            this.endPoint = settings.Value.endpoint;
            this.IloaMarkerRepository = new DocumentDBRepository<IloaMarker>(database, collection, authKey, endPoint);
        }
        // GET: api/marker
        [HttpGet]
        public async Task<IEnumerable<IloaMarker>> Get()
        //public IEnumerable<IloaMarker> Get()
        {

            return await this.IloaMarkerRepository.GetItemsAsync(x => true);


            //IloaMarker marker = new IloaMarker()
            //{
            //    Id = "TestMarker1",
            //    X = 386020,
            //    Y = 6670057,
            //    Color = "ff0000",
            //    Msg = $"{this.database}, {this.collection}, {this.authKey}, {this.endPoint}",
            //    Shape = 3,
            //    Size = 3
            //};

            //return new List<IloaMarker>() { marker };
        }

        // GET api/marker/5
        [HttpGet("{tag}")]
        public async Task<IEnumerable<IloaMarker>> Get(string tag)
        {
            return await this.IloaMarkerRepository.GetItemsAsync(x => x.Tag == tag);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]IloaMarker value)
        {

            if (!ModelState.IsValid)
            {
                // returns HttpCode 400
                return BadRequest(ModelState);
            }

            await this.IloaMarkerRepository.CreateItemAsync(value);
            return Ok();
    }

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        ///DELETE api/values/5
        [HttpDelete("{tag}")]
        public async Task<ActionResult> Delete(string tag)
        {
            try
            {
                var items = await this.IloaMarkerRepository.GetItemsAsync(x => x.Tag == tag);

                if(items.Count() == 0)
                {
                    return NotFound();
                }
                foreach (var item in items)
                {
                    await this.IloaMarkerRepository.DeleteItemAsync(item.Id);
                }
            }
            catch
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("/api/marker/item/{id}")]
        public async Task<ActionResult> DeleteItem(string id)
        {
            try
            {
               await this.IloaMarkerRepository.DeleteItemAsync(id);
            }
            catch
            {
                return NotFound();
            }
            return Ok();

        }
    }
}
