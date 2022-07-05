
using AutoMapper;
using Sample.Application.Features.Categories.Commands;
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

            // nos ahorra codigo para hacer instancias de la clase pacientes sin tener que poner paciente.nombre.....

            CreateMap<CreateCategoryCommand, Category>();
            // CreateMap<RegisterCommand, Usuarios>();
            #endregion
        }
    }
}
