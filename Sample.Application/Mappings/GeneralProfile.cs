
using AutoMapper;
using Sample.Application.Features.Categories.Commands;
using Sample.Application.Features.Customers.Commands.Create;
using Sample.Domain.Entities;

namespace Sample.Application.Mappings
{
    //clase de mapeo
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {

            #region DTOs
            //CreateMap<Usuarios, UserRequest>();


            #endregion
            #region Commands 

            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<CreateCustomerCommand, Customer>();
            // CreateMap<RegisterCommand, Usuarios>();
            #endregion
        }
    }
}
