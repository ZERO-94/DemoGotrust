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
    public class PublisherService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IPublisherRepository _publisherRepository;

        public PublisherService()
        {
            _bookRepository = new BookRepository();
            _publisherRepository = new PublisherRepository();
        }

        public async Task<Publisher> GetPublisherbyId(string id)
        {
            try
            {
                return _publisherRepository.GetById(id);
            } catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PaginatedResult<Publisher>> GetAllPublishers(int pageSize, int pageNumber)
        {
            try
            {
                return await _publisherRepository.GetAll().paginate(pageSize, pageNumber);
            } catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Publisher> CreatePublisher(Publisher publisher)
        {
            try
            {
                return _publisherRepository.Create(publisher);

            } catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Publisher> UpdatePublisher(Publisher publisher)
        {
            try
            {
                return _publisherRepository.Update(publisher);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Publisher> DeletePublisher(string id)
        {
            try
            {

                Publisher publisher = _publisherRepository.GetById(id);

                if (publisher == null) throw new ArgumentException("Invalid Publisher Id");

                return _publisherRepository.Delete(publisher);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
