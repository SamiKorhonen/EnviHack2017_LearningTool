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
        public MarkerController(IOptions<AppSettings> settings)
        {
            DocumentDBRepository<IloaMarker>.CollectionId = settings.Value.Collection;
            DocumentDBRepository<IloaMarker>.DatabaseId = settings.Value.Database;
            DocumentDBRepository<IloaMarker>.AuthKey = settings.Value.AuthKey;
            DocumentDBRepository<IloaMarker>.EndPoint = settings.Value.EndPoint;

        }
        // GET: api/marker
        [HttpGet]
        public async Task<IEnumerable<IloaMarker>> Get()
        {
            return await DocumentDBRepository<IloaMarker>.GetItemsAsync(x => true);


            //IloaMarker marker = new IloaMarker()
            //{
            //    Id = "TestMarker1",
            //    X = 386020,
            //    Y = 6670057,
            //    Color = "ff0000",
            //    Msg = "TestMarker",
            //    Shape = 3,
            //    Size = 3
            //};

            //return new List<IloaMarker>() { marker };
        }

        // GET api/marker/5
        [HttpGet("{id}")]
        public IloaMarker Get(int id)
        {
            return  new IloaMarker()
            {
                Id = "TestMarker1",
                X = 386020,
                Y = 6670057,
                Color = "ff0000",
                Msg = "TestMarker",
                Shape = 3,
                Size = 3
            };
            ;
        }

        // POST api/values
        [HttpPost]
        public async void Post([FromBody]IloaMarker value)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<IloaMarker>.CreateItemAsync(value);
            }
        }

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
