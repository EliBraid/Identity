using InterfaceD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDemo
{
    public class EmailProvider : IEmailProvider
    {
        public IEnumerable<EmailInfo> GetSendEmail()
        {
            var lines = File.ReadAllLines("1.txt");

            foreach (var line in lines)
            {
                var sec = line.Split('|');

                var email = sec[0];
                var title = sec[1];
                var body = sec[2];

                yield return new EmailInfo(email, title, body);
            }
        }
    }
}
