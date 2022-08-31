using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access
{
    public class Credentials
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int? ClientId { get; set; }

        // -------------- Navigation Properties --------------
        public Client Client { get; set; }
    }
}
