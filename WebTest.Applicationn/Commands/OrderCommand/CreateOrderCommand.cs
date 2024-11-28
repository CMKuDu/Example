using WebTest.Applicationn.DTOs;
using WebTest.Applicationn.ICommand;

namespace WebTest.Applicationn.Commands.OrderCommand
{
    public class CreateOrderCommand : ICommand<string>
    {
        public OrderDTO OrderDTO { get; }
        public CreateOrderCommand(OrderDTO orderDTO) { OrderDTO = orderDTO; }
    }
}
