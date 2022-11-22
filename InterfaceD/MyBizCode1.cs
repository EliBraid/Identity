using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceD
{
    public class MyBizCode1
    {
        private IEmailProvider emailProvider;
        private IEmailSend emailSend;

        public MyBizCode1(IEmailProvider emailProvider, IEmailSend emailSend)
        {
            this.emailProvider = emailProvider;
            this.emailSend = emailSend;
        }

        public async Task DoMyIt()
        {
            var emails = emailProvider.GetSendEmail();

            foreach (var email in emails)
            {
                await emailSend.SendAsync(email.Email, email.Title, email.Body);
                Task.Delay(1000).Wait();
            }
        }

    }
}
