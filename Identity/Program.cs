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
            {
                var h = context.Houses.Single(h => h.Id == 1);

                if(!string.IsNullOrEmpty(h.Owner))
                {
                    if(h.Owner == name)
                    {
                        Console.WriteLine("抢到了");
                    }
                    else
                    {
                        Console.WriteLine("被抢了");
                    }
                    return;
                }
                h.Owner = name;
                Thread.Sleep(5000);
                Console.WriteLine("恭喜抢到了");
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {

                    Console.WriteLine("并发访问冲突");
                }
                
                Console.ReadKey();
            }
                //    using(var tx = context.Database.BeginTransaction())
                //{
                //    var h =context.Houses.FromSqlInterpolated($"SELECT * FROM Houses WITH(UPDLOCK) WHERE Id=1").Single();

                //    if (!string.IsNullOrEmpty(h.Owner))
                //    {
                //        if(h.Owner == name)
                //        {
                //            Console.WriteLine("房子已经抢到");
                //        }
                //        else
                //        {
                //            Console.WriteLine($"房子已经被{h.Owner}抢到了");
                //        }
                //        return;
                //    }
                //    h.Owner = name;
                
            }

            
        }
    }
}