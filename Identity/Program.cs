using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Identity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入名字");
            string name = Console.ReadLine();
            using (DataDbcontext context = new DataDbcontext())
                using(var tx = context.Database.BeginTransaction())
            {
                var h =context.Houses.FromSqlInterpolated($"SELECT * FROM Houses WITH(UPDLOCK) WHERE Id=1").Single();

                if (!string.IsNullOrEmpty(h.Owner))
                {
                    if(h.Owner == name)
                    {
                        Console.WriteLine("房子已经抢到");
                    }
                    else
                    {
                        Console.WriteLine($"房子已经被{h.Owner}抢到了");
                    }
                    return;
                }
                h.Owner = name;
                Thread.Sleep(5000);
                Console.WriteLine("恭喜抢到了");
                context.SaveChanges();
                tx.Commit();
                Console.ReadKey();
            }

            
        }
    }
}