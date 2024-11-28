using MediatR;

namespace WebTest.Applicationn.IEvent
{
    public interface IEventHandler<in TEvent> : 
        INotificationHandler<TEvent> where TEvent : IEvent
    { }
   
}
