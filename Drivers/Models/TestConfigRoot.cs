using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayDemo1.Drivers.Models
{
    public class TestConfigRoot
    {
        public string? BrowserName { get; set; }

        public bool? IsHeadless { get; set; }

        public string? ProjectRoot { get; set; }
    }
}
