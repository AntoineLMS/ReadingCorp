using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ReadingCorp;
using ReadingCorp.Models;

namespace ReadingCorp.Controllers
{
    public class bookController : ApiController
    {
        private ReadingCorpEntities db = new ReadingCorpEntities();

        public IQueryable<BookViewModel> GetAllBooks()
        {
            var books = from b in db.Book
                               select new BookViewModel()
                               {
                                   Book_id = b.Book_id,
                                   Book_name = b.Book_name,
                                   Author = b.Author,
                                   Category = b.Category,
                                   Description = b.Book_description,
                                   RegistrationDate = (DateTime)b.RegistrationTime
                               };
            return books;
        }

        [ResponseType(typeof(BookViewModel))]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            Book book = await db.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            BookViewModel b = new BookViewModel();
            b.Book_id = book.Book_id;
            b.Book_name = book.Book_name;
            b.Author = book.Author;
            b.Description = book.Book_description;
            b.RegistrationDate = (DateTime)book.RegistrationTime;
            b.Category = book.Category;

            return Ok(b);
        }

        [ResponseType(typeof(BookViewModel))]
        public async Task<IHttpActionResult> PutBook(int id, BookViewModel b)
        {
            Book book = await db.Book.FindAsync(id);
            if (!ModelState.IsValid || book == null)
            {
                return BadRequest(ModelState);
            }
            
            book.Book_name = b.Book_name;
            book.Author = b.Author;
            book.Book_description = b.Description;
            book.RegistrationTime = DateTime.Now;
            book.Category = b.Category;
            db.Entry(book).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            b.Book_id = id;
            return Ok(b);
        }

        [ResponseType(typeof(int))]
        public async Task<IHttpActionResult> PostNewBook(BookViewModel b)
        {
            if (!ModelState.IsValid || b == null)
            {
                return BadRequest(ModelState);
            }
            Book book = new Book();
            using (db)
            {
                book.Book_name = b.Book_name;
                book.Author = b.Author;
                book.Category = b.Category;
                book.Book_description = b.Description;
                book.RegistrationTime = DateTime.Now;

                db.Book.Add(book);
                await db.SaveChangesAsync();
            }
        
            return Ok(book.Book_id);
        }

        private bool BookExists(int id)
        {
            return db.Book.Count(e => e.Book_id == id) > 0;
        }
    }
}