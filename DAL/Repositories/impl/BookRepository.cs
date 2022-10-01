using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.impl
{
    public class BookRepository : IBookRepository
    {
        private readonly BookPublisherContext _context;

        public BookRepository(BookPublisherContext context)
        {
            _context = context;
        }

        public Book Create(Book book)
        {
            try
            {
                if (book != null)
                {
                    var obj = _context.Books.Add(book);
                    if (obj != null)
                    {
                        _context.SaveChanges();
                        return obj.Entity;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    throw new ArgumentNullException();
                }

                return book;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Book Delete(Book book)
        {
            try
            {
                if (book != null)
                {
                    var obj = _context.Books.Remove(book);
                    if (obj != null)
                    {
                        _context.SaveChanges();
                        return obj.Entity;
                    } else
                    {
                        return null;
                    }
                } else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<Book> GetAll()
        {
            try
            {
                return _context.Books.Include("Publisher").AsNoTracking();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Book GetById(string id)
        {
            try
            {
                return _context.Books.Include("Publisher").AsNoTracking().FirstOrDefault(book => book.BookId.Equals(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Book Update(Book book)
        {
            try
            {
                if (book != null)
                {
                    var obj = _context.Books.Update(book);
                    if (obj != null)
                    {
                        _context.SaveChanges();
                        return obj.Entity;
                    }
                    else
                    {
                        return null;
                    }
                } else
                {
                    throw new ArgumentNullException();
                }

                return book;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
