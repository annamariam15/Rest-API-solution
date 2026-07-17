/*using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;
using AnnaMariaSolution.Server.DTOs;
using AnnaMariaSolution.Server.Models;

namespace AnnaMariaSolution.Server.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateProjectRequest, Project>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.IsComplete, opt => opt.Ignore())
                .ForMember(dest => dest.ProjectEmployees, opt => opt.Ignore())
                .ForMember(dest => dest.Tasks, opt => opt.Ignore());

        }
    }
}*/