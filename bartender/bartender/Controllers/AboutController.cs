using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bartender.Controllers
{
    [Route("[controller]/[action]")]
    public class AboutController
    {
        
        public string Phone()
        {
            return "904-428-3830";
        }

        public string Address()
        {
            return "USA";
        }
    }
}
