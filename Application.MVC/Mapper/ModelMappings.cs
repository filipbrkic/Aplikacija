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
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Registration, RegistrationDTO>().ReverseMap();
            CreateMap<Seminar, SeminarDTO>().ReverseMap();
            CreateMap<EmployeeDTO, EmployeeViewModel>().ReverseMap();
            CreateMap<RegistrationDTO, RegistrationViewModel>().ReverseMap();
            CreateMap<SeminarDTO, SeminarViewModel>().ReverseMap();
        }
    }
}
