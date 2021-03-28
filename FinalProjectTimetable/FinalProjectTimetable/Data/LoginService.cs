using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FinalProjectTimetable.Data
{
    public class LoginService
    {
        public User User { get; private set; }
        private HttpClient _httpService = new HttpClient();


    }
}
