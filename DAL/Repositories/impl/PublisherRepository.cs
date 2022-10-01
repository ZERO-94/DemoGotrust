﻿using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.impl
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly BookPublisherContext _context;

        public PublisherRepository()
        {
            _context = new BookPublisherContext();
        }

        public Publisher Create(Publisher publisher)
        {
            try
            {
                if (publisher != null)
                {
                    var obj = _context.Add(publisher);
                    if (obj != null)
                    {
                        _context.SaveChangesAsync();
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

                return publisher;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Publisher Delete(Publisher publisher)
        {
            try
            {
                if (publisher != null)
                {
                    var obj = _context.Remove(publisher);
                    if (obj != null)
                    {
                        _context.SaveChangesAsync();
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

        public IEnumerable<Publisher> GetAll()
        {
            try
            {
                return _context.Publishers.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Publisher GetById(string id)
        {
            try
            {
                return _context.Publishers.FirstOrDefault(publisher => publisher.PublisherId.Equals(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Publisher Update(Publisher publisher)
        {
            try
            {
                if (publisher != null)
                {
                    var obj = _context.Update(publisher);
                    if (obj != null)
                    {
                        _context.SaveChangesAsync();
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

                return publisher;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}