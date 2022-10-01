using DAL.Models;
using DAL.Repositories;
using DAL.Repositories.impl;
using DAL.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IPublisherRepository _publisherRepository;

        public BookService(IBookRepository bookRepository, IPublisherRepository publisherRepository)
        {
            _bookRepository = bookRepository;
            _publisherRepository = publisherRepository;
        }

        public async Task<Book> GetBookbyId(string id)
        {
            try
            {
                return _bookRepository.GetById(id);
            } catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PaginatedResult<Book>> GetAllBooks(int pageSize, int pageNumber)
        {
            try
            {
                return await _bookRepository.GetAll().paginate(pageSize, pageNumber);
            } catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Book> CreateBook(Book book)
        {
            try
            {

                Publisher publisher = _publisherRepository.GetById(book.PublisherId);

                if (publisher == null) throw new ArgumentException("Invalid Publisher Id");

                return _bookRepository.Create(book);

            } catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Book> UpdateBook(Book book)
        {
            try
            {

                Publisher publisher = _publisherRepository.GetById(book.PublisherId);

                if (publisher == null) throw new ArgumentException("Invalid Publisher Id");

                return _bookRepository.Update(book);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Book> DeleteBook(string id)
        {
            try
            {

                Book book = _bookRepository.GetById(id);

                if (book == null) throw new ArgumentException("Invalid Book Id");

                return _bookRepository.Delete(book);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
