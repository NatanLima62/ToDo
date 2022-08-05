using AutoMapper;
using ToDo.Api.ViewModels.AssignmentViewModel;
using ToDo.Domain.Entities;
using ToDo.Services.DTOs;

namespace ToDo.Tests.Configuration;

public static class AutomapperConfigutation
{
    public static IMapper CreateMapper() =>
        new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Assignment, AssignmentDTO>().ReverseMap();
            cfg.CreateMap<CreateAssignmentViewModel, AssignmentDTO>().ReverseMap();
            cfg.CreateMap<UpdateAssignmentViewModel, AssignmentDTO>().ReverseMap();
        }).CreateMapper();
}