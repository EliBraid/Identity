namespace CleanDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var lines = await File.ReadAllLinesAsync("1.txt");

            foreach (var line in lines)
            {
                string[] segments = line.Split('|');

                string email = segments[0];
                string title = segments[1];
                string body = segments[2];

                Console.WriteLine($"发送邮件: {email},{title},{body}");
            }
        }
    }
}