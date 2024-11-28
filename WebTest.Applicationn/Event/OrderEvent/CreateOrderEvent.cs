using MediatR;
using WebTest.Applicationn.DTOs;

namespace WebTest.Applicationn.Event.OrderEvent
{
    public class CreateOrderEvent : WebTest.Applicationn.IEvent.IEvent, INotification
    {
        public OrderDTO OrderDTO { get; set; }
        public CreateOrderEvent(OrderDTO orderDTO)
        {
            OrderDTO = orderDTO;
        }
    }
}
