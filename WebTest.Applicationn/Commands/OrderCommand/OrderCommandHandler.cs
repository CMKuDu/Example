using WebAPITest.Infastructure.UnitOfWork;
using WebTest.Applicationn.Event.OrderEvent;
using WebTest.Applicationn.ICommand;
using WebTest.Applicationn.IEvent;
using WebTest.Domain.IRepository;
using WebTest.Domain.Model;

namespace WebTest.Applicationn.Commands.OrderCommand
{
    public class OrderCommandHandler : ICommandHandler<CreateOrderCommand, string>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IEventHandler<CreateOrderEvent> _eventHandler;
        private readonly IUnitOfWork _unitOfWork;
        public OrderCommandHandler(IOrderRepository orderRepository, IEventHandler<CreateOrderEvent> eventHandler, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _eventHandler = eventHandler;
            _orderRepository = orderRepository;
        }
        public async Task<string> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Id = Guid.NewGuid().ToString(),
                CustomerId = request.OrderDTO.CustomerId,
                ProductId = request.OrderDTO.ProductId,
                Quantity = request.OrderDTO.Quantity,
                TotalAmount = request.OrderDTO.TotalAmount,
            };
            await _orderRepository.Add(order);
            _unitOfWork.Compele();
            var notification = new CreateOrderEvent(request.OrderDTO);
            await _eventHandler.Handle(notification, cancellationToken);
            return order.CustomerId.ToString();
        }

    }
}
