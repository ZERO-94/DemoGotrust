using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.impl
{
    public class AccountUserRepository : IAccountUserRepository
    {
        private readonly BookPublisherContext _context;

        public AccountUserRepository(BookPublisherContext context)
        {
            _context = context;
        }

        public AccountUser GetByUserIdAndPassword(string userId, string password)
        {
            try
            {

                return _context.AccountUsers.FirstOrDefault(user => user.UserId.Equals(userId) && user.UserPassword.Equals(password));

            } catch (Exception ex)
            {
                throw;
            }
        }
    }
}
