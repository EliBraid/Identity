using MediatR;

namespace MediatRDemo2
{
    public record PostNotification(string Body): INotification;
}
