using InterfaceD;
using Microsoft.Extensions.DependencyInjection;

namespace CleanDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //var lines = await File.ReadAllLinesAsync("1.txt");

            //foreach (var line in lines)
            //{
            //    string[] segments = line.Split('|');

            //    string email = segments[0];
            //    string title = segments[1];
            //    string body = segments[2];

            //    Console.WriteLine($"发送邮件: {email},{title},{body}");
            //}

            ServiceCollection service = new ServiceCollection();
            service.AddScoped<MyBizCode1>();

            service.AddScoped<IEmailProvider, EmailProvider>();
            service.AddScoped<IEmailSend, MyEmailSend>();

            var provider = service.BuildServiceProvider();

            var go = provider.GetService<MyBizCode1>();

            await go.DoMyIt();
        }
    }
}