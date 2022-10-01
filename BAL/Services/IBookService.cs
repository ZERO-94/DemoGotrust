using DAL.Models;
using DAL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public interface IBookService
    {
        public Task<Book> GetBookbyId(string id);

        public Task<PaginatedResult<Book>> GetAllBooks(int pageSize, int pageNumber);

        public Task<Book> CreateBook(Book book);

        public Task<Book> UpdateBook(Book book);

        public Task<Book> DeleteBook(string id);
    }
}
