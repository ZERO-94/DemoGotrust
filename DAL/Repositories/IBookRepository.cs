using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IBookRepository
    {
        public Book GetById(string id);
        public IQueryable<Book> GetAll();
        public Book Create(Book book);
        public Book Update(Book book);
        public Book Delete(Book book);
    }
}
