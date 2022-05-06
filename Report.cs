using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace web
{
    public class Report : IReport
    {
        private readonly ICatalog catalog;

        public Report(ICatalog catalog)
        {
            this.catalog = catalog;
        }

        public async Task Print(HttpContext context)
        {
            foreach (var book in catalog.GetBooks())
            {
                await context.Response.WriteAsync($"{book.Id,-10}{book.Title,-50}{book.Price.ToString("C"),-10}\r\n");
            }
        }
    }

}
