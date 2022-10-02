using BAL.Services;
using DAL.Models;
using DAL.Utilities;
using DemoGotrust.Models.Request;
using DemoGotrust.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoGotrust.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<ActionResult<PaginationResponse<BasicBookResponse>>> Get([FromQuery] int pageSize = 5, [FromQuery] int pageNumber = 0)
        {
            try
            {
                PaginatedResult<Book> books = await _bookService.GetAllBooks(pageSize, pageNumber);
                return books != null ? Ok(new PaginationResponse<BasicBookResponse>{
                        limit = books.limit,
                        page = books.page,
                        total = books.total,
                        objects = books.objects.Select(book => new BasicBookResponse(book)).ToList()
                }) : Ok(new List<BasicBookResponse>());
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<BookController>/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<BasicBookResponse>> Get(string id)
        {
            try { 
                Book book = await _bookService.GetBookbyId(id);
                return book != null ? Ok(new BasicBookResponse(book)) : NoContent();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<ActionResult<Book>> Post([FromBody] CreateBookRequest book)
        {
            try
            {
                Book createdBook = await _bookService.CreateBook(new Book { BookId = book.BookId, AuthorName = book.AuthorName, BookName = book.AuthorName, PublisherId = book.PublisherId, Quantity = book.Quantity });
                if (createdBook == null) return UnprocessableEntity();
                return Ok(new BasicBookResponse(createdBook));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                if(ex.InnerException.Message.Contains("duplicate key"))
                {
                    return BadRequest("Duplicate key!");
                }

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<BookController>/5
        [HttpPut]
        public async Task<ActionResult<Book>> Put([FromBody] UpdateBookRequest book)
        {
            try
            {
                Book updatedBook = await _bookService.UpdateBook(new Book { BookId = book.BookId, AuthorName = book.AuthorName, BookName = book.AuthorName, PublisherId = book.PublisherId, Quantity = book.Quantity });
                if (updatedBook == null) return UnprocessableEntity();
                return Ok(new BasicBookResponse(updatedBook));
            }catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> Delete(string id)
        {
            try
            {
                return await _bookService.DeleteBook(id);
            } catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            } catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
