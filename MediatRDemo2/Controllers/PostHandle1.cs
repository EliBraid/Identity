using MediatR;

namespace MediatRDemo2.Controllers
{
    public class PostHandle1 : NotificationHandler<PostNotification>
    {
        protected override void Handle(PostNotification notification)
        {
            Console.WriteLine("说: "+notification);
        }
    }
}
