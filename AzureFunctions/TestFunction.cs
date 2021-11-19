using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using TestFunction.DataAccess;
using TestFunction.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace TestFunction
{
    public class TestFunction
    {
        private readonly TestDemoDbContext _dbContext;
        public TestFunction(TestDemoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FunctionName("TestFunction")]
        public async Task<List<User>> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            await Task.Delay(0);
            log.LogInformation("C# HTTP trigger function processed a request.");

            try
            {
                //adding some data to db..
                //await _dbContext.Users.AddAsync(new User { Name = $"Dev{DateTime.Now.Ticks}", Email = $"honeydevp+{new Random().Next()}@gmail.com", Password = "asdjkkekjhnb" });
                //await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
            }

            var users = await _dbContext.Users.ToListAsync();
            
            //optional --> modifying the httpcontext object
            //req.HttpContext.Response.ContentType = "application/xml";

            return users;
        }
    }
}
