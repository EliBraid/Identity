using InterfaceD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDemo
{
    public class MyEmailSend : IEmailSend
    {
        public Task SendAsync(string Email, string Title, string Body)
        {
            Console.WriteLine($"{Email}: {Title},{Body}");

            return Task.CompletedTask;
        }
    }
}
