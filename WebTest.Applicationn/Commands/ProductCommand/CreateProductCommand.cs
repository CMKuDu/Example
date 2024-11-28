using WebTest.Applicationn.DTOs;
using WebTest.Applicationn.ICommand;

namespace WebTest.Applicationn.Commands.ProductCommand
{
    public class CreateProductCommand : ICommand<string>
    {
        public ProductDTO ProductDTO { get; set; }
        public CreateProductCommand(ProductDTO productDTO)
        {
            ProductDTO = productDTO;
        }
    }
}
