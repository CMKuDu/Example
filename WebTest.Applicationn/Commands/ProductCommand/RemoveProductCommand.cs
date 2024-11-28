using WebTest.Applicationn.ICommand;

namespace WebTest.Applicationn.Commands.ProductCommand
{
    public class RemoveProductCommand : ICommand<string>
    {
        public int ProductId { get; set; }
        public RemoveProductCommand (int productId) {  ProductId = productId; }
    }
}
