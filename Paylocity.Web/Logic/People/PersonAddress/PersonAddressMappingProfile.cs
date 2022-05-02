using AutoMapper;
using Paylocity.Web.Logic.People.PersonAddress.Create;
using Paylocity.Web.Logic.People.PersonAddress.Update;
using Paylocity.Web.Models.Entities;

namespace Paylocity.Web.Logic.People.PersonAddress
{
    public class PersonAddressMappingProfile : Profile
    {
        public PersonAddressMappingProfile()
        {
            CreateMap<CreateAddress, Address>()
              .ForMember(dst => dst.CreatedByUser, src => src.MapFrom((a, b, c, d) => d.Items["UserId"]))
              .ForMember(dst => dst.LastModifiedByUser, src => src.MapFrom((a, b, c, d) => d.Items["UserId"]))
                ;

            CreateMap<UpdateAddress, Address>()
              .ForMember(dst => dst.CreatedByUser, src => src.MapFrom((a, b, c, d) => d.Items["UserId"]))
              .ForMember(dst => dst.LastModifiedByUser, src => src.MapFrom((a, b, c, d) => d.Items["UserId"]))
                ;
        }
    }
}
