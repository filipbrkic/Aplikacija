using Application.Common.Interface;
using Application.Common.Models;
using Application.DAL.Models;
using Application.MVC.Models;
using AutoMapper;

namespace Application.MVC.Mapper
{
    public class ModelMappings : Profile
    {
        public ModelMappings()
        {
            CreateMap<UserIdentity, UserIdentityDTO>().ReverseMap();
            CreateMap<Registration, RegistrationDTO>().ReverseMap();
            CreateMap<Seminar, SeminarDTO>().ReverseMap();
            CreateMap<UserIdentityDTO, UserViewModel>().ReverseMap();
            CreateMap<RegistrationDTO, RegistrationViewModel>().ReverseMap();
            CreateMap<SeminarDTO, SeminarViewModel>().ReverseMap();

            CreateMap<Filtering, IFiltering>().ReverseMap();
            CreateMap<Paging, IPaging>().ReverseMap();
            CreateMap<Sorting, ISorting>().ReverseMap();

            CreateMap<Seminar, SeminarViewModel>().ReverseMap();
            CreateMap<Registration, RegistrationViewModel>().ReverseMap();
            CreateMap<UserIdentity, UserViewModel>().ReverseMap();
        }
    }
}
