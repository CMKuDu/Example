using MediatR;
using WebTest.Applicationn.DTOs;
using WebTest.Applicationn.IEvent;

namespace WebTest.Applicationn.Event.ProductEvent
{
    public class CreateProductEvent : WebTest.Applicationn.IEvent.IEvent, INotification
    {
        public ProductDTO ProductDTO { get; set; }

        public CreateProductEvent(ProductDTO productDTO)
        {
            ProductDTO = productDTO;
        }
    }
}
