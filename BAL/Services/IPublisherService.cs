using DAL.Models;
using DAL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public interface IPublisherService
    {
        public Task<Publisher> GetPublisherbyId(string id);

        public Task<PaginatedResult<Publisher>> GetAllPublishers(int pageSize, int pageNumber);

        public Task<Publisher> CreatePublisher(Publisher book);

        public Task<Publisher> UpdatePublisher(Publisher book);

        public Task<Publisher> DeletePublisher(string id);
    }
}
