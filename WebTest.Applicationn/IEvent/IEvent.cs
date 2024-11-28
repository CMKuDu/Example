using MediatR;

namespace WebTest.Applicationn.IEvent
{
    public interface IEvent : INotification{ }
    //public interface IEvent <out TResult> : INotification { }
}
