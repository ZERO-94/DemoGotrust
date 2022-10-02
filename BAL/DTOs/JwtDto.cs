using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.DTOs
{
    public class JwtDto
    {
        public string accessToken { get; set; }
        public string expire { get; set; }
    }
}
