namespace Exercise.App.Profiles
{
    using AutoMapper;
    using Exercise.Core.Models;
    using Exercise.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Employee, ManagerDto>();
            CreateMap<Employee, ProjectionDto>();
            CreateMap<Employee, Employee>();
        }
    }
}
