using AspNetCoreApi21.Data;
using AspNetCoreApi21.Data.DummyData;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AspNetCoreApi21.Controllers
{
    public class BooksController : ODataController
    {
        private BookContext _db;

        public BooksController(BookContext context)
        {
            _db = context;
            if (context.Books.Count() == 0)
            {
                foreach (var b in BooksDataSource.GetBooks())
                {
                    context.Books.Add(b);
                    context.Presses.Add(b.Press);
                }
                context.SaveChanges();
            }
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_db.Books);
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            return Ok(_db.Books.FirstOrDefault(c => c.Id == key));
        }
    }
}
