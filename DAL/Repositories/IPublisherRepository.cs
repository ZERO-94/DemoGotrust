using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IPublisherRepository
    {
        public Publisher GetById(string id);
        public IQueryable<Publisher> GetAll();
        public Publisher Create(Publisher publisher);
        public Publisher Update(Publisher publisher);
        public Publisher Delete(Publisher publisher);
    }
}
