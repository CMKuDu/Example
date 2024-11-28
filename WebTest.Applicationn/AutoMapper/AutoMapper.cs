using AutoMapper;
using WebTest.Applicationn.DTOs;
using WebTest.Domain.Model;

namespace WebTest.Applicationn.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<Payment, PaymentDTO>().ReverseMap();
            //CreateMap<Category, CategoryDTO>().ReverseMap();
        }

    }
}
