using BAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public interface IAuthService
    {
        public JwtDto login(string username, string password);
    }
}
