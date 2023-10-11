using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ViewModel.Authentication
{
    public class LoginResponseViewModel
    {
        public string Token { get; set; }
        public DateTime TokenEndTime { get; set; }
    }
}
