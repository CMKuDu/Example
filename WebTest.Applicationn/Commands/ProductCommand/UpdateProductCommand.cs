using WebTest.Applicationn.DTOs;
using WebTest.Applicationn.ICommand;

namespace WebTest.Applicationn.Commands.ProductCommand
{
    public class UpdateProductCommand : ICommand<string>
    {
        public ProductDTO ProductDTO { get; set; }
        public UpdateProductCommand(ProductDTO productDTO)
        {
            ProductDTO = productDTO;
        }
    }
}
