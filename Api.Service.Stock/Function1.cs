using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Api.Service.Stock
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

        [FunctionName("CheckApplication")]
        public static async Task CheckApplication([TimerTrigger("0 0 * * * *", RunOnStartup = true, UseMonitor = false)] TimerInfo myTimer, ILogger log)
        {
            var factors = FindAllAssignableFrom<IDesignTimeDbContextFactory<DbContext>>();

            foreach (var type in factors)
            {
                try
                {
                    var instance = Activator.CreateInstance(type) as IDesignTimeDbContextFactory<DbContext>;
                    if (instance == null) continue;

                    var context = instance.CreateDbContext(new string[0]);
                    var pending = await context.Database.GetPendingMigrationsAsync().ConfigureAwait(false);

                    if (pending.Count() == 0) continue;

                    await context.Database.MigrateAsync().ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    var message = e.ToString();
                    if (message.Contains("Value cannot be null. (Parameter 'connectionString')") == false)
                    {
                        log.LogError(e.ToString());
                    }
                }


            }
        }

        public static List<Type> FindAllAssignableFrom<T>() where T : class
        {
            var result = AppDomain.CurrentDomain.GetAssemblies().ToList()
                .SelectMany(p => p.DefinedTypes
                    .ToList()
                    .FindAll(t => t.IsAbstract == false && typeof(T)
                    .IsAssignableFrom(t.AsType()))
                    .Select(t => t.AsType()))
                .ToList();

            return result;
        }
    }
}
