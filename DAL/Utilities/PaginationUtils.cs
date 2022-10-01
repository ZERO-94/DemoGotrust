using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Utilities
{
    public static class Extensions
    {
        public static async Task<PaginatedResult<T>> paginate<T>(this IQueryable<T> source,
                                                int pageSize, int pageNumber)
        {
            return await new PaginatedResult<T>(pageNumber, pageSize).paginate(source);
        }
    }

    public class PaginatedResult<T> : ActionResult
    {
        private const int defaultPageSize = 20;
        private const int maxPageSize = 50;

        public int total { get;  set; }
        public int limit { get; private set; }
        public int page { get; private set; }
        public List<T> objects { get; private set; }

        public PaginatedResult(int pageNumber, int pageSize = defaultPageSize)
        {
            limit = pageSize;
            page = pageNumber;

            if (limit < 0 || limit > maxPageSize)
            {
                limit = defaultPageSize;
            }
            if (pageNumber < 0)
            {
                page = 0;
            }
        }

        internal async Task<PaginatedResult<T>> paginate(IQueryable<T> queryable)
        {
            total = queryable.Count();

            if (limit > total)
            {
                limit = total;
                page = 0;
            }

            int skip = page * limit;
            if (skip + limit > total)
            {
                if(skip >= total)
                {
                    //always get last page
                    page = total % limit != 0 ? total / limit : (total / limit) - 1; 
                    skip = page * limit;
                } else
                {
                    limit = total - skip;
                }
                
            }

            objects = await queryable.Skip(skip).Take(limit).ToListAsync();
            return this;
        }
    }
}
