using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceD
{
    public interface IEmailSend
    {
        public Task SendAsync(string Email,string Title,string Body);
    }
}
