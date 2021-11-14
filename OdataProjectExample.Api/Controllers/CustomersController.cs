using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using OdataProjectExample.DataAccess.DataContexts;
using OdataProjectExample.Utilities.demoData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdataProjectExample.Api.Controllers
{

    //Conversion from Route API to Odata
    //Commented Route Api approach 




    //[Route("api/[controller]")]
    //[ApiController]
    //public class CustomersController : ControllerBase
    public class CustomersController : ODataController
    {
        private readonly DataContext dataContext;

        public CustomersController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        //[HttpGet]
        //public async Task<IActionResult> Get() {
        //    return Ok(await dataContext.Customers.ToArrayAsync());
        //}

        [EnableQuery]
        public IActionResult Get() {
            return Ok(dataContext.Customers);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Customer customer) {

            if (customer is null) return BadRequest();
            await dataContext.AddAsync(customer);
            await dataContext.SaveChangesAsync();
         
            return CreatedAtAction("ToDo",customer);        
        }

        [HttpPost]
        [Route("fillWithDemoData")]
        public async Task<IActionResult> Fill() {
            if ((await dataContext.Customers.CountAsync()) > 0) return BadRequest();

            var demoData = new DemoData();
            var data = demoData.GenerateDemoData(10);

            await dataContext.Customers.AddRangeAsync(data.Item1);
            await dataContext.Orders.AddRangeAsync(data.Item2);
            await dataContext.SaveChangesAsync();
            
            return Ok();
        }
    }
}
