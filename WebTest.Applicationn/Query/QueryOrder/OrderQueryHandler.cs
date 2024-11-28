using WebTest.Applicationn.DTOs;
using WebTest.Applicationn.IQueries;
using WebTest.Domain.IRepository;

namespace WebTest.Applicationn.Query.QueryOrder
{
    public class OrderQueryHandler : IQueryHandler<GetAllOrderQuery, IEnumerable<OrderDTO>>
    {
        private readonly IOrderRepository _orderRepository;
        public OrderQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderDTO>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAllOrder();
            var orderDTO = order.Select(x => new OrderDTO
            {
                CustomerId = x.CustomerId,
                Id = x.Id,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                TotalAmount = x.TotalAmount,
            }).ToList();
            return orderDTO;
        }
    }
}
